using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bot.Builder.Community.WebChatStyling
{
    public abstract class StylingAttribute : Attribute
    {
        protected string propertyName;
        protected StylingPropertyCategory propertyCategory;
        protected StylingAttributeCategory attributeCategory;
        protected string valueMemberName;
        
        public StylingAttribute(string propertyName, StylingAttributeCategory category, 
            StylingPropertyCategory propertyCategory, string valueMemberName = null)
        {
            this.propertyName = propertyName;
            this.propertyCategory = propertyCategory;
            this.attributeCategory = category;
            this.valueMemberName = valueMemberName;
        }

        public string Name { get => propertyName; }

        public StylingPropertyCategory PropertyCategory { get => propertyCategory; }
        public StylingAttributeCategory AttributeCategory { get => attributeCategory; }
        public string ValueMemberName { get => valueMemberName; }

        public virtual string GetEffectiveName(object input)
        {
            return propertyName;
        }
        public virtual object GetEffectiveValue(object input, object defaultValue, PropertyInfo attachedProperty, bool useDefault)
        {
            if (input == null)
            {
                return defaultValue;
            }
            try
            {
                return ValueEquality(input, defaultValue) ? (useDefault ? defaultValue : null) : input;
            }
            catch
            {
                try
                {
                    return EnumerableEquality(input, defaultValue) ? (useDefault ? defaultValue : null) : input;
                }
                catch 
                { 
                }
            }
            return input;
        }

        public virtual void PopulateOptions(JObject options, bool useDefault = false) { }

        public bool ValueEquality(object val1, object val2)
        {
            if (!(val1 is IConvertible)) throw new ArgumentException("val1 must be IConvertible type");
            if (!(val2 is IConvertible)) throw new ArgumentException("val2 must be IConvertible type");

            // convert val2 to type of val1.
            var converted2 = Convert.ChangeType(val2, val1.GetType());

            // compare now that same type.
            return val1.Equals(converted2);
        }
        public bool EnumerableEquality(object val1, object val2)
        {

            if (!(val1 is IEnumerable)) throw new ArgumentException("val1 must be IEnumerable type");
            if (!(val2 is IEnumerable)) throw new ArgumentException("val2 must be IEnumerable type");

            var vt = val1.GetType();
            Type baseType;
            if (vt.IsArray)
            {
                baseType = vt.GetElementType();
            }
            else
            {
                baseType = vt.GenericTypeArguments[0];
            }
            
            var t = typeof(Enumerable);
            var em = t.GetMethods().First(x => (x.Name == "Except") && (x.GetParameters().Length== 2));
            var am = t.GetMethods().First(x => (x.Name == "Any") && (x.GetParameters().Length == 1));
            var gem = em.MakeGenericMethod(new Type[] { baseType });
            var gam = am.MakeGenericMethod(new Type[] { baseType });

            var d1 = gem.Invoke(null, new object[] { val1, val2 }); 
            var d2 = gem.Invoke(null, new object[] { val2, val1 });
            var differencesFound = (bool)gam.Invoke(null, new object[] { d1 }) ||
                (bool)gam.Invoke(null, new object[] { d2 });

            return !differencesFound;
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
