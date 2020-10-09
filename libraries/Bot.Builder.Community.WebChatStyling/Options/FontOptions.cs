using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    // TODO: Create Defaults Class
    // TODO: Implement StylingOption
    public class FontOptions : StylingOption
    {
        public FontOptions() : base(typeof(Defaults)) { }

        public static class Defaults
        {
            public static List<string> Primary { get => new List<string> 
            { "Calibri", "Helvetica Neue", "Arial", "sans-serif" }; }
            public static List<string> Monospace { get => new List<string> 
            { "Consolas", "Courier New", "monospace" }; }
            public static int SmallPercentage { get => 80; }
        }

        [ListStyling("primaryFont", ", ")]
        public List<string> Primary { get; set; } = Defaults.Primary;
        [ListStyling("monospaceFont", ", ")]
        public List<string> Monospace { get; set; } = Defaults.Monospace;

        [PercentageStyling("fontSizeSmall")]
        public int? SmallPercentage { get; set; } = Defaults.SmallPercentage;
    }

}
