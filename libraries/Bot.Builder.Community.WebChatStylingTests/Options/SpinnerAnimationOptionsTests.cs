using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class SpinnerAnimationOptionsTests: OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "spinnerAnimationBackgroundImage",
                "spinnerAnimationHeight",
                "spinnerAnimationWidth" ,
                "spinnerAnimationPadding" ,
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new SpinnerAnimationOptions
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
            var s = new SpinnerAnimationOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        //SpinnerAnimationOptions

        #region BackgroundImage Tests
        [TestMethod()]
        public void BackgroundImageDefault()
        {
            var propertyIndex = 0;
            var expectedValue = SpinnerAnimationOptions.Defaults.BackgroundImage;
            var src = new SpinnerAnimationOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundImageCustom()
        {
            var propertyIndex = 0;
            var expectedValue = "a.png";

            var src = new SpinnerAnimationOptions { BackgroundImage = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Height Tests
        [TestMethod()]
        public void HeightDefault()
        {
            var propertyIndex = 1;
            var expectedValue = SpinnerAnimationOptions.Defaults.Height;
            var src = new SpinnerAnimationOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void HeightCustom()
        {
            var propertyIndex = 1;
            var expectedValue = 10;

            var src = new SpinnerAnimationOptions { Height = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion


        #region Width Tests
        [TestMethod()]
        public void WidthDefault()
        {
            var propertyIndex = 2;
            var expectedValue = SpinnerAnimationOptions.Defaults.Width;
            var src = new SpinnerAnimationOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void WidthCustom()
        {
            var propertyIndex = 2;
            var expectedValue = 50;

            var src = new SpinnerAnimationOptions { Width = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Padding Tests
        [TestMethod()]
        public void PaddingDefault()
        {
            var propertyIndex = 3;
            var expectedValue = SpinnerAnimationOptions.Defaults.Padding;
            var src = new SpinnerAnimationOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void PaddingCustom()
        {
            var propertyIndex = 3;
            var expectedValue = 80;

            var src = new SpinnerAnimationOptions { Padding = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
    }
}