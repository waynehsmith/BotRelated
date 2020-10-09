using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bot.Builder.Community.Helpers
{
    
    [System.AttributeUsage(System.AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
    internal class ExcludeRandomAttribute : Attribute
    {
        private readonly int[] values;

        public ExcludeRandomAttribute(params int[] values )
        {
            this.values = values;
        }
        public T[] ExcludedValues<T>() where T:Enum
        {
            return values.FromIntArray<T>();
        }
    }

    
    internal  static class EnumHelpers
    {
        public static T GetValueFromDescription<T>(this string description) where T : Enum
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (String.Compare(attribute.Description, description, true) == 0)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (String.Compare(field.Name, description, true) == 0)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
            // or return default(T);
        }
        public static string GetDescription<T>(this T value) where T : Enum
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            return !(Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute) ? value.ToString() : attribute.Description;
        }
        public static U GetCustomAttribute<U, T>(this T value) where T : Enum where U: Attribute
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

           return Attribute.GetCustomAttribute(field, typeof(U)) as U;
        }

        public static IEnumerable<string> GetDescriptions<T>() where T : Enum
        {
            var result = Enum.GetValues(typeof(T))
                .Cast<T>().Select(v => GetDescription<T>(v));
            return result;
        }
        public static bool TryGetValueFromDescription<T>(this string description, out T value) where T : Enum
        {
            var success = false;
            value = default;
            try
            {
                value = GetValueFromDescription<T>(description);
                success = true;
            }
            catch (ArgumentException) { }
            return success;
        }

        public static int[] ToIntArray<T>(this T[] value)
        {
            int[] result = new int[value.Length];
            for (int i = 0; i < value.Length; i++)
                result[i] = Convert.ToInt32(value[i]);
            return result;
        }

        public static T[] FromIntArray<T>(this int[] value)
        {
            T[] result = new T[value.Length];
            for (int i = 0; i < value.Length; i++)
                result[i] = (T)Enum.ToObject(typeof(T), value[i]);
            return result;
        }

        public static List<T> GetRandomValueList<T>() where T: Enum {
            
            return GetRandomValueList<T>((v) => true);
        }
        public static List<T> GetRandomValueList<T>(Func<T, bool> fnInclude) where T : Enum
        {
            var eType = typeof(T);
            var allValues = Enum.GetValues(typeof(T)).Cast<T>().ToList();

            var era = eType.GetCustomAttribute<ExcludeRandomAttribute>();
            if (era != null)
            {
                var excluded = era.ExcludedValues<T>();
                return allValues.Except(excluded).Where(v => fnInclude(v)).ToList();
            }
            return allValues;
        }

        public static T GetRandomValue<T>() where T : Enum
        {
            return GetRandomValue<T>((v) => true);
        }
        public static T GetRandomValue<T>(Func<T, bool> fnInclude) where T:Enum
        {
            var allValues = GetRandomValueList<T>(fnInclude);
            var value = allValues[RandomHelper.GetRandom(0, allValues.Count)];
            return value;
        }
        public static T GetRandomValue<T>(params T[] exclude) where T : Enum
        {
            var allValues = GetRandomValueList<T>();
            T value;// = default;
            bool excluded;
            do
            {
                value = allValues[RandomHelper.GetRandom(0, allValues.Count)];
                excluded = exclude.Contains(value);
            } while (excluded);
                
            return value;
        }

        public static List<T> GetRandomValues<T>(int count) where T : Enum
        {
            return GetRandomValues<T>(count, (v) => true);
        }
        public static List<T> GetRandomValues<T>(int count, Func<T, bool> fnInclude) where T : Enum
        {
            var values = new List<T>(count);
            var allValues = GetRandomValueList<T>();

            while (values.Count < count)
            {
                if (allValues.Count == 0)
                {
                    allValues = GetRandomValueList<T>(fnInclude);
                }
                var value = allValues[RandomHelper.GetRandom(0, allValues.Count)];
                values.Add(value);
                allValues.Remove(value);
            }
            return values;
        }
    }
}
