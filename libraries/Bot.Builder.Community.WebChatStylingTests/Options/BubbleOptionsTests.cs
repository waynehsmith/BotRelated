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
    public class BubbleOptionsTests : OptionsTests
    {
        private readonly string[] borderStyles = new string[]
        {
                "none", "dotted", "dashed",
                "solid", "double", "groove",
                "ridge", "inset", "outset"
        };

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "bubbleFromUserBackground",
                "bubbleFromUserTextColor",
                "bubbleFromUserBorderColor",
                "bubbleFromUserBorderStyle",
                "bubbleFromUserBorderRadius",
                "bubbleFromUserBorderWidth",
                "bubbleFromUserNubOffset",
                "bubbleFromUserNubSize",

                "bubbleBackground",
                "bubbleTextColor",
                "bubbleBorderColor",
                "bubbleBorderStyle",
                "bubbleBorderRadius",
                "bubbleBorderWidth",
                "bubbleNubOffset",
                "bubbleNubSize",
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var aco = new BubbleOptions
            {
            };

            var o = PopulateOptions(aco);
            Assert.AreEqual(0, o.Count);

            o = PopulateOptions(aco, true);
            Assert.AreEqual(8, o.Count);

        }

        [TestMethod]
        public void OptionNames()
        {
            var s = new BubbleOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        #region Background Tests
        [TestMethod()]
        public void BackgroundDefault()
        {
            var propertyIndex = 0;
            var expectedValue = BubbleOptions.Defaults.Background;
            var src = new BubbleOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundCustom()
        {
            var propertyIndex = 0;
            var expectedValue = EnumHelpers.GetRandomValue<KnownColor>(KnownColor.White).ToString();

            var src = new BubbleOptions { Background = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region TextColor Tests
        [TestMethod()]
        public void TextColorDefault()
        {
            var propertyIndex = 1;
            var expectedValue = BubbleOptions.Defaults.TextColor;
            var src = new BubbleOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void TextColorCustom()
        {
            var propertyIndex = 1;
            var expectedValue = EnumHelpers.GetRandomValue<KnownColor>().ToString();

            var src = new BubbleOptions { TextColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderColor Tests
        [TestMethod()]
        public void BorderColorDefault()
        {
            var propertyIndex = 2;
            var expectedValue = BubbleOptions.Defaults.BorderColor;
            var src = new BubbleOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderColorCustom()
        {
            var propertyIndex = 2;
            var expectedValue = EnumHelpers.GetRandomValue<KnownColor>().ToString();

            var src = new BubbleOptions { BorderColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        
        #region BorderStyle Tests
        [TestMethod()]
        public void BorderStyleDefault()
        {
            var propertyIndex = 3;
            var expectedValue = BubbleOptions.Defaults.BorderStyle;
            var src = new BubbleOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderStyleCustom()
        {
            var propertyIndex = 3;
            var expectedValue = borderStyles[r.Next(0, borderStyles.Length, 3)];

            var src = new BubbleOptions { BorderStyle = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderRadius Tests
        [TestMethod()]
        public void BorderRadiusDefault()
        {
            var propertyIndex = 4;
            var expectedValue = BubbleOptions.Defaults.BorderRadius;
            var src = new BubbleOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderRadiusCustom()
        {
            var propertyIndex = 4;
            var expectedValue = new CSSLengthUnit(
                r.Next(0, 20, BubbleOptions.Defaults.BorderRadius.Units), 
                CSSUnit.Pixels);

            var src = new BubbleOptions { BorderRadius = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderWidth Tests
        [TestMethod()]
        public void BorderWidthDefault()
        {
            var propertyIndex = 5;
            var expectedValue = BubbleOptions.Defaults.BorderWidth;
            var src = new BubbleOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderWidthCustom()
        {
            var propertyIndex = 5;
            var expectedValue = new CSSLengthUnit(r.Next(0, 5, BubbleOptions.Defaults.BorderWidth.Units), CSSUnit.Pixels);

            var src = new BubbleOptions { BorderWidth = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region NubOffset Tests
        [TestMethod()]
        public void NubOffsetDefault()
        {
            var propertyIndex = 6;
            var expectedValue = BubbleOptions.Defaults.NubOffset;
            var src = new BubbleOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void NubOffsetCustom()
        {
            var propertyIndex = 6;
            var expectedValue = r.Next(-4, 4, BubbleOptions.Defaults.NubOffset);

            var src = new BubbleOptions { NubOffset = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region NubSize Tests
        [TestMethod()]
        public void NubSizeDefault()
        {
            var propertyIndex = 7;
            var expectedValue = BubbleOptions.Defaults.NubSize;
            var src = new BubbleOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void NubSizeCustom()
        {
            var propertyIndex = 7;
            var expectedValue = r.Next(-2, 2);

            var src = new BubbleOptions { NubSize = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
    }
}