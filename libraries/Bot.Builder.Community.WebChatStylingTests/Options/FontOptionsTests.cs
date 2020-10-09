using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Drawing;
using Bot.Builder.Community.Helpers;
using System.Drawing.Text;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class FontOptionsTests : OptionsTests
    {
        private FontFamily[] fontFamilies;


        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "primaryFont",
                "monospaceFont",
                "fontSizeSmall",
            });
            // Get the array of FontFamily objects.
            fontFamilies = (new InstalledFontCollection()).Families;
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new FontOptions
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
            var s = new FontOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }


        private List<string> GetRandomFontFamilyNames(FontFamily[] families, int count)
        {
            var value = new List<String>();
            for (int i = 0; i < count; i++)
            {
                var f = families[RandomHelper.GetRandom(0, families.Length)];
                value.Add(f.Name);
            }
            return value;
        }

        #region Primary Tests
        [TestMethod()]
        public void PrimaryDefault()
        {
            var propertyIndex = 0;
            var expectedValue = FontOptions.Defaults.Primary;
            var src = new FontOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, 
                CreateStringList(expectedValue, ListStylingAttribute. DefaultDelimiter));
        }

       

        [TestMethod()]
        public void PrimaryCustom()
        {
            var propertyIndex = 0;
            var expectedValue = GetRandomFontFamilyNames(fontFamilies, 3);

            var src = new FontOptions { Primary = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex,
                CreateStringList(expectedValue, ListStylingAttribute.DefaultDelimiter));
        }
        #endregion

        #region Monospace Tests
        [TestMethod()]
        public void MonospaceDefault()
        {
            var propertyIndex = 1;
            var expectedValue = FontOptions.Defaults.Monospace;
            var src = new FontOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex,
                CreateStringList(expectedValue, ListStylingAttribute.DefaultDelimiter));
        }

        [TestMethod()]
        public void MonospaceCustom()
        {
            var propertyIndex = 1;
            var expectedValue = GetRandomFontFamilyNames(fontFamilies, 3);

            var src = new FontOptions { Monospace = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex,
                CreateStringList(expectedValue, ListStylingAttribute.DefaultDelimiter));
        }
        #endregion

        #region SmallPercentage Tests
        [TestMethod()]
        public void SmallPercentageDefault()
        {
            var propertyIndex = 2;
            var expectedValue = FontOptions.Defaults.SmallPercentage;
            var src = new FontOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, CreatePercentageValue(expectedValue));
        }

        [TestMethod()]
        public void SmallPercentageCustom()
        {
            var propertyIndex = 2;
            var expectedValue = r.Next(5, 8) * 10;

            var src = new FontOptions { SmallPercentage = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, CreatePercentageValue( expectedValue));
        }
        #endregion
    }
}