using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Bot.Builder.Community.Helpers;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class SuggestedActionsOptionsTests: OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "suggestedActionBackground" ,
                "suggestedActionBorderColor" ,
                "suggestedActionBorderRadius" ,
                "suggestedActionBorderStyle" ,
                "suggestedActionBorderWidth" ,

                "suggestedActionTextColor" ,
                "suggestedActionDisabledBackground" ,
                "suggestedActionDisabledBorderColor" ,
                "suggestedActionDisabledBorderRadius" ,
                "suggestedActionDisabledBorderStyle" ,

                "suggestedActionDisabledBorderWidth" ,
                "suggestedActionDisabledTextColor" ,
                "suggestedActionBorder" ,
                "suggestedActionDisabledBorder" , 
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new SuggestedActionsOptions
            {
            };

            var so = PopulateOptions(src);
            Assert.AreEqual(0, so.Count);

            so = PopulateOptions(src, true);
            Assert.AreEqual(7, so.Count);

        }

        [TestMethod]
        public void OptionNames()
        {
            var s = new SuggestedActionsOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        //SuggestedActionsOptions
        #region Background Tests
        [TestMethod()]
        public void BackgroundDefault()
        {
            var propertyIndex = 0;
            var expectedValue = SuggestedActionsOptions.Defaults.Background;
            var src = new SuggestedActionsOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundCustom()
        {
            var propertyIndex = 0;
            var expectedValue = CreateColor();

            var src = new SuggestedActionsOptions { Background = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Border Tests
        [TestMethod()]
        public void BorderDefault()
        {
            var propertyIndex = 12;
            var expectedValue = SuggestedActionsOptions.Defaults.Border;
            var src = new SuggestedActionsOptions(false) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue?.CSSText);
        }

        [TestMethod()]
        public void BorderCustom()
        {
            var propertyIndex = 12;
            var expectedValue = new CSSBorder("solid 1px violet");

            var src = new SuggestedActionsOptions(false) { Border = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue?.CSSText);
        }
        #endregion

        #region BorderColor Tests
        [TestMethod()]
        public void BorderColorDefault()
        {
            var propertyIndex = 1;
            var expectedValue = SuggestedActionsOptions.Defaults.BorderColor;
            var src = new SuggestedActionsOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderColorCustom()
        {
            var propertyIndex = 1;
            var expectedValue = CreateColor();

            var src = new SuggestedActionsOptions { BorderColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderRadius Tests
        [TestMethod()]
        public void BorderRadiusDefault()
        {
            var propertyIndex = 2;
            var expectedValue = SuggestedActionsOptions.Defaults.BorderRadius;
            var src = new SuggestedActionsOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderRadiusCustom()
        {
            var propertyIndex = 2;
            var expectedValue = new CSSLengthUnit(r.Next(10, 24), CSSUnit.Points); ;

            var src = new SuggestedActionsOptions { BorderRadius = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderStyle Tests
        [TestMethod()]
        public void BorderStyleDefault()
        {
            var propertyIndex = 3;
            var expectedValue = SuggestedActionsOptions.Defaults.BorderStyle;
            var src = new SuggestedActionsOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderStyleCustom()
        {
            var propertyIndex = 3;
            var expectedValue = EnumHelpers.GetRandomValue<CSSBorderStyle>(SuggestedActionsOptions.Defaults.BorderStyle);

            var src = new SuggestedActionsOptions { BorderStyle = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderWidth Tests
        [TestMethod()]
        public void BorderWidthDefault()
        {
            var propertyIndex = 4;
            var expectedValue = SuggestedActionsOptions.Defaults.BorderWidth;
            var src = new SuggestedActionsOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderWidthCustom()
        {
            var propertyIndex = 4;
            var expectedValue = new CSSLengthUnit(r.Next(10,24),CSSUnit.Points);

            var src = new SuggestedActionsOptions { BorderWidth = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue.ToString());
        }
        #endregion

        #region TextColor Tests
        [TestMethod()]
        public void TextColorDefault()
        {
            var propertyIndex = 5;
            var expectedValue = SuggestedActionsOptions.Defaults.TextColor;
            var src = new SuggestedActionsOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void TextColorCustom()
        {
            var propertyIndex = 5;
            var expectedValue = CreateColor();

            var src = new SuggestedActionsOptions { TextColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion


        #region Background Tests
        [TestMethod()]
        public void BackgroundDisabledDefault()
        {
            var propertyIndex = 6;
            var expectedValue = SuggestedActionsOptions.DefaultsDisabled.Background;
            var src = new SuggestedActionsOptions(true) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundDisabledCustom()
        {
            var propertyIndex = 6;
            var expectedValue = CreateColor();

            var src = new SuggestedActionsOptions(true) { Background = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Border Tests
        [TestMethod()]
        public void BorderDisabledDefault()
        {
            var propertyIndex = 13;
            var expectedValue = SuggestedActionsOptions.Defaults.Border;
            var src = new SuggestedActionsOptions (true){ };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue?.CSSText);
        }

        [TestMethod()]
        public void BorderDisabledCustom()
        {
            var propertyIndex = 13;
            var expectedValue = new CSSBorder("solid 1px violet");

            var src = new SuggestedActionsOptions(true) { Border = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue?.CSSText);
        }
        #endregion

        #region BorderColor Tests
        [TestMethod()]
        public void BorderColorDisabledDefault()
        {
            var propertyIndex = 7;
            var expectedValue = SuggestedActionsOptions.DefaultsDisabled.BorderColor;
            var src = new SuggestedActionsOptions(true) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderColorDisabledCustom()
        {
            var propertyIndex = 7;
            var expectedValue = CreateColor();

            var src = new SuggestedActionsOptions(true) { BorderColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderRadius Tests
        [TestMethod()]
        public void BorderRadiusDisabledDefault()
        {
            var propertyIndex = 8;
            var expectedValue = SuggestedActionsOptions.DefaultsDisabled.BorderRadius;
            var src = new SuggestedActionsOptions(true) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderRadiusDisabledCustom()
        {
            var propertyIndex = 8;
            var expectedValue = new CSSLengthUnit(r.Next(10, 24), CSSUnit.Points); ;

            var src = new SuggestedActionsOptions(true) { BorderRadius = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderStyle Tests
        [TestMethod()]
        public void BorderStyleDisabledDefault()
        {
            var propertyIndex = 9;
            var expectedValue = SuggestedActionsOptions.DefaultsDisabled.BorderStyle;
            var src = new SuggestedActionsOptions(true) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderStyleDisabledCustom()
        {
            var propertyIndex = 9;
            var expectedValue = EnumHelpers.GetRandomValue<CSSBorderStyle>(SuggestedActionsOptions.Defaults.BorderStyle);

            var src = new SuggestedActionsOptions(true) { BorderStyle = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderWidth Tests
        [TestMethod()]
        public void BorderWidthDisabledDefault()
        {
            var propertyIndex = 10;
            var expectedValue = SuggestedActionsOptions.DefaultsDisabled.BorderWidth;
            var src = new SuggestedActionsOptions(true) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderWidthDisabledCustom()
        {
            var propertyIndex = 10;
            var expectedValue = new CSSLengthUnit(r.Next(10, 24), CSSUnit.Points);

            var src = new SuggestedActionsOptions(true) { BorderWidth = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue.ToString());
        }
        #endregion

        #region TextColor Tests
        [TestMethod()]
        public void TextColorDisabledDefault()
        {
            var propertyIndex = 11;
            var expectedValue = SuggestedActionsOptions.DefaultsDisabled.TextColor;
            var src = new SuggestedActionsOptions(true) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void TextColorDisabledCustom()
        {
            var propertyIndex = 11;
            var expectedValue = CreateColor();

            var src = new SuggestedActionsOptions(true) { TextColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

    }
}