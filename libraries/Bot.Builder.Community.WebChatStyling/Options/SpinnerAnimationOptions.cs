using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class SpinnerAnimationOptions : StylingOption
    {
        public SpinnerAnimationOptions(): base(typeof(Defaults)) { }

        public static class Defaults
        {
            public static int Height { get => 16; }
            public static int Width { get => 16; }
            public static string BackgroundImage { get => null;}
            public static int? Padding { get => 12; }
        }



        [SimpleStyling("spinnerAnimationBackgroundImage")]
        public string BackgroundImage { get; set; } = Defaults.BackgroundImage;

        [SimpleStyling("spinnerAnimationHeight")]
        public int? Height { get; set; } = Defaults.Height;

        [SimpleStyling("spinnerAnimationWidth")]
        public int? Width { get; set; } = Defaults.Width;

        [SimpleStyling("spinnerAnimationPadding")]
        public int? Padding { get; set; } = Defaults.Padding;




    }

}
