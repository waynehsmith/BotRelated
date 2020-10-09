namespace Bot.Builder.Community.WebChatStyling
{
    public class NameTemplateAttribute : StylingAttribute
    {
        public NameTemplateAttribute(string name) : 
            base(name, StylingAttributeCategory.Name, StylingPropertyCategory.ReplaceName)
        { 
        }
        public override string GetEffectiveName(object input)
        {
            INameTemplate src = input as INameTemplate;
            var effectiveName = src.Resolver.Invoke(this.Name, src.NameTemplateParams);
            return effectiveName;
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
