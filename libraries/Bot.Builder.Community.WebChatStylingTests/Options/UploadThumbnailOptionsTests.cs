using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class UploadThumbnailOptionsTests: OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "enableUploadThumbnail" ,
                "uploadThumbnailContentType" ,
                "uploadThumbnailHeight" ,
                "uploadThumbnailQuality" ,
                "uploadThumbnailWidth" ,
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new UploadThumbnailOptions
            {
            };

            var so = PopulateOptions(src);
            Assert.AreEqual(0, so.Count);

            so = PopulateOptions(src, true);
            Assert.AreEqual(5, so.Count);

        }

        [TestMethod]
        public void OptionNames()
        {
            var s = new UploadThumbnailOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        //UploadThumbnailOptions
        #region Enable Tests
        [TestMethod()]
        public void EnableDefault()
        {
            var propertyIndex = 0;
            var expectedValue = UploadThumbnailOptions.Defaults.Enable;
            var src = new UploadThumbnailOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void EnableCustom()
        {
            var propertyIndex = 0;
            var expectedValue = false;

            var src = new UploadThumbnailOptions { Enable = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region ContentType Tests
        [TestMethod()]
        public void ContentTypeDefault()
        {
            var propertyIndex = 1;
            var expectedValue = UploadThumbnailOptions.Defaults.ContentType;
            var src = new UploadThumbnailOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ContentTypeCustom()
        {
            var propertyIndex = 1;
            var expectedValue = "image/png";

            var src = new UploadThumbnailOptions { ContentType = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Height Tests
        [TestMethod()]
        public void HeightDefault()
        {
            var propertyIndex = 2;
            var expectedValue = UploadThumbnailOptions.Defaults.Height;
            var src = new UploadThumbnailOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void HeightCustom()
        {
            var propertyIndex = 2;
            var expectedValue = 300;

            var src = new UploadThumbnailOptions { Height = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Quality Tests
        [TestMethod()]
        public void QualityDefault()
        {
            var propertyIndex = 3;
            var expectedValue = UploadThumbnailOptions.Defaults.Quality;
            var src = new UploadThumbnailOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void QualityCustom()
        {
            var propertyIndex = 3;
            var expectedValue = 1.4;

            var src = new UploadThumbnailOptions { Quality = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Width Tests
        [TestMethod()]
        public void WidthDefault()
        {
            var propertyIndex = 4;
            var expectedValue = UploadThumbnailOptions.Defaults.Width;
            var src = new UploadThumbnailOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void WidthCustom()
        {
            var propertyIndex = 4;
            var expectedValue = 15;

            var src = new UploadThumbnailOptions { Width = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
    }
}