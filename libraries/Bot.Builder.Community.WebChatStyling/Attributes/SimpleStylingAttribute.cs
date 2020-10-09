namespace Bot.Builder.Community.WebChatStyling
{
    public class SimpleStylingAttribute : StylingAttribute
    {
        public SimpleStylingAttribute() :this(string.Empty)
        {
        }
        public SimpleStylingAttribute(string name) : 
            base(name, StylingAttributeCategory.Value, StylingPropertyCategory.General) 
        {
        }
        public SimpleStylingAttribute(string name, string memberName) :
            base(name, StylingAttributeCategory.Value, StylingPropertyCategory.General, memberName)
        {
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
