using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bot.Builder.Community.Middleware.EmulatorEvents
{
    public class EmulatorEventProcessor : IMiddleware
    {
        #region Default Notification Handlers
        private static readonly Func<ITurnContext, Exception, Task> DefaultHandleException =
            async (turnContext, ex) =>
            {
                await turnContext.SendActivityAsync(MessageFactory.Text($"EmulatorEventProcessor caught: {ex.Message}"));
            };
        private static readonly Func<ITurnContext, Activity, Task> DefaultHandleEventFired =
            async (turnContext, activity) =>
            {
                string nameToUse = "**Unknown**";
                if (!String.IsNullOrEmpty(activity.Name))
                {
                    nameToUse = activity.Name;
                }
                await turnContext.SendActivityAsync(MessageFactory.Text($"Firing event {nameToUse}"));

            };
        private static readonly Func<ITurnContext, Exception, Task> DefaultHandleEventNotFired =
            async (turnContext, ex) => {
                await turnContext.SendActivityAsync(MessageFactory.Text($"Unable to fire event: {ex.Message}"));
            };
        #endregion

        public EmulatorEventProcessor()
        {
            ClearDefaultHandlers();
        }

        /// <summary>
        /// Command token for events to process - defaults to "emulatorEvent"
        /// </summary>
        public string EventToken { get; set; } = "emulatorEvent";

        #region Notification Handlers
        /// <summary>
        /// Called when an exception occurs in the Emulator Event Processor
        /// </summary>
        public Func<ITurnContext, Exception, Task> HandleException { get; set; } 

        /// <summary>
        /// Called when event data has been processed and the event is about to fire
        /// </summary>
        public Func<ITurnContext, Activity, Task> HandleEventFired { get; set; }

        /// <summary>
        /// Called when event data was processed and the event cannot be fired
        /// </summary>
        public Func<ITurnContext, Exception, Task> HandleEventNotFired { get; set; }


        /// <summary>
        /// Enable handlers that send information back to the emulator when there is a problem
        /// </summary>
        public void EnableDefaultHandlers()
        {
            this.HandleEventFired = DefaultHandleEventFired;
            this.HandleEventNotFired = DefaultHandleEventNotFired;
            this.HandleException = DefaultHandleException;
        }

        /// <summary>
        /// Reset the Handlers to the default values
        /// </summary>
        public void ClearDefaultHandlers()
        {
            this.HandleEventFired = async (turnContext, activity) => { await Task.CompletedTask; };
            this.HandleEventNotFired = async (turnContext, ex) => { await Task.CompletedTask; };
            this.HandleException = async (turnContext, ex) => { await Task.CompletedTask; };
        }
        #endregion

        /// <summary>
        /// Extracts information and converts the activity from a message to an event
        /// </summary>
        /// <param name="turnContext">The context object for this turn.</param>
        /// <param name="nextTurn">The delegate to call to continue the bot middleware pipeline.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects
        /// or threads to receive notice of cancellation.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        /// <seealso cref="ITurnContext"/>
        /// <seealso cref="Bot.Schema.IActivity"/>
        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {

            // Attach to the activity
            var activity = turnContext.Activity;

            // Only try to process the data if it was sent from the emulator and was a message
            if ((activity.Type == ActivityTypes.Message) && (activity.ChannelId == "emulator"))
            {
                // Create a Typing Indicator activity and send it back to the emulator to 
                // avoid a timeout while attempting to process the event
                var typingActivity = Activity.CreateTypingActivity();
                await turnContext.SendActivityAsync(typingActivity);

                // Determine if the user sent in event data in the text of the message
                if (!String.IsNullOrEmpty(activity.Text)  && 
                    activity.Text.StartsWith($"/{EventToken} ",StringComparison.InvariantCultureIgnoreCase))
                {
                    // Get the length of the activity text
                    var dataLength = activity.Text.Length;

                    // Verify that the activity text has data after the command token
                    if (dataLength > EventToken.Length + 2)
                    {
                        // Retrieve the payload data from the message text
                        var payloadData = activity.Text.Substring(EventToken.Length + 2);

                        EventPayload payload = null;
                        try
                        { 
                            // Deserialize the payload into and EventPayload object
                            payload = JsonConvert.DeserializeObject<EventPayload>(payloadData);
                        }
                        catch (Exception peX)
                        {
                            var ae = new ArgumentException("Invalid event data", peX);
                            // Call the Exception Processor
                            await HandleException(turnContext, ae);
                        }
                        if (payload != null)
                        {
                            // Parse the payload
                            await ParseEventPayload(turnContext, activity, payload);
                        }
                    }
                    else
                    {
                        await HandleException(turnContext, new ArgumentException("No event data received!"));
                    }
                }
                else if ((activity.Attachments?.Count == 1) && 
                    (activity.Attachments?[0].ContentType== "application/json"))
                {
                    // The user may have sent the event information in the attachment.
                    // Execute only if we have a single attachment and it is a Json file

                    // Get the attachment
                    var attachment = activity.Attachments.First();

                    string rawData = String.Empty;
                    try
                    {
                        using (HttpClient httpClient = new HttpClient() {
                            Timeout = TimeSpan.FromSeconds(5)
                        })
                        {
                            /*
                            // Skype & MS Teams attachment URLs are secured by a JwtToken, so we need to pass the token from our bot.
                            if ((activity.ChannelId.Equals("skype", StringComparison.InvariantCultureIgnoreCase) || 
                                activity.ChannelId.Equals("msteams", StringComparison.InvariantCultureIgnoreCase))
                                && new Uri(attachment.ContentUrl).Host.EndsWith("skype.com"))
                            {
                                var token = await new MicrosoftAppCredentials().GetTokenAsync();
                                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                            }
                            */

                            // Get the data from the Url
                            var responseMessage = await httpClient.GetAsync(attachment.ContentUrl);
                            var contentLenghtBytes = responseMessage.Content.Headers.ContentLength;
                            rawData = await responseMessage.Content.ReadAsStringAsync();
                        }
                        // Parse the data into a JObject
                        var bo = JObject.Parse(rawData);
                        // The actual data is in a property called "data" containing a JToken
                        JToken t = bo["data"];

                        // Pull the bytes from the JToken
                        var databytes = t.Children().Select(x => (byte)x).ToArray();

                        // Decode the byte data to a JSON string
                        var jsonWrapperString = Encoding.Default.GetString(
                                databytes,
                                0,
                                databytes.Length);

                        // Deserialize the data into an EmulatorEventWrapper object
                        EmulatorEventWrapper jsonWrapper = JsonConvert
                            .DeserializeObject<EmulatorEventWrapper>(jsonWrapperString);

                        // Parse the event data
                        await ParseEventWrapper(turnContext, activity, jsonWrapper);
                    }
                    catch(TaskCanceledException tce)
                    {
                        await HandleException(turnContext, 
                            new HttpRequestException("Unable to get attachment!", tce));
                    }
                    catch(Exception eewEx)
                    {
                        // Call the Exception Processor
                        await HandleException(turnContext, eewEx);
                    }
                }
            }
            
            await next(cancellationToken).ConfigureAwait(false);
        }

        #region Payload and Wrapper methods
        private async Task ParseEventPayload(ITurnContext turnContext, Activity activity, EventPayload payload)
        {
            try
            {
                // Validate that we have an event name
                if (String.IsNullOrEmpty(payload.EventName))
                {
                    throw new ArgumentException("Missing name parameter!");
                }
                else
                {
                    // Update the properties on the activity so the bot can process the event
                    activity.Name = payload.EventName;
                    activity.Value = JsonConvert.SerializeObject(payload);
                    activity.Text = null;
                    activity.Type = "event";

                    // Fire the notification that the event will be fired
                    await HandleEventFired(turnContext, activity);
                }
            }
            catch (Exception ex)
            {
                // fire the notification that the event will not be fired
                await HandleEventNotFired(turnContext, ex);
            }
        }

        private async Task ParseEventWrapper(ITurnContext turnContext, Activity activity, EmulatorEventWrapper wrapper)
        {
            try
            {
                // Validate that the JSON file's WrapperType matches the EventToken
                if (String.Compare(wrapper.WrapperType, EventToken, true) == 0)
                {
                    // Parse the event payload
                    await ParseEventPayload(turnContext, activity, wrapper.Payload);
                }
                else
                {
                    // Not an emulator event to process
                }                
            }
            catch(Exception ex)
            {
                await HandleEventNotFired(turnContext, ex);
                //await turnContext.SendActivityAsync(MessageFactory.Text($"Unable to fire event: {ex.Message}"));
            }
        }
        #endregion
    }
}
