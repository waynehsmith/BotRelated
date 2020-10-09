using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class TimestampOptions : StylingOption
    {
        public TimestampOptions() : base(typeof(Defaults)) { }

        public static class Defaults
        {
            public static bool Group { get => true; }
            public static int Timeout { get => 20000; }
            public static int TimeoutAttachments { get => 120000; }
            public static string Color { get => null; }
            public static TimestampFormatSetting Format { get => TimestampFormatSetting.relative; }
        }


        [SimpleStyling("groupTimestamp")]
        public bool Group { get; set; } = Defaults.Group;

        [SimpleStyling("sendTimeout")]
        public int Timeout { get; set; } = Defaults.Timeout;

        [SimpleStyling("sendTimeoutForAttachments")]
        public int TimeoutAttachments { get; set; } = Defaults.TimeoutAttachments;

        [SimpleStyling("timestampColor")]
        public string Color { get; set; } = Defaults.Color;

        [EnumStyling("timestampFormat", typeof(TimestampFormatSetting))]
        public TimestampFormatSetting Format { get; set; } = Defaults.Format;
    }

}
