using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class TypingAnimationOptionsTests : OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "typingAnimationBackgroundImage" ,
                "typingAnimationDuration" ,
                "typingAnimationHeight" ,
                "typingAnimationWidth" ,
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new TypingAnimationOptions
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
            var s = new TypingAnimationOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        //TypingAnimationOptions

        #region BackgroundImage Tests
        [TestMethod()]
        public void BackgroundImageDefault()
        {
            var propertyIndex = 0;
            var expectedValue = TypingAnimationOptions.Defaults.BackgroundImage;
            var src = new TypingAnimationOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundImageCustom()
        {
            var propertyIndex = 0;
            var expectedValue = "x.jpg";

            var src = new TypingAnimationOptions { BackgroundImage = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Duration Tests
        [TestMethod()]
        public void DurationDefault()
        {
            var propertyIndex = 1;
            var expectedValue = TypingAnimationOptions.Defaults.Duration;
            var src = new TypingAnimationOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void DurationCustom()
        {
            var propertyIndex = 1;
            var expectedValue = 500;

            var src = new TypingAnimationOptions { Duration = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Height Tests
        [TestMethod()]
        public void HeightDefault()
        {
            var propertyIndex = 2;
            var expectedValue = TypingAnimationOptions.Defaults.Height;
            var src = new TypingAnimationOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void HeightCustom()
        {
            var propertyIndex = 2;
            var expectedValue = 50;

            var src = new TypingAnimationOptions { Height = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Width Tests
        [TestMethod()]
        public void WidthDefault()
        {
            var propertyIndex = 3;
            var expectedValue = TypingAnimationOptions.Defaults.Width;
            var src = new TypingAnimationOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void WidthCustom()
        {
            var propertyIndex = 3;
            var expectedValue = 100;

            var src = new TypingAnimationOptions { Width = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

    }
}