using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class ChatColorOptions : StylingOption
    {
        public ChatColorOptions() : base(typeof(Defaults)) { }

        public static class Defaults
        {
            public static string AccentColor { get => "#0063B1"; }
            public static string BackgroundColor { get => "White"; }
            public static string CardEmphasisBackgroundColor { get => "#F0F0F0"; }
            public static string SubtleColor { get => "#767676"; }// With contrast 4.5:1 to white;
        }

        [SimpleStyling("accent")]
        public string AccentColor { get; set; } = Defaults.AccentColor;
        [SimpleStyling("backgroundColor")]
        public string BackgroundColor { get; set; } = Defaults.BackgroundColor;
        [SimpleStyling("cardEmphasisBackgroundColor")]
        public string CardEmphasisBackgroundColor { get; set; } = Defaults.CardEmphasisBackgroundColor;
        [SimpleStyling("subtle")]
        public string SubtleColor { get; set; } = Defaults.SubtleColor;        
    }

}
