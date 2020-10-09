using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class SendBoxOptions : StylingOption
    {
        public SendBoxOptions() : base(typeof(Defaults)) { }

        public static class Defaults
        {
            public static int Height { get => 40; }
            public static int HeightMax { get => 200; }

            public static bool Hide { get => false; }
            public static bool HideUploadButton { get => false; }
            public static string MicrophoneColor { get => "#F33"; }
            public static string BackgroundColor { get => "White"; }
            public static string TextColor { get => "Black"; }
            public static string TextColorDisabled { get => null; }
            public static string PlaceholderColor { get => null; }
            public static bool TextWrap { get => false; }

            public static string ButtonColor { get => null; }
            public static string ButtonColorDisabled { get => "#CCC"; }
            public static string ButtonColorFocus { get => "#333"; }
            public static string ButtonColorHover { get => "#333"; }

            public static CSSBorder BorderBottom { get => new CSSBorder(); }
            public static CSSBorder BorderLeft { get => new CSSBorder(); }
            public static CSSBorder BorderRight { get => new CSSBorder(); }
            public static CSSBorder BorderTop { get => new CSSBorder("solid 1px #E6E6E6"); }
        }

        [SimpleStyling("sendBoxHeight")]
        public int Height { get; set; } = Defaults.Height;
        [SimpleStyling("sendBoxMaxHeight")] 
        public int HeightMax { get; set; } = Defaults.HeightMax;

        [SimpleStyling("hideSendBox")] 
        public bool Hide { get; set; } = Defaults.Hide;
        [SimpleStyling("hideUploadButton")] 
        public bool HideUploadButton { get; set; } = Defaults.HideUploadButton;
        [SimpleStyling("microphoneButtonColorOnDictate")] 
        public string MicrophoneColor { get; set; } = Defaults.MicrophoneColor;
        [SimpleStyling("sendBoxBackground")] 
        public string BackgroundColor { get; set; } = Defaults.BackgroundColor;
        [SimpleStyling("sendBoxTextColor")] 
        public string TextColor { get; set; } = Defaults.TextColor;
        [SimpleStyling("sendBoxDisabledTextColor")] 
        public string TextColorDisabled { get; set; } = Defaults.TextColorDisabled;
        [SimpleStyling("sendBoxPlaceholderColor")] 
        public string PlaceholderColor { get; set; } = Defaults.PlaceholderColor;
        [SimpleStyling("sendBoxTextWrap")] 
        public bool TextWrap { get; set; } = Defaults.TextWrap;

        [SimpleStyling("sendBoxButtonColor")] 
        public string ButtonColor { get; set; } = Defaults.ButtonColor;
        [SimpleStyling("sendBoxButtonColorOnDisabled")] 
        public string ButtonColorDisabled { get; set; } = Defaults.ButtonColorDisabled;
        [SimpleStyling("sendBoxButtonColorOnFocus")]
        public string ButtonColorFocus { get; set; } = Defaults.ButtonColorFocus;
        [SimpleStyling("sendBoxButtonColorOnHover")]
        public string ButtonColorHover { get; set; } = Defaults.ButtonColorHover;

        [SimpleStyling("sendBoxBorderBottom", "CSSText")] 
        public CSSBorder BorderBottom { get; set; } = Defaults.BorderBottom;
        [SimpleStyling("sendBoxBorderLeft", "CSSText")] 
        public CSSBorder BorderLeft { get; set; } = Defaults.BorderLeft;
        [SimpleStyling("sendBoxBorderRight", "CSSText")] 
        public CSSBorder BorderRight { get; set; } = Defaults.BorderRight;
        [SimpleStyling("sendBoxBorderTop", "CSSText")] 
        public CSSBorder BorderTop { get; set; } = Defaults.BorderTop;
    }

}
