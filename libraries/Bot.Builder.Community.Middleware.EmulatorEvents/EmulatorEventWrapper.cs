using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Builder.Community.Middleware.EmulatorEvents
{
    public class EmulatorEventWrapper
    {
        [JsonProperty("type")]
        public string WrapperType { get; set; }

        [JsonProperty("payload")]
        public EventPayload Payload { get; set; }
    }
}
