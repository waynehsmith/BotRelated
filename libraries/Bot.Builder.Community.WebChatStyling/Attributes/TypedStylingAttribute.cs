using Bot.Builder.Community.Helpers;
using System;
using System.Reflection;

namespace Bot.Builder.Community.WebChatStyling
{
    public abstract class TypedStylingAttribute : StylingAttribute
    {
        protected readonly Type targetType;

        public TypedStylingAttribute(string name, Type targetType = null) : 
            base(name, StylingAttributeCategory.Value, StylingPropertyCategory.General) 
        {
            this.targetType = targetType;
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
