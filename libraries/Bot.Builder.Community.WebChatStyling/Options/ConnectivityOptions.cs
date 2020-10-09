using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Builder.Community.WebChatStyling
{
    public class ConnectivityOptions : StylingOption
    {
        public ConnectivityOptions() : base(typeof(Defaults)) { }
        public static class Defaults
        {
            public static double IconPadding { get => PaddingOptions.Defaults.Regular * 1.2; }
            public static double MarginHorizontal { get => PaddingOptions.Defaults.Regular * 1.4; }
            public static double MarginVertical { get => PaddingOptions.Defaults.Regular * 0.8; }
            public static int TextSize { get => 75; }
            public static string Failed { get => "#C50F1F"; }
            public static string Slow { get => "#EAA300"; }
            public static string NotificationText { get => "#5E5E5E"; }
            public static int SlowAfter { get => 15000; }
        }

        [SimpleStyling("connectivityIconPadding")]
        public double? IconPadding { get; set; } = Defaults.IconPadding;
        [SimpleStyling("connectivityMarginLeftRight")] 
        public double? MarginHorizontal { get; set; } = Defaults.MarginHorizontal;
        [SimpleStyling("connectivityMarginTopBottom")] 
        public double? MarginVertical { get; set; } = Defaults.MarginVertical;
        [PercentageStyling("connectivityTextSize")]
        public int? TextSize { get; set; } = Defaults.TextSize;
        [SimpleStyling("failedConnectivity")] 
        public string Failed { get; set; } = Defaults.Failed;
        [SimpleStyling("slowConnectivity")] 
        public string Slow { get; set; } = Defaults.Slow;
        [SimpleStyling("notificationText")] 
        public string NotificationText { get; set; } = Defaults.NotificationText;
        [SimpleStyling("slowConnectionAfter")] 
        public int? SlowAfter { get; set; } = Defaults.SlowAfter;

    }
}
