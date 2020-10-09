using System;
using System.Reflection;

namespace Bot.Builder.Community.WebChatStyling
{
    public class PercentageStylingAttribute : StylingAttribute
    {
        public PercentageStylingAttribute(string name) : 
            base(name, StylingAttributeCategory.Value, StylingPropertyCategory.Percentage) { }

        public override object GetEffectiveValue(object input, object defaultValue, PropertyInfo attachedProperty, bool useDefault)
        {
            var value = base.GetEffectiveValue(input, defaultValue, attachedProperty, useDefault);
            return (value == null) ? null : $"'{value}%'";
            
        }
    }
}