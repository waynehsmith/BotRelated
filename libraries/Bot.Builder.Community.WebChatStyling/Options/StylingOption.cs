using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public abstract class StylingOption
    {
        protected Type defaultsType = null;
        
        public StylingOption(Type defaultsType) 
        { 
            this.defaultsType = defaultsType; 
        }

        public Type DefaultsType { get => defaultsType; }

        public virtual void PopulateOptions(JObject options, bool useDefault = false)
        {
            var attType = typeof(StylingAttribute);
            var srcType = this.GetType();
            var currentMembers = srcType.GetProperties();
            var defaultMembers = this.DefaultsType?.GetProperties();
            for (int i = 0; i < currentMembers.Length; i++)
            {
                var currentMember = currentMembers[i] as PropertyInfo;
                var sAttributes = currentMember.GetCustomAttributes<StylingAttribute>();
                //(attType) as StylingAttribute;
                if (sAttributes.Count() > 0)
                {
                    string effectiveName = String.Empty;
                    dynamic effectiveValue = null;
                    bool populated = false;
                    foreach (var sa in sAttributes)
                    {
                        if (sa.AttributeCategory.HasFlag(StylingAttributeCategory.Option))
                        {
                            populated = true;
                            var completeOption = currentMember.GetGetMethod().Invoke(this, null) as StylingOption;
                            completeOption?.PopulateOptions(options, useDefault);
                        }
                        else
                        {
                            if (sa.AttributeCategory.HasFlag(StylingAttributeCategory.Name))
                            {
                                effectiveName = sa.GetEffectiveName(this);
                            }
                            if (sa.AttributeCategory.HasFlag(StylingAttributeCategory.Value))
                            {
                                dynamic srcValue = CallValueMember(sa, currentMember.GetValue(this));
                                var defaultMember = defaultMembers.First(m => m.Name == currentMember.Name) as PropertyInfo;
                                dynamic defaultValue = CallValueMember(sa, defaultMember.GetValue(null));
                                effectiveValue = sa.GetEffectiveValue(srcValue, defaultValue, currentMember, useDefault);
                                effectiveName = String.IsNullOrEmpty(effectiveName) ? sa.Name : effectiveName;
                            }
                        }
                    }
                    if (!populated && ((effectiveValue != null) || useDefault))
                    {
                        
                        options[effectiveName] = effectiveValue != null ? JToken.FromObject(effectiveValue) : null;
                    }
                }
                
            }
        }

        private static dynamic CallValueMember(StylingAttribute sa, dynamic input)
        {
            if ((input != null) && !String.IsNullOrEmpty(sa.ValueMemberName))
            {
                Type vmt = input.GetType();
                var vm = vmt.GetProperty(sa.ValueMemberName);
                return vm.GetValue(input, null);
            }

            return input;
        }

        public static IList<string> GetOptionNames(object source)
        {
            var names = new List<string>();
            var srcType = source.GetType();
            var currentMembers = srcType.GetProperties();
            for (int i = 0; i < currentMembers.Length; i++)
            {
                var currentMember = currentMembers[i] as PropertyInfo;
                var sAttributes = currentMember.GetCustomAttributes<StylingAttribute>();
                //(attType) as StylingAttribute;
                if (sAttributes.Count() > 0)
                {
                    string effectiveName = String.Empty;
                    foreach (var sa in sAttributes)
                    {
                        if (sa.AttributeCategory.HasFlag(StylingAttributeCategory.Name))
                        {
                            effectiveName = sa.GetEffectiveName(source);
                        }
                        if (sa.AttributeCategory.HasFlag(StylingAttributeCategory.Value))
                        {
                            effectiveName = String.IsNullOrEmpty(effectiveName) ? sa.Name : effectiveName;
                        }
                        if (sa.AttributeCategory.HasFlag(StylingAttributeCategory.Option))
                        {
                            // try to get the object
                            var m = currentMember.GetGetMethod();
                            var target = m?.Invoke(source, null);
                            if (target != null)
                            {
                                var targetNames = GetOptionNames(target);
                                if (targetNames?.Count > 0)
                                {
                                    names.AddRange(targetNames);
                                }
                            }
                            effectiveName = String.Empty;
                        }
                    }
                    if (!String.IsNullOrEmpty(effectiveName))
                    {
                        names.Add(effectiveName);
                    }
                }
            }
            return names;
        }
        public virtual IList<string> GetOptionNames() {
            return GetOptionNames(this);
        }
    }
}
