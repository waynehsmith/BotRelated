using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.WebChatStyling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    [TestClass()]
    public class EnumStylingAttributeTests
    {
        [TestMethod()]
        public void GetEffectiveValueSetTest()
        {
            var esa = new EnumStylingAttribute("Abc", typeof(WordBreakSetting));
            var v = esa.GetEffectiveValue(WordBreakSetting.KeepAll, 
                WordBreakSetting.BreakWord, null, false);

            Assert.AreEqual("keep-all", v);
            
        }

        [TestMethod()]
        public void GetEffectiveValueDefaultTest()
        {
            var esa = new EnumStylingAttribute("Abc", typeof(WordBreakSetting));
            var v = esa.GetEffectiveValue(null,
                WordBreakSetting.BreakWord, null, false);

            Assert.AreEqual("break-word", v);
        }

        [TestMethod()]
        public void GetEffectiveValueNullTest()
        {
            var esa = new EnumStylingAttribute("Abc", typeof(WordBreakSetting));
            var v = esa.GetEffectiveValue(null,
                null, null, false);

            Assert.AreEqual(null, v);
        }
    }
}