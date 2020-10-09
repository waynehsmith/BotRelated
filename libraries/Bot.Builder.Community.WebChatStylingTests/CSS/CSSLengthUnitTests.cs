using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;
using Bot.Builder.Community.Helpers;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class CSSLengthUnitTests : OptionsTests
    {
        [TestMethod()]
        public void DefaultConstructor()
        {
            var lu = new CSSLengthUnit();
            Assert.AreEqual(0, lu.Units);
            Assert.AreEqual(CSSUnit.None, lu.UnitCategory);
        }

        [TestMethod()]
        public void ConstructorString()
        {
            var units = r.Next(-15, 15, 0);
            var unitCategory = EnumHelpers.GetRandomValue<CSSUnit>(CSSUnit.None);
            var input = $"{units}{CSSUnitTypeAttribute.GetUnitSuffix<CSSUnit>(unitCategory)}";
            var lu = new CSSLengthUnit(input);
            Assert.AreEqual(units, lu.Units);
            Assert.AreEqual(unitCategory, lu.UnitCategory);
        }

        [TestMethod()]
        public void ConstructorComponents()
        {
            var units = r.Next(-15, 15, 0);
            var unitCategory = EnumHelpers.GetRandomValue<CSSUnit>();
            var lu = new CSSLengthUnit(units, unitCategory);
            Assert.AreEqual(units, lu.Units);
            Assert.AreEqual(unitCategory, lu.UnitCategory);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var units = r.Next(-15, 15, 0);
            var unitCategory = EnumHelpers.GetRandomValue<CSSUnit>(CSSUnit.None);
            var lu = new CSSLengthUnit(units, unitCategory);
            var expected = $"{units}{CSSUnitTypeAttribute.GetUnitSuffix<CSSUnit>(unitCategory)}";
            Assert.AreEqual(expected, lu.ToString());
        }

        [TestMethod()]
        public void ParseTest()
        {
            var units = r.Next(-15, 15, 0);
            var unitCategory = EnumHelpers.GetRandomValue<CSSUnit>(CSSUnit.None);
            var input = $"{units}{CSSUnitTypeAttribute.GetUnitSuffix<CSSUnit>(unitCategory)}";
            var lu = CSSLengthUnit.Parse(input);
            Assert.AreEqual(units, lu.Units);
            Assert.AreEqual(unitCategory, lu.UnitCategory);

            input = $"invalid{input}invalid";
            Assert.ThrowsException<ArgumentException>(
                () =>
                {
                    lu = CSSLengthUnit.Parse(input);
                }, $"Expected exception from invalid input: {input}");            
        }

        [TestMethod()]
        public void TryParseTest()
        {
            var units = r.Next(-15, 15, 0);
            var unitCategory = EnumHelpers.GetRandomValue<CSSUnit>(CSSUnit.None);
            var input = $"{units}{CSSUnitTypeAttribute.GetUnitSuffix<CSSUnit>(unitCategory)}";

            var value = CSSLengthUnit.TryParse(input, out CSSLengthUnit lu);
            Assert.AreEqual(units, lu.Units);
            Assert.AreEqual(unitCategory, lu.UnitCategory);
            Assert.IsTrue(value);

            input += "invalid";
            value = CSSLengthUnit.TryParse(input, out _);
            Assert.IsFalse(value);
        }
    }
}