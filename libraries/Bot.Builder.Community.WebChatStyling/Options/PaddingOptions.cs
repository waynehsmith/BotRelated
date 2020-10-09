using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class PaddingOptions : StylingOption
    {
        public PaddingOptions() : base(typeof(Defaults)) { }

        public static class Defaults
        {
            public static int Regular { get; set; } = 10;
            public static int Wide { get => Regular * 2; }
        }

        [SimpleStyling("paddingRegular")]
        public int? Regular { get; set; } = Defaults.Regular;
        [SimpleStyling("paddingWide")]
        public int? Wide { get; set; } = Defaults.Wide;
    }

}
