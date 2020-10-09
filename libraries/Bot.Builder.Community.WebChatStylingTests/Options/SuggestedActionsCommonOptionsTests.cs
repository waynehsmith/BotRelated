using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Bot.Builder.Community.Helpers;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class SuggestedActionsCommonOptionsTests : OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "suggestedActionHeight",
                "suggestedActionImageHeight",
                "suggestedActionLayout", 
                "suggestedActionsStackedHeight",
                "suggestedActionsStackedOverflow" ,

                "suggestedActionsCarouselFlipperCursor" ,
                "suggestedActionsCarouselFlipperBoxWidth" ,
                "suggestedActionsCarouselFlipperSize" ,
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new SuggestedActionsCommonOptions
            {
            };

            var so = PopulateOptions(src);
            Assert.AreEqual(0, so.Count);

            so = PopulateOptions(src, true);
            Assert.AreEqual(8, so.Count);

        }

        [TestMethod]
        public void OptionNames()
        {
            var s = new SuggestedActionsCommonOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }
        
        //SuggestedActionsCommonOptions

        #region Height Tests
        [TestMethod()]
        public void HeightDefault()
        {
            var propertyIndex = 0;
            var expectedValue = SuggestedActionsCommonOptions.Defaults.Height;
            var src = new SuggestedActionsCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void HeightCustom()
        {
            var propertyIndex = 0;
            var expectedValue = r.Next(0, 50, SuggestedActionsCommonOptions.Defaults.Height);

            var src = new SuggestedActionsCommonOptions { Height = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region ImageHeight Tests
        [TestMethod()]
        public void ImageHeightDefault()
        {
            var propertyIndex = 1;
            var expectedValue = SuggestedActionsCommonOptions.Defaults.ImageHeight;
            var src = new SuggestedActionsCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ImageHeightCustom()
        {
            var propertyIndex = 1;
            var expectedValue = r.Next(0, 50, SuggestedActionsCommonOptions.Defaults.ImageHeight);

            var src = new SuggestedActionsCommonOptions { ImageHeight = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Layout Tests
        [TestMethod()]
        public void LayoutDefault()
        {
            var propertyIndex = 2;
            var expectedValue = SuggestedActionsCommonOptions.Defaults.Layout;
            var src = new SuggestedActionsCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void LayoutCustom()
        {
            var propertyIndex = 2;
            var expectedValue = EnumHelpers.GetRandomValue<SuggestedActionLayoutSetting>(
                SuggestedActionsCommonOptions.Defaults.Layout);

            var src = new SuggestedActionsCommonOptions { Layout = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region StackedHeight Tests
        [TestMethod()]
        public void StackedHeightDefault()
        {
            var propertyIndex = 3;
            var expectedValue = SuggestedActionsCommonOptions.Defaults.StackedHeight;
            var src = new SuggestedActionsCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void StackedHeightCustom()
        {
            var propertyIndex = 3;
            var expectedValue = "auto";

            var src = new SuggestedActionsCommonOptions { StackedHeight = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region StackedOverflow Tests
        [TestMethod()]
        public void StackedOverflowDefault()
        {
            var propertyIndex = 4;
            var expectedValue = SuggestedActionsCommonOptions.Defaults.StackedOverflow;
            var src = new SuggestedActionsCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void StackedOverflowCustom()
        {
            var propertyIndex = 4;
            var expectedValue = "auto";

            var src = new SuggestedActionsCommonOptions { StackedOverflow = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region CarouselCursor Tests
        [TestMethod()]
        public void CarouselCursorDefault()
        {
            var propertyIndex = 5;
            var expectedValue = SuggestedActionsCommonOptions.Defaults.CarouselCursor;
            var src = new SuggestedActionsCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void CarouselCursorCustom()
        {
            var propertyIndex = 5;
            var expectedValue = "hand";

            var src = new SuggestedActionsCommonOptions { CarouselCursor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region CarouselWidth Tests
        [TestMethod()]
        public void CarouselWidthDefault()
        {
            var propertyIndex = 6;
            var expectedValue = SuggestedActionsCommonOptions.Defaults.CarouselWidth;
            var src = new SuggestedActionsCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void CarouselWidthCustom()
        {
            var propertyIndex = 6;
            var expectedValue = 10;

            var src = new SuggestedActionsCommonOptions { CarouselWidth = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region CarouselSize Tests
        [TestMethod()]
        public void CarouselSizeDefault()
        {
            var propertyIndex = 7;
            var expectedValue = SuggestedActionsCommonOptions.Defaults.CarouselSize;
            var src = new SuggestedActionsCommonOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void CarouselSizeCustom()
        {
            var propertyIndex = 7;
            var expectedValue = 40;

            var src = new SuggestedActionsCommonOptions { CarouselSize = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
    }
}