using Bot.Builder.Community.Helpers;
using System;
using System.Reflection;

namespace Bot.Builder.Community.WebChatStyling
{
    public class EnumStylingAttribute : TypedStylingAttribute
    {
        private static readonly MethodInfo descriptionMethod =
            typeof(EnumHelpers).GetMethod("GetDescription");

        public EnumStylingAttribute(string name, Type targetType = null) : 
            base(name, targetType) 
        {
        }

        public override object GetEffectiveValue(object input, object defaultValue, PropertyInfo attachedProperty, bool useDefault)
        {
            var value = base.GetEffectiveValue(input, defaultValue, attachedProperty, useDefault);
            if (value == null)
            {
                return null;
            }
            var generic = descriptionMethod.MakeGenericMethod(targetType ?? attachedProperty.PropertyType);
            var ev = generic.Invoke(null, new object[] { value });
            return ev;
        }
    }
}

/*
if (current.MappedValues != undefined) {
    current.Value = current.MappedValues[current.Value];
}

if (current.Join != undefined) {
    current.Value = current.Value.join(current.Join)
}

if (current.Border != undefined) {
    current.Value = current.Value.CSSText;
}

if (current.Percentage != undefined) {
    current.Value = "'" + current.Value.toString() + "%'";
}
if (current.LengthUnit != undefined) {
    current.Value = "'" + current.Value.UnitString + "'";
}

if (current.ReplaceName != undefined) {
    propertyName = current.ReplaceName(current.Name, current.ReplaceNameParams);
}
if (current.Suffix != undefined) {
    propertyName += current.Suffix;
}
    */
