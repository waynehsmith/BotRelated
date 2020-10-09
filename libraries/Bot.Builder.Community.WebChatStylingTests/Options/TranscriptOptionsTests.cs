using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class TranscriptOptionsTests : OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "transcriptOverlayButtonColor" ,
                "transcriptOverlayButtonColorOnFocus" , // defaults to transcriptOverlayButtonColor
                "transcriptOverlayButtonColorOnHover" ,

                "transcriptOverlayButtonBackground" ,
                "transcriptOverlayButtonBackgroundOnFocus" ,
                "transcriptOverlayButtonBackgroundOnHover" ,
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new TranscriptOptions
            {
            };

            var so = PopulateOptions(src);
            Assert.AreEqual(0, so.Count);

            so = PopulateOptions(src, true);
            Assert.AreEqual(3, so.Count);

        }

        [TestMethod]
        public void OptionNames()
        {
            var s = new TranscriptOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        #region Color Tests
        [TestMethod()]
        public void ColorDefault()
        {
            var propertyIndex = 0;
            var expectedValue = TranscriptOptions.Defaults.Color;
            var src = new TranscriptOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ColorCustom()
        {
            var propertyIndex = 0;
            var expectedValue = CreateColor(KnownColor.White);

            var src = new TranscriptOptions { Color = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region ColorFocus Tests
        [TestMethod()]
        public void ColorFocusDefault()
        {
            var propertyIndex = 1;
            var expectedValue = TranscriptOptions.Defaults.ColorFocus;
            var src = new TranscriptOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ColorFocusCustom()
        {
            var propertyIndex = 1;
            var expectedValue = CreateColor();

            var src = new TranscriptOptions { ColorFocus = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region ColorHover Tests
        [TestMethod()]
        public void ColorHoverDefault()
        {
            var propertyIndex = 2;
            var expectedValue = TranscriptOptions.Defaults.ColorHover;
            var src = new TranscriptOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ColorHoverCustom()
        {
            var propertyIndex = 2;
            var expectedValue = CreateColor();

            var src = new TranscriptOptions { ColorHover = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion


        #region BackgroundColor Tests
        [TestMethod()]
        public void BackgroundDefault()
        {
            var propertyIndex = 3;
            var expectedValue = TranscriptOptions.DefaultsBackground.Color;
            var src = new TranscriptOptions(true) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundCustom()
        {
            var propertyIndex = 3;
            var expectedValue = CreateColor();

            var src = new TranscriptOptions(true) { Color = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BackgroundFocus Tests
        [TestMethod()]
        public void BackgroundFocusDefault()
        {
            var propertyIndex = 4;
            var expectedValue = TranscriptOptions.DefaultsBackground.ColorFocus;
            var src = new TranscriptOptions(true) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundFocusCustom()
        {
            var propertyIndex = 4;
            var expectedValue = CreateColor();

            var src = new TranscriptOptions(true) { ColorFocus = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BackgroundHover Tests
        [TestMethod()]
        public void BackgroundHoverDefault()
        {
            var propertyIndex = 5;
            var expectedValue = TranscriptOptions.DefaultsBackground.ColorHover;
            var src = new TranscriptOptions(true) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundHoverCustom()
        {
            var propertyIndex = 5;
            var expectedValue = CreateColor();

            var src = new TranscriptOptions(true) { ColorHover = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
    }
}