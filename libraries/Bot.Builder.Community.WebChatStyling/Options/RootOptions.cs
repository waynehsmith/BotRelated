using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class RootOptions : StylingOption
    {
        public RootOptions() : base(typeof(Defaults)) { }

        public static class Defaults
        {
            public static CSSLengthUnit Height { get => new CSSLengthUnit("100%"); }
            public static CSSLengthUnit Width { get => new CSSLengthUnit("100%"); }
            public static int ZIndex { get => 0; }
        }

        [LengthStyling("rootHeight")]
        public CSSLengthUnit Height { get; set; } = Defaults.Height;

        [LengthStyling("rootWidth")]
        public CSSLengthUnit Width { get; set; } = Defaults.Width;
        
        [SimpleStyling("rootZIndex")]
        public int? ZIndex { get; set; } = Defaults.ZIndex;
    }

}
