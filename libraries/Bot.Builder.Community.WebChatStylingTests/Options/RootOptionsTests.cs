using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Bot.Builder.Community.Helpers;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class RootOptionsTests : OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "rootHeight",
                "rootWidth",
                "rootZIndex"
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new RootOptions
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
            var s = new RootOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        #region Height Tests
        [TestMethod()]
        public void HeightDefault()
        {
            var propertyIndex = 0;
            var expectedValue = RootOptions.Defaults.Height;
            var src = new RootOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue.ToString());
        }

        [TestMethod()]
        public void HeightCustom()
        {
            var propertyIndex = 0;
            var expectedValue = new CSSLengthUnit(r.Next(1,99), CSSUnit.Percent);

            var src = new RootOptions { Height = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue.ToString());
        }
        #endregion

        #region Width Tests
        [TestMethod()]
        public void WidthDefault()
        {
            var propertyIndex = 1;
            var expectedValue = RootOptions.Defaults.Width;
            var src = new RootOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue.ToString());
        }

        [TestMethod()]
        public void WidthCustom()
        {
            var propertyIndex = 1;
            var expectedValue = new CSSLengthUnit(r.Next(1, 99), CSSUnit.Percent); 

            var src = new RootOptions { Width = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue.ToString());
        }
        #endregion

        #region ZIndex Tests
        [TestMethod()]
        public void ZIndexDefault()
        {
            var propertyIndex = 2;
            var expectedValue = RootOptions.Defaults.ZIndex;
            var src = new RootOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ZIndexCustom()
        {
            var propertyIndex = 2;
            var expectedValue = r.Next(-10, 10, 0);

            var src = new RootOptions { ZIndex = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
    }
}