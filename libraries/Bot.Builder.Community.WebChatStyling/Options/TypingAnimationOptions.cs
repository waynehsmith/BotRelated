using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class TypingAnimationOptions : StylingOption
    {
        public TypingAnimationOptions(): base(typeof(Defaults)) { }

        public static class Defaults
        {
            public static int Height { get => 20; }
            public static int Width { get => 64; }
            public static string BackgroundImage { get => null;}
            public static int? Duration { get => 5000; }
        }



        [SimpleStyling("typingAnimationBackgroundImage")]
        public string BackgroundImage { get; set; } = Defaults.BackgroundImage;

        [SimpleStyling("typingAnimationDuration")]
        public int? Duration { get; set; } = Defaults.Duration;


        [SimpleStyling("typingAnimationHeight")]
        public int? Height { get; set; } = Defaults.Height;

        [SimpleStyling("typingAnimationWidth")]
        public int? Width { get; set; } = Defaults.Width;

    }

}
