using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Enum)]
    public class CSSUnitTypeAttribute : Attribute
    {
        public string Suffix { get; private set; }
        public CSSUnitCategory Category { get; private set; }
        public CSSUnitTypeAttribute(string suffix, CSSUnitCategory category)
        {
            this.Suffix = suffix;
            this.Category = category;
        }

        public static string GetUnitSuffix<T>(T value) where T:Enum
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            var att = Attribute.GetCustomAttribute(field, typeof(CSSUnitTypeAttribute)) as CSSUnitTypeAttribute;
            return att?.Suffix ?? String.Empty;
        }
        public static T GetUnitFromSuffix<T>(string suffix) where T : Enum
        {
            var t = typeof(T);
            var values = Enum.GetValues(t) as T[];
            return Array.Find<T>(values, v => 
            { 
                var field = t.GetField(v.ToString());
                var att = Attribute.GetCustomAttribute(field, typeof(CSSUnitTypeAttribute)) as CSSUnitTypeAttribute;
                return (att?.Suffix.CompareTo(suffix) == 0);
            });
        }
    }

}
