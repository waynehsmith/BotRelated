using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Bot.Builder.Community.Helpers;
using Bot.Builder.Community.WebChatStyling;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass]
    public class ConnectivityOptionsTests : OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "connectivityIconPadding" ,
                "connectivityMarginLeftRight" ,
                "connectivityMarginTopBottom" ,
                "connectivityTextSize" ,
                "failedConnectivity" ,

                "slowConnectivity",
                "notificationText",
                "slowConnectionAfter" ,
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new ConnectivityOptions
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
            var s = new ConnectivityOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        #region IconPadding Tests
        [TestMethod()]
        public void IconPaddingDefault()
        {
            var propertyIndex = 0;
            var expectedValue = ConnectivityOptions.Defaults.IconPadding;
            var src = new ConnectivityOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void IconPaddingCustom()
        {
            var propertyIndex = 0;
            var expectedValue = 11.0;

            var src = new ConnectivityOptions { IconPadding = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region MarginHorizontal Tests
        [TestMethod()]
        public void MarginHorizontalDefault()
        {
            var propertyIndex = 1;
            var expectedValue = ConnectivityOptions.Defaults.MarginHorizontal;
            var src = new ConnectivityOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void MarginHorizontalCustom()
        {
            var propertyIndex = 1;
            var expectedValue = 13.0;

            var src = new ConnectivityOptions { MarginHorizontal = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region MarginVertical Tests
        [TestMethod()]
        public void MarginVerticalDefault()
        {
            var propertyIndex = 2;
            var expectedValue = ConnectivityOptions.Defaults.MarginVertical;
            var src = new ConnectivityOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void MarginVerticalCustom()
        {
            var propertyIndex = 2;
            var expectedValue = 9.0;

            var src = new ConnectivityOptions { MarginVertical = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region TextSize Tests
        [TestMethod()]
        public void TextSizeDefault()
        {
            var propertyIndex = 3;
            var expectedValue = ConnectivityOptions.Defaults.TextSize;
            var src = new ConnectivityOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, CreatePercentageValue( expectedValue));
        }

        [TestMethod()]
        public void TextSizeCustom()
        {
            var propertyIndex = 3;
            var expectedValue = 25;

            var src = new ConnectivityOptions { TextSize = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, CreatePercentageValue(expectedValue));
        }
        #endregion

        #region Failed Tests
        [TestMethod()]
        public void FailedDefault()
        {
            var propertyIndex = 4;
            var expectedValue = ConnectivityOptions.Defaults.Failed;
            var src = new ConnectivityOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void FailedCustom()
        {
            var propertyIndex = 4;
            var expectedValue = CreateColor();

            var src = new ConnectivityOptions { Failed = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Slow Tests
        [TestMethod()]
        public void SlowDefault()
        {
            var propertyIndex = 5;
            var expectedValue = ConnectivityOptions.Defaults.Slow;
            var src = new ConnectivityOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void SlowCustom()
        {
            var propertyIndex = 5;
            var expectedValue = CreateColor();

            var src = new ConnectivityOptions { Slow = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region NotificationText Tests
        [TestMethod()]
        public void NotificationTextDefault()
        {
            var propertyIndex = 6;
            var expectedValue = ConnectivityOptions.Defaults.NotificationText;
            var src = new ConnectivityOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void NotificationTextCustom()
        {
            var propertyIndex = 6;
            var expectedValue = CreateColor();

            var src = new ConnectivityOptions { NotificationText = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region SlowAfter Tests
        [TestMethod()]
        public void SlowAfterDefault()
        {
            var propertyIndex = 7;
            var expectedValue = ConnectivityOptions.Defaults.SlowAfter;
            var src = new ConnectivityOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void SlowAfterCustom()
        {
            var propertyIndex = 7;
            var expectedValue = 1000;

            var src = new ConnectivityOptions { SlowAfter = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
    }
}
