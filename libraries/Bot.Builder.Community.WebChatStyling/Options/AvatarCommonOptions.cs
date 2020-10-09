using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class AvatarCommonOptions : StylingOption
    {
        public AvatarCommonOptions() : base(typeof(Defaults)) {}

        public static class Defaults
        {
            public static CSSLengthUnit BorderRadius { get => new CSSLengthUnit("50%"); }

            public static int Size { get => 40; }

            public static AvatarGroupSetting Group { get => AvatarGroupSetting.Status; }
        }

        [LengthStyling("avatarBorderRadius")]
        public CSSLengthUnit BorderRadius { get; set; } = Defaults.BorderRadius;

        [SimpleStyling("avatarSize")]
        public int? Size { get; set; } = Defaults.Size;

        [EnumStyling("showAvatarInGroup", typeof(AvatarGroupSetting))]
        public AvatarGroupSetting? Group { get; set; } = Defaults.Group;
    }

}
