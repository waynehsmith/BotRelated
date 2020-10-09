using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Bot.Builder.Community.WebChatStyling
{
    public class ListStylingAttribute : StylingAttribute
    {
        private readonly string delimiter;

        public ListStylingAttribute(string name, string delimiter) :
            base(name, StylingAttributeCategory.Value, StylingPropertyCategory.Join)
        {
            this.delimiter = delimiter;
        }
        public override object GetEffectiveValue(object input, object defaultValue, PropertyInfo attachedProperty, bool useDefault)
        {
            var values = base.GetEffectiveValue(input, defaultValue, attachedProperty, useDefault);
            var lstValues = new List<string>();
            string value = null;
            if (values != null)
            {
                foreach (var v in (IEnumerable)values)
                {
                    lstValues.Add($"'{v}'");
                }
                value = String.Join(delimiter, lstValues);
            }
            return value;
        }

        public static string DefaultDelimiter
        {
            get
            {
                return ", ";
            }
        }
    }
}