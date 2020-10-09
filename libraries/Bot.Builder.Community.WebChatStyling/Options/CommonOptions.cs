using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class CommonOptions : StylingOption
    {
        public CommonOptions() : base(typeof(Defaults)) {}

        public static class Defaults
        { 
            public static WordBreakSetting WordBreak { get => WordBreakSetting.BreakWord; }
            public static bool MarkdownCRLF { get => true; }
            public static bool RichCardWrapTitle { get => false; }
            public static bool HideScrollToEndButton { get => false; }
            public static bool ShowSpokenText { get => false; }
            public static int GeneralFontSize { get => 85; }
            public static int VideoHeight { get => 270; }
            public static int NotificationDebounceTimeout { get => 400; }
            public static bool UseEmojis { get => true; }
            
        }

        [EnumStyling("messageActivityWordBreak")]
        public WordBreakSetting WordBreak { get; set; } = Defaults.WordBreak;
        
        [SimpleStyling("markdownRespectCRLF")]
        public bool MarkdownCRLF { get; set; } = Defaults.MarkdownCRLF;
        
        [SimpleStyling("richCardWrapTitle")]
        public bool RichCardWrapTitle { get; set; } = Defaults.RichCardWrapTitle;

        [SimpleStyling("hideScrollToEndButton")]
        public bool HideScrollToEndButton { get; set; } = Defaults.HideScrollToEndButton;

        [SimpleStyling("showSpokenText")]
        public bool ShowSpokenText { get; set; } = Defaults.ShowSpokenText;

        [PercentageStyling("newMessagesButtonFontSize")]
        public int GeneralFontSize { get; set; } = Defaults.GeneralFontSize;

        [SimpleStyling("videoHeight")]
        public int VideoHeight { get; set; } = Defaults.VideoHeight;

        [SimpleStyling("notificationDebounceTimeout")]
        public int NotificationDebounceTimeout { get; set; } = Defaults.NotificationDebounceTimeout ;

        // Emoji
        //emojiSet: true // true || false || { ':)' : '😊'}
        [SimpleStyling("emojiSet")]
        public bool UseEmojis { get; set; } = Defaults.UseEmojis;

    }

}
