using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Bot.Builder.Community.Helpers;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class AvatarCommonOptionsTests : OptionsTests
    {
        [TestInitialize]
        public void SetupProperties() {
            propertyNames.AddRange(new string[] {
                "avatarBorderRadius", 
                "avatarSize",
                "showAvatarInGroup"
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
            var s = new AvatarCommonOptions();
            var names = s.GetOptionNames();
            Assert.AreEqual(propertyNames.Count, names.Count);
        }

        [TestMethod()]
        public void BorderRadiusDefault()
        {
            var propertyIndex = 0;
            var expectedValue = AvatarCommonOptions.Defaults.BorderRadius;
            var aa = new AvatarCommonOptions { };

            var so = PopulateOptions(aa);
            AssertEmptyProperty(so, propertyIndex);            

            so = PopulateOptions(aa, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }


        [TestMethod()]
        public void BorderRadiusCustom()
        {
            var units = r.Next(5, 15,
                AvatarCommonOptions.Defaults.BorderRadius.Units / 5);
            var expectedRaw = new CSSLengthUnit($"'{units * 5}%'");
            var aa = new AvatarCommonOptions { BorderRadius = expectedRaw };
            var so = PopulateOptions(aa);
            Assert.AreEqual(
                expectedRaw.ToString(),
                so[propertyNames[0]]);

        }

        [TestMethod()]
        public void SizeDefault()
        {
            var propertyIndex = 1;
            var expectedValue = AvatarCommonOptions.Defaults.Size;
            var aa = new AvatarCommonOptions { };

            var so = PopulateOptions(aa);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(aa, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);

        }

        [TestMethod()]
        public void SizeCustom()
        {
            var propertyIndex = 1;
            var expectedValue = r.Next(25, 75, AvatarCommonOptions.Defaults.Size);

            var aa = new AvatarCommonOptions { Size = expectedValue };
            var so = PopulateOptions(aa);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);

        }

        [TestMethod()]
        public void GroupDefault()
        {
            var propertyIndex = 2;
            var expectedValue = AvatarCommonOptions.Defaults.Group;
            var aa = new AvatarCommonOptions { };

            var so = PopulateOptions(aa);
            AssertEmptyProperty(so, propertyIndex);

            so = PopulateOptions(aa, true);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);

        }

        [TestMethod()]
        public void GroupCustom()
        {
            var propertyIndex = 2;
            var expectedValue = EnumHelpers.GetRandomValue<AvatarGroupSetting>(AvatarCommonOptions.Defaults.Group);
            var aa = new AvatarCommonOptions { Group = expectedValue };

            var so = PopulateOptions(aa);
            AssertPopulatedProperty(so, propertyIndex, expectedValue);
        }
        

    }
}