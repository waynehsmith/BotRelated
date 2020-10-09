using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class TranscriptOptions : StylingOption, INameTemplate
    {
        private readonly bool isBackground;

        public TranscriptOptions() : this(false) { }

        public TranscriptOptions(bool isBackground) : base( isBackground ? typeof(DefaultsBackground) : typeof(Defaults))
        {
            this.isBackground = isBackground;
            if (isBackground)
            {
                this.Color = DefaultsBackground.Color;
                this.ColorFocus = DefaultsBackground.ColorFocus;
                this.ColorHover = DefaultsBackground.ColorHover;
            }
            else
            {
                this.Color = Defaults.Color;
                this.ColorFocus = Defaults.ColorFocus;
                this.ColorHover = Defaults.ColorHover;
            }
        }

        public bool IsBackground { get => isBackground;}

        public static class DefaultsBackground
        {
            public static string Color { get => "rgba(0, 0, 0, .6)"; }
            public static string ColorFocus { get => "rgba(0, 0, 0, .8)"; }
            public static string ColorHover { get => "rgba(0, 0, 0, .8)"; }
        }
        public static class Defaults
        {
            public static string Color { get => "White"; }
            public static string ColorFocus { get => null; }
            public static string ColorHover { get => null; }


        }
        /*
          // Transcript overlay buttons (e.g. carousel and suggested action flippers, scroll to bottom, etc.)
          newMessagesButtonFontSize: '85%',

          transcriptOverlayButtonBackground: 'rgba(0, 0, 0, .6)',
          transcriptOverlayButtonBackgroundOnFocus: 'rgba(0, 0, 0, .8)',
          transcriptOverlayButtonBackgroundOnHover: 'rgba(0, 0, 0, .8)',

          transcriptOverlayButtonColor: 'White',
          transcriptOverlayButtonColorOnFocus: undefined, // defaults to transcriptOverlayButtonColor
          transcriptOverlayButtonColorOnHover: undefined, // defaults to transcriptOverlayButtonColor
        */



        [NameTemplate("transcriptOverlayButton[x]")]
        [SimpleStyling()]
        public string Color { get; set; }

        [NameTemplate("transcriptOverlayButton[x]OnFocus")]
        [SimpleStyling()]
        public string ColorFocus { get; set; }

        [NameTemplate("transcriptOverlayButton[x]OnHover")]
        [SimpleStyling()]
        public string ColorHover { get; set; }
        #region NameTemplate members
        private static string ResolveNameTemplate(string templateName, object[] templateParams)
        {
            var value = (bool)templateParams[0] ? "Background" : "Color";
            return Regex.Replace(templateName, @"\[x]", value);
        }

        object[] INameTemplate.NameTemplateParams => new object[] { IsBackground };

        Func<string, object[], string> INameTemplate.Resolver => ResolveNameTemplate;
        #endregion
        public override IList<string> GetOptionNames()
        {
            var names = new List<string>();
            var soColor = GetOptionNames(new TranscriptOptions(false));
            var soBackground = GetOptionNames(new TranscriptOptions(true));

            names.AddRange(soColor);
            names.AddRange(soBackground);


            return names;
        }
    }

}
