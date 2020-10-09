using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class BubbleOptions : StylingOption, INameTemplate
    {
        public BubbleOptions() : this(false)
        {
        }
        public BubbleOptions(bool isBotBubble) : base(typeof(Defaults))            
        {
            this.IsBotBubble = isBotBubble;
        }

        public bool IsBotBubble { get; set; }

        public static class Defaults
        {
            public static string Background { get => "White"; }
            public static string BorderColor { get => "#E6E6E6"; }
            public static CSSLengthUnit BorderRadius { get => new CSSLengthUnit("2px");}
            public static string BorderStyle { get =>  "solid";}
            public static CSSLengthUnit BorderWidth { get => new CSSLengthUnit("2px"); }
            public static int NubOffset { get =>  0;}
            public static int? NubSize { get => null; }
            public static string TextColor { get =>  "Black";}
        }

        /// <summary>
        /// A HTML color name (White) or code (#E6E6E6)
        /// </summary>
        [NameTemplate("bubble[x]Background")]
        [SimpleStyling]
        public string Background { get; set; } = Defaults.Background;

        /// <summary>
        /// A HTML color name (White) or code (#E6E6E6)
        /// </summary>
        [NameTemplate("bubble[x]BorderColor")]
        [SimpleStyling]
        public string BorderColor { get; set; } = Defaults.BorderColor;

        [NameTemplate("bubble[x]BorderRadius")] 
        [LengthStyling("")]
        public CSSLengthUnit BorderRadius { get; set; } = Defaults.BorderRadius;

        [NameTemplate("bubble[x]BorderStyle")]
        [SimpleStyling]
        public string BorderStyle { get; set; } = Defaults.BorderStyle;

        [NameTemplate("bubble[x]BorderWidth")]
        [LengthStyling("")]
        public CSSLengthUnit BorderWidth { get; set; } = Defaults.BorderWidth;

        /// <summary>
        /// Either a positive/negative number,
        /// use -2 for "bottom"
        /// </summary>
        [NameTemplate("bubble[x]NubOffset")]
        [SimpleStyling]
        public int? NubOffset { get; set; } = Defaults.NubOffset;


        /// <summary>
        /// 0 means a sharp corner.
        /// </summary>
        [NameTemplate("bubble[x]NubSize")] 
        [SimpleStyling]
        public int? NubSize { get; set; } = Defaults.NubSize;

        [NameTemplate("bubble[x]TextColor")]
        [SimpleStyling]
        public string TextColor { get; set; } = Defaults.TextColor;

        #region NameTemplate members
        private static string ResolveNameTemplate(string templateName, object[] templateParams)
        {
            var value = (bool)templateParams[0] ? "" : "FromUser";
            return Regex.Replace(templateName, @"\[x]", value);
        }

        object[] INameTemplate.NameTemplateParams => new object[] { IsBotBubble};

        Func<string, object[], string> INameTemplate.Resolver => ResolveNameTemplate;
        #endregion

        public override IList<string> GetOptionNames()
        {
            var names = new List<string>();
            var soUser = GetOptionNames(new BubbleOptions(false));
            var soBot = GetOptionNames(new BubbleOptions(true));

            names.AddRange(soUser);
            names.AddRange(soBot);


            return names;
        }
    }

}
