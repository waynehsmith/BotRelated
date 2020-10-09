using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class AvatarOptions : StylingOption, INameTemplate
    {
        public AvatarOptions() : this(false) { }
        public AvatarOptions(bool isBotAvatar) : base(typeof(Defaults))
        {
            this.IsBotAvatar = isBotAvatar;
        }

        public bool IsBotAvatar { get; set; }

        public static class Defaults
        {
            public static string BackgroundColor { get => null; }
            public static string Image { get => null; }
            public static string Initials { get => null; }
        }

        /// <summary>
        /// A HTML color name (White) or code (#E6E6E6)
        /// </summary>
        [NameTemplate("[x]AvatarBackgroundColor")]
        [SimpleStyling()]
        public string BackgroundColor { get; set; } = Defaults.BackgroundColor;

        [NameTemplate("[x]AvatarImage")]
        [SimpleStyling()]
        public string Image { get; set; } = Defaults.Image;

        [NameTemplate("[x]AvatarInitials")]
        [SimpleStyling()]
        public string Initials { get; set; } = Defaults.Initials;

        #region NameTemplate members
        private static string ResolveNameTemplate(string templateName, object[] templateParams)
        {
            var value = (bool)templateParams[0] ? "bot" : "user";
            return Regex.Replace(templateName, @"\[x]", value);
        }

        object[] INameTemplate.NameTemplateParams => new object[] { IsBotAvatar };

        Func<string, object[], string> INameTemplate.Resolver => ResolveNameTemplate;
        #endregion

        public override IList<string> GetOptionNames()
        {
            var names = new List<string>();
            var soUser = GetOptionNames(new AvatarOptions(false));
            var soBot = GetOptionNames(new AvatarOptions(true));

            names.AddRange(soUser);
            names.AddRange(soBot);


            return names;
        }
    }
}
