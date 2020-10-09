using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Builder.Community.WebChatStyling
{
    public class ToastOptions : StylingOption
    {
        public ToastOptions() : base(typeof(Defaults)) { }
        
        public static class Defaults
        {
            public static bool Hide { get => false; }
            public static int Height { get => 32; }
            public static int MaxHeight { get => 32 * 5; }
            public static int SingularMaxHeight { get => 50; }
            public static double FontSize { get => 87.5; }
            public static int IconWidth { get => 36; }
            public static string SeparatorColor { get => "#E8EAEC"; }
            public static int TextPadding { get => 6; }

            public static string ErrorBackgroundColor { get => "#FDE7E9"; }
            public static string ErrorColor { get => "#A80000"; }
            public static string InfoBackgroundColor { get => "#CEF1FF"; }
            public static string InfoColor { get => "#105E7D"; }
            public static string SuccessBackgroundColor { get => "#DFF6DD"; }
            public static string SuccessColor { get => "#107C10"; }
            public static string WarnBackgroundColor { get => "#FFF4CE"; }
            public static string WarnColor { get => "#3B3A39"; }
        }

        [SimpleStyling("hideToaster")]
        public bool? Hide { get; set; } = Defaults.Hide;
        [SimpleStyling("toasterHeight")]
        public int? Height { get; set; } = Defaults.Height;
        [SimpleStyling("toasterMaxHeight")]
        public int? MaxHeight { get; set; } = Defaults.MaxHeight;
        [SimpleStyling("toasterSingularMaxHeight")]
        public int? SingularMaxHeight { get; set; } = Defaults.SingularMaxHeight;
        [PercentageStyling("toastFontSize")]
        public double? FontSize { get; set; } = Defaults.FontSize;
        [SimpleStyling("toastIconWidth")]
        public int? IconWidth { get; set; } = Defaults.IconWidth;
        [SimpleStyling("toastSeparatorColor")]
        public string SeparatorColor { get; set; } = Defaults.SeparatorColor;
        [SimpleStyling("toastTextPadding")]
        public int? TextPadding { get; set; } = Defaults.TextPadding;

        [SimpleStyling("toastErrorBackgroundColor")]
        public string ErrorBackgroundColor { get; set; } = Defaults.ErrorBackgroundColor;
        [SimpleStyling("toastErrorColor")]
        public string ErrorColor { get; set; } = Defaults.ErrorColor;
        [SimpleStyling("toastInfoBackgroundColor")]
        public string InfoBackgroundColor { get; set; } = Defaults.InfoBackgroundColor;
        [SimpleStyling("toastInfoColor")]
        public string InfoColor { get; set; } = Defaults.InfoColor;
        [SimpleStyling("toastSuccessBackgroundColor")]
        public string SuccessBackgroundColor { get; set; } = Defaults.SuccessBackgroundColor;
        [SimpleStyling("toastSuccessColor")]
        public string SuccessColor { get; set; } = Defaults.SuccessColor;
        [SimpleStyling("toastWarnBackgroundColor")]
        public string WarnBackgroundColor { get; set; } = Defaults.WarnBackgroundColor;
        [SimpleStyling("toastWarnColor")]
        public string WarnColor { get; set; } = Defaults.WarnColor;
    }
}
