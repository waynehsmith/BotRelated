using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Bot.Builder.Community.Helpers;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class PaddingOptionsTests : OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "paddingRegular",
                "paddingWide",
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new PaddingOptions
            {
            };

            var so = PopulateOptions(src);
            Assert.AreEqual(0, so.Count);

            so = PopulateOptions(src, true);
            Assert.AreEqual(2, so.Count);

        }

        [TestMethod]
        public void OptionNames()
        {
            var s = new PaddingOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }


        #region Regular Tests
        [TestMethod()]
        public void RegularDefault()
        {
            var propertyIndex = 0;
            var expectedValue = PaddingOptions.Defaults.Regular;
            var src = new PaddingOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void RegularCustom()
        {
            var propertyIndex = 0;
            var expectedValue = r.Next(1, 100, PaddingOptions.Defaults.Regular);

            var src = new PaddingOptions { Regular = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Wide Tests
        [TestMethod()]
        public void WideDefault()
        {
            var propertyIndex = 1;
            var expectedValue = PaddingOptions.Defaults.Wide;
            var src = new PaddingOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void WideCustom()
        {
            var propertyIndex = 1;
            var expectedValue = r.Next(1,100, PaddingOptions.Defaults.Wide);

            var src = new PaddingOptions { Wide = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
    }
}