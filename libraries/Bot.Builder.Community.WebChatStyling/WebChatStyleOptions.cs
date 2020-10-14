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

        public static WebChatStyleOptions Default { 
            get
            {
                return new WebChatStyleOptions() { 
                    BotBubble = new BubbleOptions(true),
                    UserBubble = new BubbleOptions(false),
                    AllBubbles = new BubbleCommonOptions(),

                    ChatColors = new ChatColorOptions(),
                    Fonts = new FontOptions(),

                    BotAvatar = new AvatarOptions(true),
                    UserAvatar = new AvatarOptions(false),
                    AllAvatars = new AvatarCommonOptions(),

                    Padding = new PaddingOptions(),
                    Common = new CommonOptions(),
                    Root = new RootOptions(),
                    SendBox = new SendBoxOptions(),

                    EnabledSuggestedActions = new SuggestedActionsOptions(false),
                    DisabledSuggestedActions = new SuggestedActionsOptions(true),
                    AllSuggestedActions = new SuggestedActionsCommonOptions(),

                    Timestamp = new TimestampOptions(),
                    Toast = new ToastOptions(),


                    TranscriptBackground = new TranscriptOptions(false),
                    TranscriptColor = new TranscriptOptions(true),

                    Connectivity = new ConnectivityOptions(),

                    SpinnerAnimation = new SpinnerAnimationOptions(),
                    TypingAnimation = new TypingAnimationOptions(),
                    UploadThumbnail = new UploadThumbnailOptions(),
                };
            } 
        }
    }
}
