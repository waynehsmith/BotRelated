using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Builder.Community.Middleware.EmulatorEvents
{
    public class EventPayload
    {
        [JsonProperty("name")]
        public string EventName { get; set; }

        [JsonProperty("value")]
        public JToken Value { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }
}
