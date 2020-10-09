using System;
using System.Reflection;

namespace Bot.Builder.Community.WebChatStyling
{
    public class LengthStylingAttribute : StylingAttribute
    {
        public LengthStylingAttribute() : this(String.Empty)
        {
        }
        public LengthStylingAttribute(string name) : 
            base(name, StylingAttributeCategory.Value, StylingPropertyCategory.LengthUnit)
        {
        }

        public override object GetEffectiveValue(object input, object defaultValue, PropertyInfo attachedProperty, bool useDefault)
        {
            var vInput = input as CSSLengthUnit;
            var vDefault = defaultValue as CSSLengthUnit;
            if (String.Compare( vInput?.UnitString, vDefault.UnitString, true) == 0)
            {
                return useDefault ? vDefault.UnitString : null;
            }
            return vInput?.UnitString;
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
