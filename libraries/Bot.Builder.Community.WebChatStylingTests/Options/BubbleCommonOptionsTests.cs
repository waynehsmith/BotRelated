using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class BubbleCommonOptionsTests : OptionsTests
    {
        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "bubbleImageHeight",
                "bubbleMaxWidth",
                "bubbleMinHeight",
                "bubbleMinWidth",
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var aco = new BubbleCommonOptions
            {
            };

            var o = PopulateOptions(aco);
            Assert.AreEqual(0, o.Count);

            o = PopulateOptions(aco, true);
            Assert.AreEqual(4, o.Count);

        }


        #region ImageHeight Tests
        [TestMethod()]
        public void ImageHeightDefault()
        {
            var propertyIndex = 0;
            var expectedValue = 240;
            var src = new BubbleCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ImageHeightCustom()
        {
            var propertyIndex = 0;
            var expectedValue = r.Next(40,100);

            var src = new BubbleCommonOptions { ImageHeight = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region MaxWidth Tests
        [TestMethod()]
        public void MaxWidthDefault()
        {
            var propertyIndex = 1;
            var expectedValue = 480;
            var src = new BubbleCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void MaxWidthCustom()
        {
            var propertyIndex = 1;
            var expectedValue = r.Next(40, 100);

            var src = new BubbleCommonOptions { MaxWidth = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region MinHeight Tests
        [TestMethod()]
        public void MinHeightDefault()
        {
            var propertyIndex = 2;
            var expectedValue = 40;
            var src = new BubbleCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void MinHeightCustom()
        {
            var propertyIndex = 2;
            var expectedValue = r.Next(10, 40);

            var src = new BubbleCommonOptions { MinHeight = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region MinWidth Tests
        [TestMethod()]
        public void MinWidthDefault()
        {
            var propertyIndex = 3;
            var expectedValue = 250;
            var src = new BubbleCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void MinWidthCustom()
        {
            var propertyIndex = 3;
            var expectedValue = r.Next(40, 100);

            var src = new BubbleCommonOptions { MinWidth = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
    }
}