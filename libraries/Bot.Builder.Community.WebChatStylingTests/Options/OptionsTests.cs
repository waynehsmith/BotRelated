using Bot.Builder.Community.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bot.Builder.Community.WebChatStyling.Tests
{
    public class OptionsTests
    {
        protected Random r = new Random();

        protected List<string> propertyNames = new List<string>();

        protected void AssertPopulatedProperty<T>(JObject so, int propertyIndex, T expected) //where T:class
        {
            Assert.IsTrue(so.ContainsKey(propertyNames[propertyIndex]), $"{propertyNames[propertyIndex]} is not populated!");
            if (!typeof(T).IsEnum)
            {
                try
                {
                    Assert.AreEqual(expected, so.Value<T>(propertyNames[propertyIndex]));
                }
                catch(InvalidCastException)
                {
                    Assert.AreEqual(expected.ToString(), so.Value<String>(propertyNames[propertyIndex]));
                }                
            }
            else
            {
                var valueName = so.Value<String>(propertyNames[propertyIndex]);
                var t = typeof(T);
                var mName = "Parse";
                var mArgs = new Type[] { typeof(String), typeof(bool) };

                var et = typeof(Enum);
                MethodInfo gm = GetGenericMethod(t, mArgs, mName, et);
                object actualValue;
                try
                {
                    actualValue = gm.Invoke(null, new object[] { valueName, true });
                }
                catch (TargetInvocationException)
                {
                    et = typeof(EnumHelpers);
                    mName = "GetValueFromDescription";
                    mArgs = new Type[] { typeof(String) };
                    gm = GetGenericMethod(t, mArgs, mName, et);
                    actualValue = gm.Invoke(null, new object[] { valueName });
                }
                Assert.AreEqual(expected, actualValue);
            }
        }

        private static MethodInfo GetGenericMethod(Type t, Type[] mArgs, string mName, Type et)
        {
            var mi = et.GetMethod(mName, 1, mArgs);
            var gm = mi.MakeGenericMethod(t);
            return gm;
        }

        protected void AssertEmptyProperty(JObject so, int propertyIndex )
        {
            Assert.IsFalse(so.ContainsKey(propertyNames[propertyIndex]));
        }

        protected JObject PopulateOptions(StylingOption source, bool useDefault = false)
        {
            var target = new JObject();
            source.PopulateOptions(target, useDefault);
            return target;
        }
        protected string CreatePercentageValue(double value)
        {
            return $"'{value}%'";
        }
        protected string CreateStringList(IEnumerable<object> values, string delimiter)
        {
            var lstValues = new List<string>();
            string value = null;
            if (values != null)
            {
                foreach (var v in values)
                {
                    lstValues.Add($"'{v}'");
                }
                value = String.Join(delimiter, lstValues);
            }
            return value;
        }

        protected string CreateColor(KnownColor exclude)
        {
            return EnumHelpers.GetRandomValue<KnownColor>(exclude).ToString();
        }
        protected string CreateColor()
        {
            return EnumHelpers.GetRandomValue<KnownColor>().ToString();
        }

        protected CSSBorder CreateBorder()
        {
            var value = new CSSBorder
            {
                Color = CreateColor(),
                Style = EnumHelpers.GetRandomValue<CSSBorderStyle>(),
                Units = r.Next(1, 4),
                UnitCategory = EnumHelpers.GetRandomValue<CSSUnit>()
            };
            return value;
        }
        protected string GetRelativeFileName(string fileName)
        {
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
            var pos = pathItems.Reverse().ToList().FindIndex(x => string.Equals("bin", x));
            string projectPath = String.Join(Path.DirectorySeparatorChar.ToString(), 
                pathItems.Take(pathItems.Length - pos - 1));
            return Path.Combine(projectPath, "Data", fileName);
        }
    }
}
