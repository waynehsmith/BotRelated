using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class BubbleCommonOptions : StylingOption
    {
        public BubbleCommonOptions() : base(typeof(Defaults)) {}

        public static class Defaults
        {
            public static int ImageHeight { get => 240; }
            public static int MaxWidth { get => 480;} // screen width = 600px
            public static int MinHeight { get => 40; }
            public static int MinWidth { get => 250; } // min screen width = 300px, Edge requires 372px (https://developer.microsoft.com/en-us/microsoft-edge/platform/issues/13621468/)
        }

        [SimpleStyling("bubbleImageHeight")]
        public int? ImageHeight { get; set; } = Defaults.ImageHeight;
        [SimpleStyling("bubbleMaxWidth")]
        public int? MaxWidth { get; set; } = Defaults.MaxWidth;
        [SimpleStyling("bubbleMinHeight")]
        public int? MinHeight { get; set; } = Defaults.MinHeight;
        [SimpleStyling("bubbleMinWidth")]
        public int? MinWidth { get; set; } = Defaults.MinWidth;
    }

}
