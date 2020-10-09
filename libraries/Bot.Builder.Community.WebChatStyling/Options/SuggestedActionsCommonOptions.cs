using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Builder.Community.WebChatStyling
{
    public class SuggestedActionsCommonOptions : StylingOption
    {
        public SuggestedActionsCommonOptions() : base(typeof(Defaults)) { }

        public static class Defaults
        {
            public static int Height { get => 40; }
            public static int ImageHeight { get => 20; }
            public static SuggestedActionLayoutSetting Layout { get =>  SuggestedActionLayoutSetting.carousel; }
            public static string StackedHeight { get => null; }
            public static string StackedOverflow { get => null; }
            public static string CarouselCursor { get => null; }
            public static int CarouselWidth { get => 40; }
            public static int CarouselSize { get => 20; }
        }

        [SimpleStyling("suggestedActionHeight")]
        public int Height { get; set; } = Defaults.Height;
        [SimpleStyling("suggestedActionImageHeight")]
        public int ImageHeight { get; set; } = Defaults.ImageHeight;

        [EnumStyling("suggestedActionLayout")]
        public SuggestedActionLayoutSetting Layout { get; set; } = Defaults.Layout;

        // Suggested actions 'stacked' layout
        [SimpleStyling("suggestedActionsStackedHeight")]//: undefined, // defaults to 'auto'
        public string StackedHeight { get; set; } = Defaults.StackedHeight;

        [SimpleStyling("suggestedActionsStackedOverflow")]//: undefined, // defaults to 'auto'
        public string StackedOverflow { get; set; } = Defaults.StackedOverflow;

        [SimpleStyling("suggestedActionsCarouselFlipperCursor")]
        public string CarouselCursor { get; set; } = Defaults.StackedOverflow;
        [SimpleStyling("suggestedActionsCarouselFlipperBoxWidth")] 
        public int? CarouselWidth { get; set; } = Defaults.CarouselWidth;
        [SimpleStyling("suggestedActionsCarouselFlipperSize")] 
        public int? CarouselSize { get; set; } = Defaults.CarouselSize;

    }
}
