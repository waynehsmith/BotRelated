using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class WebChatStyleOptions
    {
        [OptionStyling]
        public BubbleOptions BotBubble { get; set; }
        [OptionStyling]
        public BubbleOptions UserBubble { get; set; }
        [OptionStyling]
        public BubbleCommonOptions AllBubbles { get; set; }

        [OptionStyling]
        public ChatColorOptions ChatColors { get; set; }
        [OptionStyling]
        public PaddingOptions Padding { get; set; }

        [OptionStyling]
        public FontOptions Fonts { get; set; }

        [OptionStyling]
        public AvatarOptions BotAvatar { get; set; }
        [OptionStyling]
        public AvatarOptions UserAvatar { get; set; }
        [OptionStyling]
        public AvatarCommonOptions AllAvatars { get; set; }

        [OptionStyling]
        public CommonOptions Common { get; set; }

        [OptionStyling]
        public RootOptions Root { get; set; }
        [OptionStyling]
        public SendBoxOptions SendBox { get; set; }

        [OptionStyling]
        public SuggestedActionsOptions DisabledSuggestedActions { get; set; }
        [OptionStyling]
        public SuggestedActionsOptions EnabledSuggestedActions { get; set; }
        [OptionStyling]
        public SuggestedActionsCommonOptions AllSuggestedActions { get; set; }

        [OptionStyling]
        public TimestampOptions Timestamp { get; set; }
        [OptionStyling]
        public TranscriptOptions TranscriptBackground { get; set; }
        [OptionStyling]
        public TranscriptOptions TranscriptColor { get; set; }

        [OptionStyling]
        public ConnectivityOptions Connectivity { get; set; }

        [OptionStyling]
        public TypingAnimationOptions TypingAnimation { get; set; }
        [OptionStyling]
        public SpinnerAnimationOptions SpinnerAnimation { get; set; }

        [OptionStyling]
        public UploadThumbnailOptions UploadThumbnail { get; set; }

        [OptionStyling]
        public ToastOptions Toast { get; set; }
    }
}
