using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Bot.Builder.Community.Helpers;
using System.Drawing;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class AvatarOptionsTests : OptionsTests
    {
        [TestInitialize]
        public void SetupProperties()
        {
            propertyNames.AddRange(new string[] {
                "userAvatarBackgroundColor",
                "userAvatarImage",
                "userAvatarInitials",

                "botAvatarBackgroundColor",
                "botAvatarImage",
                "botAvatarInitials",

            });
        }

        [TestMethod()]
        public void EmptyContructor()
        {
            var aco = new AvatarCommonOptions
            {
            };

            var o = PopulateOptions(aco);
            Assert.AreEqual(0, o.Count);

            o = PopulateOptions(aco, true);
            Assert.AreEqual(3, o.Count);

        }

        [TestMethod]
        public void OptionNames()
        {
            var s = new AvatarOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        #region BackgroundColorUser Tests
        [TestMethod()]
        public void BackgroundColorUserDefault()
        {
            var propertyIndex = 0;
            string expectedValue = null;
            var aa = new AvatarOptions { };

            var so = PopulateOptions(aa);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(aa, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundColorUserCustom()
        {
            var propertyIndex = 0;
            var expectedValue = EnumHelpers.GetRandomValue<KnownColor>().ToString();

            var aa = new AvatarOptions { BackgroundColor = expectedValue };
            var so = PopulateOptions(aa);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region ImageUser Tests
        [TestMethod()]
        public void ImageUserDefault()
        {
            var propertyIndex = 1;
            string expectedValue = null;
            var src = new AvatarOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ImageUserCustom()
        {
            var propertyIndex = 1;
            var expectedValue = "https://virtualworkfriendbotz7sw.blob.core.windows.net/images/BotInitials.png"; 

            var src = new AvatarOptions { Image = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region InitialsUser Tests
        [TestMethod()]
        public void InitialsUserDefault()
        {
            var propertyIndex = 2;
            string expectedValue = null;
            var src = new AvatarOptions { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void InitialsUserCustom()
        {
            var propertyIndex = 2;
            var expectedValue = "ABC";

            var src = new AvatarOptions { Initials = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region BackgroundColorBot Tests
        [TestMethod()]
        public void BackgroundColorBotDefault()
        {
            var propertyIndex = 3;
            string expectedValue = null;
            var aa = new AvatarOptions(true) { };

            var so = PopulateOptions(aa);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(aa, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void BackgroundColorBotCustom()
        {
            var propertyIndex = 3;
            var expectedValue = EnumHelpers.GetRandomValue<KnownColor>().ToString();

            var aa = new AvatarOptions(true) { BackgroundColor = expectedValue };
            var so = PopulateOptions(aa);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Image Tests
        [TestMethod()]
        public void ImageBotDefault()
        {
            var propertyIndex = 4;
            string expectedValue = null;
            var src = new AvatarOptions(true) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void ImageBotCustom()
        {
            var propertyIndex = 4;
            var expectedValue = "https://virtualworkfriendbotz7sw.blob.core.windows.net/images/BotInitials.png";

            var src = new AvatarOptions(true) { Image = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

        #region Initials Tests
        [TestMethod()]
        public void InitialsBotDefault()
        {
            var propertyIndex = 5;
            string expectedValue = null;
            var src = new AvatarOptions(true) { };

            var so = PopulateOptions(src);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(src, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }

        [TestMethod()]
        public void InitialsBotCustom()
        {
            var propertyIndex = 5;
            var expectedValue = "ABC";

            var src = new AvatarOptions(true) { Initials = expectedValue };
            var so = PopulateOptions(src);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        #endregion

    }
}