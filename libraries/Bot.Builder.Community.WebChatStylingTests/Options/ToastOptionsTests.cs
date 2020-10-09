using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Bot.Builder.Community.Helpers;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class ToastOptionsTests: OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "hideToaster" ,
                "toasterHeight" ,
                "toasterMaxHeight" ,
                "toasterSingularMaxHeight" ,
                "toastFontSize" ,

                "toastIconWidth" ,
                "toastSeparatorColor" ,
                "toastTextPadding" ,
                "toastErrorBackgroundColor" ,
                "toastErrorColor" ,

                "toastInfoBackgroundColor" ,
                "toastInfoColor" ,
                "toastSuccessBackgroundColor" ,
                "toastSuccessColor" ,
                "toastWarnBackgroundColor" ,

                "toastWarnColor" ,
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new ToastOptions
            {
            };

            var so = PopulateOptions(src);
            Assert.AreEqual(0, so.Count);

            so = PopulateOptions(src, true);
            Assert.AreEqual(16, so.Count);

        }


        [TestMethod]
        public void OptionNames()
        {
            var s = new ToastOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        
        //ToastOptions
        #region Hide Tests
        [TestMethod()]
        public void HideDefault()
        {
            var propertyIndex = 0;
            var expectedValue = ToastOptions.Defaults.Hide;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void HideCustom()
        {
            var propertyIndex = 0;
            var expectedValue = true;

            var src = new ToastOptions { Hide = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        #region Height Tests
        [TestMethod()]
        public void HeightDefault()
        {
            var propertyIndex = 1;
            var expectedValue = ToastOptions.Defaults.Height;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void HeightCustom()
        {
            var propertyIndex = 1;
            var expectedValue = 50;

            var src = new ToastOptions { Height = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        #region MaxHeight Tests
        [TestMethod()]
        public void MaxHeightDefault()
        {
            var propertyIndex = 2;
            var expectedValue = ToastOptions.Defaults.MaxHeight;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void MaxHeightCustom()
        {
            var propertyIndex = 2;
            var expectedValue = 75;

            var src = new ToastOptions { MaxHeight = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        #region SingularMaxHeight Tests
        [TestMethod()]
        public void SingularMaxHeightDefault()
        {
            var propertyIndex = 3;
            var expectedValue = ToastOptions.Defaults.SingularMaxHeight;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void SingularMaxHeightCustom()
        {
            var propertyIndex = 3;
            var expectedValue = 75;

            var src = new ToastOptions { SingularMaxHeight = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        #region FontSize Tests
        [TestMethod()]
        public void FontSizeDefault()
        {
            var propertyIndex = 4;
            var expectedValue = ToastOptions.Defaults.FontSize;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, CreatePercentageValue(expectedValue));
        }

        [TestMethod()]
        public void FontSizeCustom()
        {
            var propertyIndex = 4;
            var expectedValue = 50.75;

            var src = new ToastOptions { FontSize = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, CreatePercentageValue(expectedValue));
        }
        #endregion


        #region IconWidth Tests
        [TestMethod()]
        public void IconWidthDefault()
        {
            var propertyIndex = 5;
            var expectedValue = ToastOptions.Defaults.IconWidth;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void IconWidthCustom()
        {
            var propertyIndex = 5;
            var expectedValue = 20;

            var src = new ToastOptions { IconWidth = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        #region SeparatorColor Tests
        [TestMethod()]
        public void SeparatorColorDefault()
        {
            var propertyIndex = 6;
            var expectedValue = ToastOptions.Defaults.SeparatorColor;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void SeparatorColorCustom()
        {
            var propertyIndex = 6;
            var expectedValue = CreateColor();

            var src = new ToastOptions { SeparatorColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        #region TextPadding Tests
        [TestMethod()]
        public void TextPaddingDefault()
        {
            var propertyIndex = 7;
            var expectedValue = ToastOptions.Defaults.TextPadding;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void TextPaddingCustom()
        {
            var propertyIndex = 7;
            var expectedValue = 10;

            var src = new ToastOptions { TextPadding = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        #region ErrorBackgroundColor Tests
        [TestMethod()]
        public void ErrorBackgroundColorDefault()
        {
            var propertyIndex = 8;
            var expectedValue = ToastOptions.Defaults.ErrorBackgroundColor;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ErrorBackgroundColorCustom()
        {
            var propertyIndex = 8;
            var expectedValue = CreateColor();

            var src = new ToastOptions { ErrorBackgroundColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        #region ErrorColor Tests
        [TestMethod()]
        public void ErrorColorDefault()
        {
            var propertyIndex = 9;
            var expectedValue = ToastOptions.Defaults.ErrorColor;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ErrorColorCustom()
        {
            var propertyIndex = 9;
            var expectedValue = CreateColor();

            var src = new ToastOptions { ErrorColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region InfoBackgroundColor Tests
        [TestMethod()]
        public void InfoBackgroundColorDefault()
        {
            var propertyIndex = 10;
            var expectedValue = ToastOptions.Defaults.InfoBackgroundColor;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void InfoBackgroundColorCustom()
        {
            var propertyIndex = 10;
            var expectedValue = CreateColor();

            var src = new ToastOptions { InfoBackgroundColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        #region InfoColor Tests
        [TestMethod()]
        public void InfoColorDefault()
        {
            var propertyIndex = 11;
            var expectedValue = ToastOptions.Defaults.InfoColor;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void InfoColorCustom()
        {
            var propertyIndex = 11;
            var expectedValue = CreateColor();

            var src = new ToastOptions { InfoColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        #region SuccessBackgroundColor Tests
        [TestMethod()]
        public void SuccessBackgroundColorDefault()
        {
            var propertyIndex = 12;
            var expectedValue = ToastOptions.Defaults.SuccessBackgroundColor;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void SuccessBackgroundColorCustom()
        {
            var propertyIndex = 12;
            var expectedValue = CreateColor();

            var src = new ToastOptions { SuccessBackgroundColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion        
        #region SuccessColor Tests
        [TestMethod()]
        public void SuccessColorDefault()
        {
            var propertyIndex = 13;
            var expectedValue = ToastOptions.Defaults.SuccessColor;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void SuccessColorCustom()
        {
            var propertyIndex = 13;
            var expectedValue = CreateColor();

            var src = new ToastOptions { SuccessColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
        #region WarnBackgroundColor Tests
        [TestMethod()]
        public void WarnBackgroundColorDefault()
        {
            var propertyIndex = 14;
            var expectedValue = ToastOptions.Defaults.WarnBackgroundColor;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void WarnBackgroundColorCustom()
        {
            var propertyIndex = 14;
            var expectedValue = CreateColor();

            var src = new ToastOptions { WarnBackgroundColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion


        #region WarnColor Tests
        [TestMethod()]
        public void WarnColorDefault()
        {
            var propertyIndex = 15;
            var expectedValue = ToastOptions.Defaults.WarnColor;
            var src = new ToastOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void WarnColorCustom()
        {
            var propertyIndex = 15;
            var expectedValue = CreateColor();

            var src = new ToastOptions { WarnColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

    }
}