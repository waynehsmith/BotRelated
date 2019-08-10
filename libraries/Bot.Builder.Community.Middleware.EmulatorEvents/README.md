## Emulator Events Middleware

### Build status
| Branch | Status | Recommended NuGet package version |
| ------ | ------ | ------ |
| master | [![Build status](https://ci.appveyor.com/api/projects/status/b9123gl3kih8x9cb?svg=true)](https://ci.appveyor.com/project/garypretty/botbuilder-community) | [![NuGet version](https://img.shields.io/badge/NuGet-1.0.39-blue.svg)](https://www.nuget.org/packages/Bot.Builder.Community.Middleware.EmulatorEvents/) |

### Description
This is part of the [Bot Builder Community Extensions](https://github.com/garypretty/botbuilder-community) project which contains various pieces of middleware, recognizers and other components for use with the Bot Builder .NET SDK v4.

This piece of middleware will allow you to send in "events" to a Bot as though they came from a DirectLine client from the Bot Framework Emulator. 

### Installation

Available via NuGet package [Bot.Builder.Community.Middleware.EmulatorEvents](https://www.nuget.org/packages/Bot.Builder.Community.Middleware.EmulatorEvents/)

Install into your project using the following command in the package manager;
```
    PM> Install-Package Bot.Builder.Community.Middleware.EmulatorEvents
```

### Sample

A basic sample for using this component can be found [here](https://github.com/BotBuilderCommunity/botbuilder-community-dotnet/tree/master/samples/EmulatorEvents).

### Usage

Emulator Events is a piece of middleware that attempts to translate event payloads into events that can be handled by a bot created.

For example, a common scenario is to sent a greeting when a user connects to a bot but before a message is sent as seen [here](https://github.com/microsoft/BotFramework-WebChat/tree/master/samples/15.d.backchannel-send-welcome-event).  When you connect via the emulator to test this, the emulator cannot currently send the event over to the bot to test this functionality.

If the original code looked like this:

```js
    {
       type: 'event',
       payload: {
         name: 'webchat/join',
         value: { 'language':'en-us'}
       }
    }
```
then within the emulator this event could be sent using the following message:

```
/emulatorEvent {"name": "webchat/join", "value": {"language":"en-us"}}
```

From the bot's perspective, it receives an event activity named **webchat/join** with the *value* of the activity equal to 
**{"name":"webchat/join","value":{"language":"en-US"}}**.

Alternatively, the emulator could send a file with the following contents to achieve the same results:

```js
{
  "type": "emulatorEvent",
  "payload": 
	{
		"name": "webchat/join",
        "value": 
        {
        "language": "en-US"
        }
   }
}
```

#### Bot modifications

Within the startup code for the bot, add the following lines during middleware construction

```cs
    services.AddSingleton<EmulatorEventProcessor>();
```

### Advanced
The emulator event processor has properties and methods that can be set to alter its behavior.

*EventToken*
:   used to set the command used to process a message as an event - defaults to **emulatorEvent**

*HandleException*
: delegate called when an exception occurs in the Emulator Event Processor

*HandleEventFired*
: delegate called when event data has been processed and the event is about to fire

*HandleEventNotFired*
: delegate called when event data was processed and the event cannot be fired

```cs
var eep = new EmulatorEventProcessor()
    {
        EventToken = "eep",
        HandleException = async (turnContext, ex) => 
        {
            await turnContext.SendActivityAsync(MessageFactory.Text($"EventProcessor caught: {ex.Message}"));
        }
    };
services.AddSingleton<EmulatorEventProcessor>(eep);
```

