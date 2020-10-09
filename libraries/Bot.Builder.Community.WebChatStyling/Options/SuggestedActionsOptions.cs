using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class SuggestedActionsOptions : StylingOption, INameTemplate
    {
        public SuggestedActionsOptions() : this(false)
        {
        }
        public SuggestedActionsOptions(bool isDisabled) : 
            base( isDisabled ? typeof(DefaultsDisabled) : typeof(Defaults))            
        {
            this.IsDisabled = isDisabled;
            if (isDisabled)
            {
                this.Background = DefaultsDisabled.Background;
                this.Border = DefaultsDisabled.Border;
                this.BorderColor = DefaultsDisabled.BorderColor;
                this.BorderRadius = DefaultsDisabled.BorderRadius;
                this.BorderStyle = DefaultsDisabled.BorderStyle;
                this.BorderWidth = DefaultsDisabled.BorderWidth;
                this.TextColor = DefaultsDisabled.TextColor;
            }
            else
            {
                this.Background = Defaults.Background;
                this.Border = Defaults.Border;
                this.BorderColor = Defaults.BorderColor;
                this.BorderRadius = Defaults.BorderRadius;
                this.BorderStyle = Defaults.BorderStyle;
                this.BorderWidth = Defaults.BorderWidth;
                this.TextColor = Defaults.TextColor;
            }
        }

        public bool IsDisabled { get; set; }

        public static class Defaults
        {
            public static string Background { get => "White"; }
            public static CSSBorder Border { get => null; }
            public static string BorderColor { get => null; }
            public static CSSLengthUnit BorderRadius { get => new CSSLengthUnit("0px");}
            public static CSSBorderStyle BorderStyle { get =>  CSSBorderStyle.solid;}
            public static CSSLengthUnit BorderWidth { get => new CSSLengthUnit("2px"); }
            public static string TextColor { get =>  null;}
        }
        public static class DefaultsDisabled
        {
            public static string Background { get => null; }
            public static CSSBorder Border { get => null; }
            public static string BorderColor { get => "#E6E6E6"; }
            public static CSSLengthUnit BorderRadius { get => new CSSLengthUnit("2px"); }
            public static CSSBorderStyle BorderStyle { get => CSSBorderStyle.solid; }
            public static CSSLengthUnit BorderWidth { get => new CSSLengthUnit("2px"); }
            public static string TextColor { get => null; }
        }

        /// <summary>
        /// A HTML color name (White) or code (#E6E6E6)
        /// </summary>
        [NameTemplate("suggestedAction[x]Background")]
        [SimpleStyling]
        public string Background { get; set; } = Defaults.Background;

        /// <summary>
        /// A CSS Border value
        /// </summary>
        [NameTemplate("suggestedAction[x]Border")]
        [SimpleStyling("","CSSText")]
        public CSSBorder Border { get; set; } = Defaults.Border;

        /// <summary>
        /// A HTML color name (White) or code (#E6E6E6)
        /// </summary>
        [NameTemplate("suggestedAction[x]BorderColor")]
        [SimpleStyling]
        public string BorderColor { get; set; } = Defaults.BorderColor;

        [NameTemplate("suggestedAction[x]BorderRadius")] 
        [LengthStyling("")]
        public CSSLengthUnit BorderRadius { get; set; } = Defaults.BorderRadius;

        [NameTemplate("suggestedAction[x]BorderStyle")] 
        [SimpleStyling]
        public CSSBorderStyle BorderStyle { get; set; } = Defaults.BorderStyle;

        [NameTemplate("suggestedAction[x]BorderWidth")]
        [LengthStyling("")]
        public CSSLengthUnit BorderWidth { get; set; } = Defaults.BorderWidth;


        [NameTemplate("suggestedAction[x]TextColor")]
        [SimpleStyling]
        public string TextColor { get; set; } = Defaults.TextColor;

        #region NameTemplate members
        private static string ResolveNameTemplate(string templateName, object[] templateParams)
        {
            var value = (bool)templateParams[0] ? "Disabled" : ""; 
            return Regex.Replace(templateName, @"\[x]", value);
        }

        object[] INameTemplate.NameTemplateParams => new object[] { IsDisabled};

        Func<string, object[], string> INameTemplate.Resolver => ResolveNameTemplate;
        #endregion

        public override IList<string> GetOptionNames()
        {
            var names = new List<string>();
            var soEnabled = GetOptionNames(new SuggestedActionsOptions(false));
            var soDisabled = GetOptionNames(new SuggestedActionsOptions(true));

            names.AddRange(soEnabled);
            names.AddRange(soDisabled);


            return names;
        }
    }

}
