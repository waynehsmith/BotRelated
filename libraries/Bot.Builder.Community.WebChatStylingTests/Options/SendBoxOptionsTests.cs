using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Bot.Builder.Community.Helpers;
using System.Drawing;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class SendBoxOptionsTests : OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "hideSendBox",
                "hideUploadButton",
                "microphoneButtonColorOnDictate" ,
                "sendBoxBackground" ,
                "sendBoxButtonColor" ,

                "sendBoxButtonColorOnDisabled" ,
                "sendBoxButtonColorOnFocus" ,
                "sendBoxButtonColorOnHover" ,
                "sendBoxDisabledTextColor" ,
                "sendBoxHeight" ,

                "sendBoxMaxHeight" ,
                "sendBoxTextColor" ,
                "sendBoxBorderBottom" ,
                "sendBoxBorderLeft" ,
                "sendBoxBorderRight" ,

                "sendBoxBorderTop" ,
                "sendBoxPlaceholderColor" ,
                "sendBoxTextWrap" ,
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new SendBoxOptions
            {
            };

            var so = PopulateOptions(src);
            Assert.AreEqual(0, so.Count);

            so = PopulateOptions(src, true);
            Assert.AreEqual(18, so.Count);

        }

        [TestMethod]
        public void OptionNames()
        {
            var s = new SendBoxOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        #region Hide Tests
        [TestMethod()]
        public void HideDefault()
        {
            var propertyIndex = 0;
            var expectedValue = SendBoxOptions.Defaults.Hide;
            var src = new SendBoxOptions { };

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

            var src = new SendBoxOptions { Hide = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region HideUploadButton Tests
        [TestMethod()]
        public void HideUploadButtonDefault()
        {
            var propertyIndex = 1;
            var expectedValue = SendBoxOptions.Defaults.HideUploadButton;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void HideUploadButtonCustom()
        {
            var propertyIndex = 1;
            var expectedValue = true;

            var src = new SendBoxOptions { HideUploadButton = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region MicrophoneColor Tests
        [TestMethod()]
        public void MicrophoneColorDefault()
        {
            var propertyIndex = 2;
            var expectedValue = SendBoxOptions.Defaults.MicrophoneColor;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void MicrophoneColorCustom()
        {
            var propertyIndex = 2;
            var expectedValue = CreateColor();

            var src = new SendBoxOptions { MicrophoneColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BackgroundColor Tests
        [TestMethod()]
        public void BackgroundColorDefault()
        {
            var propertyIndex = 3;
            var expectedValue = SendBoxOptions.Defaults.BackgroundColor;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundColorCustom()
        {
            var propertyIndex = 3;
            var expectedValue = CreateColor(KnownColor.White);

            var src = new SendBoxOptions { BackgroundColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region ButtonColor Tests
        [TestMethod()]
        public void ButtonColorDefault()    
        {
            var propertyIndex = 4;
            var expectedValue = SendBoxOptions.Defaults.ButtonColor;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ButtonColorCustom()
        {
            var propertyIndex = 4;
            var expectedValue = CreateColor();

            var src = new SendBoxOptions { ButtonColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion


        #region ButtonColorDisabled Tests
        [TestMethod()]
        public void ButtonColorDisabledDefault()
        {
            var propertyIndex = 5;
            var expectedValue = SendBoxOptions.Defaults.ButtonColorDisabled;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ButtonColorDisabledCustom()
        {
            var propertyIndex = 5;
            var expectedValue = CreateColor();

            var src = new SendBoxOptions { ButtonColorDisabled = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region ButtonColorFocus Tests
        [TestMethod()]
        public void ButtonColorFocusDefault()
        {
            var propertyIndex = 6;
            var expectedValue = SendBoxOptions.Defaults.ButtonColorFocus;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ButtonColorFocusCustom()
        {
            var propertyIndex = 6;
            var expectedValue = CreateColor();

            var src = new SendBoxOptions { ButtonColorFocus = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region ButtonColorHover Tests
        [TestMethod()]
        public void ButtonColorHoverDefault()
        {
            var propertyIndex = 7;
            var expectedValue = SendBoxOptions.Defaults.ButtonColorHover;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ButtonColorHoverCustom()
        {
            var propertyIndex = 7;
            var expectedValue = CreateColor();

            var src = new SendBoxOptions { ButtonColorHover = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region TextColorDisabled Tests
        [TestMethod()]
        public void TextColorDisabledDefault()
        {
            var propertyIndex = 8;
            var expectedValue = SendBoxOptions.Defaults.TextColorDisabled;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void TextColorDisabledCustom()
        {
            var propertyIndex = 8;
            var expectedValue = CreateColor();

            var src = new SendBoxOptions { TextColorDisabled = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Height Tests
        [TestMethod()]
        public void HeightDefault()
        {
            var propertyIndex = 9;
            var expectedValue = SendBoxOptions.Defaults.Height;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void HeightCustom()
        {
            var propertyIndex = 9;
            var expectedValue = r.Next(10, 50, SendBoxOptions.Defaults.Height);

            var src = new SendBoxOptions { Height = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion


        #region HeightMax Tests
        [TestMethod()]
        public void HeightMaxDefault()
        {
            var propertyIndex = 10;
            var expectedValue = SendBoxOptions.Defaults.HeightMax;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void HeightMaxCustom()
        {
            var propertyIndex = 10;
            var expectedValue = r.Next(100, 300, SendBoxOptions.Defaults.HeightMax);

            var src = new SendBoxOptions { HeightMax = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region TextColor Tests
        [TestMethod()]
        public void TextColorDefault()
        {
            var propertyIndex = 11;
            var expectedValue = SendBoxOptions.Defaults.TextColor;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void TextColorCustom()
        {
            var propertyIndex = 11;
            var expectedValue = CreateColor(KnownColor.Black);

            var src = new SendBoxOptions { TextColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderBottom Tests
        [TestMethod()]
        public void BorderBottomDefault()
        {
            var propertyIndex = 12;
            var expectedValue = SendBoxOptions.Defaults.BorderBottom;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderBottomCustom()
        {
            var propertyIndex = 12;
            var expectedValue = CreateBorder();

            var src = new SendBoxOptions { BorderBottom = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderLeft Tests
        [TestMethod()]
        public void BorderLeftDefault()
        {
            var propertyIndex = 13;
            var expectedValue = SendBoxOptions.Defaults.BorderLeft;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderLeftCustom()
        {
            var propertyIndex = 13;
            var expectedValue = CreateBorder();

            var src = new SendBoxOptions { BorderLeft = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BorderRight Tests
        [TestMethod()]
        public void BorderRightDefault()
        {
            var propertyIndex = 14;
            var expectedValue = SendBoxOptions.Defaults.BorderRight;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderRightCustom()
        {
            var propertyIndex = 14;
            var expectedValue = CreateBorder();

            var src = new SendBoxOptions { BorderRight = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion


        #region BorderTop Tests
        [TestMethod()]
        public void BorderTopDefault()
        {
            var propertyIndex = 15;
            var expectedValue = SendBoxOptions.Defaults.BorderTop;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BorderTopCustom()
        {
            var propertyIndex = 15;
            var expectedValue = CreateBorder();

            var src = new SendBoxOptions { BorderTop = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region PlaceholderColor Tests
        [TestMethod()]
        public void PlaceholderColorDefault()
        {
            var propertyIndex = 16;
            var expectedValue = SendBoxOptions.Defaults.PlaceholderColor;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void PlaceholderColorCustom()
        {
            var propertyIndex = 16;
            var expectedValue = CreateColor();

            var src = new SendBoxOptions { PlaceholderColor = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region TextWrap Tests
        [TestMethod()]
        public void TextWrapDefault()
        {
            var propertyIndex = 17;
            var expectedValue = SendBoxOptions.Defaults.TextWrap;
            var src = new SendBoxOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void TextWrapCustom()
        {
            var propertyIndex = 17;
            var expectedValue = true;

            var src = new SendBoxOptions { TextWrap = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion





        
    }
}