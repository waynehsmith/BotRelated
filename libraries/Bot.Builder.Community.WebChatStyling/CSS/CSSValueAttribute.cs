using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Enum)]
    public class CSSValueAttribute : DescriptionAttribute
    {
        public CSSValueAttribute(string value) : base(value) { }
    }

}
