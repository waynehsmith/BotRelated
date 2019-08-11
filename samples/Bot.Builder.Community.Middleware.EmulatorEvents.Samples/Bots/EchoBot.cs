// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Bot.Builder.Community.Middleware.EmulatorEvents;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var rawText = turnContext.Activity.Text;
            if (string.IsNullOrEmpty(rawText) || (rawText == "menu"))
            {
                await ShowMenu(turnContext, cancellationToken);
            }
            else
            {
                await turnContext.SendActivityAsync(MessageFactory.Text(
                    $"Echo: {turnContext.Activity.Text}\r\nEnter 'menu' for a menu of samples"), cancellationToken);
            }

        }

        private static async Task ShowMenu(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            string[] paths = { ".", "SampleEvents" };
            string fullPath = Path.Combine(paths);
            DirectoryInfo di = new DirectoryInfo(fullPath);
            var fileNames = di.GetFiles("*.json");
            var sampleActions = new List<CardAction>();
            foreach (var item in fileNames)
            {
                var baseName = Path.GetFileNameWithoutExtension(item.FullName);
                var wrapper = JObject.Parse(File.ReadAllText(item.FullName));
                var ca = new CardAction()
                {
                    Title = baseName,
                    Type = ActionTypes.ImBack,
                    Value = "/emulatorEvent " + wrapper["payload"].ToString().Replace("\n", "").Replace("\r", "")
                };
                sampleActions.Add(ca);
            }

            var activity = MessageFactory.Text("Here are some samples you can try:");
            activity.SuggestedActions = new SuggestedActions {
                Actions = sampleActions
            };
            /*

            var card = new HeroCard
            {
                Text = "Here are some samples you can try:",
                Buttons = sampleActions
            };

            var activity = MessageFactory.Attachment(card.ToAttachment());
            */
            await turnContext.SendActivityAsync(activity, cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(
                        "Welcome!\r\nAt any point enter 'menu' to get a list of samples"));
                    await ShowMenu(turnContext, cancellationToken);
                }
            }
        }

        protected override async Task OnEventActivityAsync(ITurnContext<IEventActivity> turnContext, CancellationToken cancellationToken)
        {
            var ea = turnContext.Activity.AsEventActivity();
            var payload = JsonConvert.DeserializeObject<EventPayload>(ea.Value.ToString());
            await turnContext.SendActivityAsync(MessageFactory.Text($"Executing event: {ea.Name}"));
            switch (ea.Name)
            {
                case "identifyUser":
                    await turnContext.SendActivityAsync(MessageFactory.Text(
                        $"I now know you as {payload.AdditionalData["givenName"]} {payload.AdditionalData["surName"]} ({payload.AdditionalData["email"]})"));
                    break;
                case "singleValue":
                    await turnContext.SendActivityAsync(MessageFactory.Text(
                        $"Received a single value of: {payload.Value.ToString()}"));
                    break;
                case "complexValue":
                    var cvData = payload.Value; 
                    await turnContext.SendActivityAsync(MessageFactory.Text(
                        $"**First Name**: {cvData["givenName"]}  **Last Name**: {cvData["surName"]}"));
                    break;
                case "complexUser":
                    var cvUser = payload.AdditionalData["userData"];
                    await turnContext.SendActivityAsync(MessageFactory.Text(
                        $"*Email*: {cvUser["email"]}"));
                    break;
                case "complexPhone":
                    var cvPhone = payload.AdditionalData["userData"];
                    var target = cvPhone.SelectToken("$.phone.extension");
                    await turnContext.SendActivityAsync(MessageFactory.Text(
                        $"You can be reached at extension: {target.ToString()}"));
                    break;
            }
        }
    }
}
