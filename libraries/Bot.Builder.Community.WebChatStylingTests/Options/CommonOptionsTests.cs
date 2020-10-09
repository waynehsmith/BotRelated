using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Bot.Builder.Community.Helpers;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class CommonOptionsTests : OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "messageActivityWordBreak",
                "markdownRespectCRLF",
                "richCardWrapTitle",
                "hideScrollToEndButton",
                "showSpokenText",
                "newMessagesButtonFontSize",      
                "videoHeight" ,
                "notificationDebounceTimeout",
                "emojiSet"
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new CommonOptions
            {
            };

            var so = PopulateOptions(src);
            Assert.AreEqual(0, so.Count);

            so = PopulateOptions(src, true);
            Assert.AreEqual(9, so.Count);

        }

        [TestMethod]
        public void OptionNames()
        {
            var s = new CommonOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        #region WordBreak Tests
        [TestMethod()]
        public void WordBreakDefault()
        {
            var propertyIndex = 0;
            var expectedValue = CommonOptions.Defaults.WordBreak;
            var src = new CommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void WordBreakCustom()
        {
            var propertyIndex = 0;
            var expectedValue = EnumHelpers.GetRandomValue<WordBreakSetting>(CommonOptions.Defaults.WordBreak);

            var src = new CommonOptions { WordBreak = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region MarkdownCRLF Tests
        [TestMethod()]
        public void MarkdownCRLFDefault()
        {
            var propertyIndex = 1;
            var expectedValue = CommonOptions.Defaults.MarkdownCRLF;
            var src = new CommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void MarkdownCRLFCustom()
        {
            var propertyIndex = 1;
            var expectedValue = false;

            var src = new CommonOptions { MarkdownCRLF = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region RichCardWrapTitle Tests
        [TestMethod()]
        public void RichCardWrapTitleDefault()
        {
            var propertyIndex = 2;
            var expectedValue = CommonOptions.Defaults.RichCardWrapTitle;
            var src = new CommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void RichCardWrapTitleCustom()
        {
            var propertyIndex = 2;
            var expectedValue = true;

            var src = new CommonOptions { RichCardWrapTitle = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region HideScrollToEndButton Tests
        [TestMethod()]
        public void HideScrollToEndButtonDefault()
        {
            var propertyIndex = 3;
            var expectedValue = CommonOptions.Defaults.HideScrollToEndButton;
            var src = new CommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void HideScrollToEndButtonCustom()
        {
            var propertyIndex = 3;
            var expectedValue = true;

            var src = new CommonOptions { HideScrollToEndButton = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region ShowSpokenText Tests
        [TestMethod()]
        public void ShowSpokenTextDefault()
        {
            var propertyIndex = 4;
            var expectedValue = CommonOptions.Defaults.ShowSpokenText;
            var src = new CommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ShowSpokenTextCustom()
        {
            var propertyIndex = 4;
            var expectedValue = true;

            var src = new CommonOptions { ShowSpokenText = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region GeneralFontSize Tests
        [TestMethod()]
        public void GeneralFontSizeDefault()
        {
            var propertyIndex = 5;
            var expectedValue = CommonOptions.Defaults.GeneralFontSize;
            var src = new CommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, CreatePercentageValue(expectedValue));
        }

        [TestMethod()]
        public void GeneralFontSizeCustom()
        {
            var propertyIndex = 5;
            var expectedValue = r.Next(50, 100, CommonOptions.Defaults.GeneralFontSize);

            var src = new CommonOptions { GeneralFontSize = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, CreatePercentageValue(expectedValue));
        }
        #endregion

        #region VideoHeight Tests
        [TestMethod()]
        public void VideoHeightDefault()
        {
            var propertyIndex = 6;
            var expectedValue = CommonOptions.Defaults.VideoHeight;
            var src = new CommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void VideoHeightCustom()
        {
            var propertyIndex = 6;
            var expectedValue = 220;

            var src = new CommonOptions { VideoHeight = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region NotificationDebounceTimeout Tests
        [TestMethod()]
        public void NotificationDebounceTimeoutDefault()
        {
            var propertyIndex = 7;
            var expectedValue = CommonOptions.Defaults.NotificationDebounceTimeout;
            var src = new CommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void NotificationDebounceTimeoutCustom()
        {
            var propertyIndex = 7;
            var expectedValue = 300;

            var src = new CommonOptions { NotificationDebounceTimeout = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region UseEmojis Tests
        [TestMethod()]
        public void UseEmojisDefault()
        {
            var propertyIndex = 8;
            var expectedValue = CommonOptions.Defaults.UseEmojis;
            var src = new CommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void UseEmojisCustom()
        {
            var propertyIndex = 8;
            var expectedValue = false;

            var src = new CommonOptions { UseEmojis = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

    }
}