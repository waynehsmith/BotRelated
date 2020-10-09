using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Bot.Builder.Community.Helpers;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class TimestampOptionsTests : OptionsTests
    {

        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "groupTimestamp" ,
                "sendTimeout" ,
                "sendTimeoutForAttachments" ,
                "timestampColor", // defaults to subtle
                "timestampFormat" ,
            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var src = new TimestampOptions
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
            var s = new TimestampOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        #region Group Tests
        [TestMethod()]
        public void GroupDefault()
        {
            var propertyIndex = 0;
            var expectedValue = TimestampOptions.Defaults.Group;
            var src = new TimestampOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void GroupCustom()
        {
            var propertyIndex = 0;
            var expectedValue = false;

            var src = new TimestampOptions { Group = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Timeout Tests
        [TestMethod()]
        public void TimeoutDefault()
        {
            var propertyIndex = 1;
            var expectedValue = TimestampOptions.Defaults.Timeout;
            var src = new TimestampOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void TimeoutCustom()
        {
            var propertyIndex = 1;
            var expectedValue = 5000;

            var src = new TimestampOptions { Timeout = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region TimeoutAttachments Tests
        [TestMethod()]
        public void TimeoutAttachmentsDefault()
        {
            var propertyIndex = 2;
            var expectedValue = TimestampOptions.Defaults.TimeoutAttachments;
            var src = new TimestampOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void TimeoutAttachmentsCustom()
        {
            var propertyIndex = 2;
            var expectedValue = 50000;

            var src = new TimestampOptions { TimeoutAttachments = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Color Tests
        [TestMethod()]
        public void ColorDefault()
        {
            var propertyIndex = 3;
            var expectedValue = TimestampOptions.Defaults.Color;
            var src = new TimestampOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ColorCustom()
        {
            var propertyIndex = 3;
            var expectedValue = CreateColor();

            var src = new TimestampOptions { Color = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Format Tests
        [TestMethod()]
        public void FormatDefault()
        {
            var propertyIndex = 4;
            var expectedValue = TimestampOptions.Defaults.Format;
            var src = new TimestampOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void FormatCustom()
        {
            var propertyIndex = 4;
            var expectedValue = TimestampFormatSetting.absolute;

            var src = new TimestampOptions { Format = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion
    }
}