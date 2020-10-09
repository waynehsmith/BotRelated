using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Bot.Builder.Community.Helpers;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class GeneralTests : OptionsTests
    {
        [TestMethod]
        public void OptionNames()
        {

            var r = new Random();
            var options = new WebChatStyleOptions();
            if (true)
            {
                var cc = new ChatColorOptions()
                {
                    BackgroundColor = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    AccentColor = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    SubtleColor = EnumHelpers.GetRandomValue<KnownColor>().ToString()
                };
                var borderStyles = new string[]
                {
                "none", "dotted", "dashed",
                "solid", "double", "groove",
                "ridge", "inset", "outset"
                };

                var bb = new BubbleOptions(true)
                {
                    Background = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    TextColor = EnumHelpers.GetRandomValue<KnownColor>().ToString(),

                    BorderColor = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    BorderStyle = borderStyles[r.Next(0, borderStyles.Length)],
                    BorderRadius = new CSSLengthUnit(r.Next(0, 20), CSSUnit.Pixels),
                    BorderWidth = new CSSLengthUnit(r.Next(0, 5), CSSUnit.Pixels)
                };
                var ub = new BubbleOptions(false)
                {
                    Background = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    TextColor = EnumHelpers.GetRandomValue<KnownColor>().ToString(),

                    BorderColor = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    BorderStyle = borderStyles[r.Next(0, borderStyles.Length)],
                    BorderRadius = new CSSLengthUnit(r.Next(0, 20), CSSUnit.Pixels),
                    BorderWidth = new CSSLengthUnit(r.Next(0, 5), CSSUnit.Pixels)
                };
                var ab = new BubbleCommonOptions()
                {

                };

                InstalledFontCollection installedFontCollection = new InstalledFontCollection();

                // Get the array of FontFamily objects.
                var fontFamilies = installedFontCollection.Families;

                #region Local Functions
                List<string> GetRandomFontFamilyNames(FontFamily[] families, int count)
                {
                    var value = new List<String>();
                    for (int i = 0; i < count; i++)
                    {
                        var f = families[RandomHelper.GetRandom(0, families.Length)];
                        value.Add(f.Name);
                    }
                    return value;
                }

                AvatarOptions PopulateAvatarOptions(Random r, bool isBot)
                {
                    var ba = new AvatarOptions(isBot)
                    {
                        BackgroundColor = EnumHelpers.GetRandomValue<KnownColor>().ToString()
                    };
                    switch (r.Next(1, 4))
                    {
                        case 1:
                            ba.Image = "https://sharecarebot-qa.azurewebsites.net/img/loup-sharecare.svg";
                            break;
                        case 2:
                            ba.Image = "https://virtualworkfriendbotz7sw.blob.core.windows.net/images/BotInitials.png";
                            break;
                        default:
                            ba.Initials = "ABC";
                            break;
                    }
                    return ba;
                }

                #endregion

                var fo = new FontOptions
                {
                    Primary = GetRandomFontFamilyNames(fontFamilies, 3),
                    Monospace = GetRandomFontFamilyNames(fontFamilies, 3),
                    SmallPercentage = r.Next(5, 8) * 10
                };

                var ba = PopulateAvatarOptions(r, true);
                var ua = PopulateAvatarOptions(r, false);
                var aa = new AvatarCommonOptions
                {
                    BorderRadius = new CSSLengthUnit($"'{r.Next(5, 15) * 5}%'"),
                    Size = r.Next(25, 75),
                    Group = EnumHelpers.GetRandomValue<AvatarGroupSetting>()
                };

                var regular = r.Next(1, 4) * 5;
                var po = new PaddingOptions
                {
                    Regular = regular,
                    Wide = regular * 2,
                };

                var co = new CommonOptions
                {
                    WordBreak = EnumHelpers.GetRandomValue<WordBreakSetting>(),
                    MarkdownCRLF = (r.NextDouble() <= .75),
                    RichCardWrapTitle = (r.NextDouble() >= .75)
                };
                var ro = new RootOptions
                {
                    Height = new CSSLengthUnit
                    {
                        Units = r.Next(25, 100),
                        //84, //r.Next(640, 800),
                        UnitCategory = CSSUnit.ViewportHeight // CSSUnit.Pixels
                    }
                    ,
                    Width = new CSSLengthUnit
                    {
                        Units = r.Next(25, 33),
                        UnitCategory = CSSUnit.ViewportWidth
                    }
                    ,
                    ZIndex = 0
                };

                var sbo = new SendBoxOptions
                {
                    Hide = false,
                    HideUploadButton = false,
                    MicrophoneColor = EnumHelpers.GetRandomValue<KnownColor>().ToString(),

                    BackgroundColor = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    TextColor = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    TextColorDisabled = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    PlaceholderColor = EnumHelpers.GetRandomValue<KnownColor>().ToString(),

                    Height = 40,
                    HeightMax = 200,
                    TextWrap = true,

                    ButtonColor = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    ButtonColorDisabled = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    ButtonColorFocus = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                    ButtonColorHover = EnumHelpers.GetRandomValue<KnownColor>().ToString(),

                    BorderBottom = new CSSBorder(),
                    BorderTop = new CSSBorder
                    {
                        Color = EnumHelpers.GetRandomValue<KnownColor>().ToString(),
                        Style = EnumHelpers.GetRandomValue<CSSBorderStyle>(),
                        UnitCategory = EnumHelpers.GetRandomValue<CSSUnit>((v) =>
                        {
                            var u = EnumHelpers.GetCustomAttribute<CSSUnitTypeAttribute, CSSUnit>(v);
                            return u.Category == CSSUnitCategory.Absolute;
                        }),
                        Units = r.Next(0, 3)
                    },
                    BorderLeft = new CSSBorder(),
                    BorderRight = new CSSBorder()

                };

                var saoe = new SuggestedActionsOptions(false)
                {

                };
                var saod = new SuggestedActionsOptions(true)
                {

                };
                var saco = new SuggestedActionsCommonOptions();

                var oTimestamp = new TimestampOptions();
                var oToast = new ToastOptions();
                var oTranscriptColor = new TranscriptOptions();
                var oTranscriptBackground = new TranscriptOptions(true);
                var oConnectivity = new ConnectivityOptions();

                var oSpinner = new SpinnerAnimationOptions();
                var oTyping = new TypingAnimationOptions();
                var oUpload = new UploadThumbnailOptions();

                options.BotBubble = bb;
                options.UserBubble = ub;
                options.AllBubbles = ab;

                options.ChatColors = cc;
                options.Fonts = fo;

                options.BotAvatar = ba;
                options.UserAvatar = ua;
                options.AllAvatars = aa;

                options.Padding = po;
                options.Common = co;
                options.SendBox = sbo;
                options.Root = ro;

                options.EnabledSuggestedActions = saoe;
                options.DisabledSuggestedActions = saod;
                options.AllSuggestedActions = saco;

                options.Timestamp = oTimestamp;
                options.Toast = oToast;

                options.TranscriptBackground = oTranscriptBackground;
                options.TranscriptColor = oTranscriptColor;

                options.Connectivity = oConnectivity;

                options.SpinnerAnimation = oSpinner;
                options.TypingAnimation = oTyping;
                options.UploadThumbnail = oUpload;
            }

            var so = StylingOption.GetOptionNames(options);
            var p = GetRelativeFileName("OptionNames.txt");
            var expected = File.ReadAllLines(p).ToList();
            var missing = expected.Except(so).ToList();
            var missingNames = String.Empty;
            if (missing.Count > 0)
            {
                missingNames = String.Join(',', missing);
            }
            Assert.AreEqual(0, missing.Count, $"{missing.Count} name(s) are missing from WebChatOptions\n{missingNames}");
        }
    }
}