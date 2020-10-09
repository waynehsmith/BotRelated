using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Bot.Builder.Community.Helpers;
using System.Drawing;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class ChatColorOptionsTests : OptionsTests
    {
        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "backgroundColor",
                "accent",
                "subtle",
                "cardEmphasisBackgroundColor",
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new ChatColorOptions
            {
            };

            var so = PopulateOptions(src);
            Assert.AreEqual(0, so.Count);

            so = PopulateOptions(src, true);
            Assert.AreEqual(4, so.Count);

        }

        [TestMethod]
        public void OptionNames()
        {
            var s = new ChatColorOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }


        #region BackgroundColor Tests
        [TestMethod()]
        public void BackgroundColorDefault()
        {
            var propertyIndex = 0;
            var expectedValue = ChatColorOptions.Defaults.BackgroundColor;
            var src = new ChatColorOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundColorCustom()
        {
            var propertyIndex = 0;
            var expectedValue = EnumHelpers.GetRandomValue<KnownColor>().ToString();

            var src = new ChatColorOptions { BackgroundColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region AccentColor Tests
        [TestMethod()]
        public void AccentColorDefault()
        {
            var propertyIndex = 1;
            var expectedValue = ChatColorOptions.Defaults.AccentColor;
            var src = new ChatColorOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void AccentColorCustom()
        {
            var propertyIndex = 1;
            var expectedValue = EnumHelpers.GetRandomValue<KnownColor>().ToString();

            var src = new ChatColorOptions { AccentColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region SubtleColor Tests
        [TestMethod()]
        public void SubtleColorDefault()
        {
            var propertyIndex = 2;
            var expectedValue = ChatColorOptions.Defaults.SubtleColor;
            var src = new ChatColorOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void SubtleColorCustom()
        {
            var propertyIndex = 2;
            var expectedValue = EnumHelpers.GetRandomValue<KnownColor>().ToString();

            var src = new ChatColorOptions { SubtleColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region CardEmphasisBackgroundColor Tests
        [TestMethod()]
        public void CardEmphasisBackgroundColorDefault()
        {
            var propertyIndex = 3;
            var expectedValue = ChatColorOptions.Defaults.CardEmphasisBackgroundColor;
            var src = new ChatColorOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void CardEmphasisBackgroundColorCustom()
        {
            var propertyIndex = 3;
            var expectedValue = EnumHelpers.GetRandomValue<KnownColor>().ToString();

            var src = new ChatColorOptions { CardEmphasisBackgroundColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
    }
}