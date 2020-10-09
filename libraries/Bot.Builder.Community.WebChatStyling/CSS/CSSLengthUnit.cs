using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class CSSLengthUnit : IComparable<CSSLengthUnit>
    {

        #region Constructors
        public CSSLengthUnit() { }
        public CSSLengthUnit(string input)
        {
            string ParsePattern = @"^'?(?<Units>-?\d+)(?<Category>\w{1,4}|%)'?$";
            var match = Regex.Match(input, ParsePattern);
            string invalidMsg = $"{input} is not a valid unit length!";
            if (!match.Success)
            {
                throw new ArgumentException(invalidMsg);
            }
            var category = CSSUnitTypeAttribute.GetUnitFromSuffix<CSSUnit>(match.Groups["Category"].Value);
            if (category == CSSUnit.None)
            {
                throw new ArgumentException(invalidMsg);
            }
            this.UnitCategory = category;
            this.Units = int.Parse(match.Groups["Units"].Value);
        }
        public CSSLengthUnit(int units, CSSUnit unitCategory)
        {
            this.Units = units;
            this.UnitCategory = unitCategory;
        }
        #endregion

        #region Fields
        public int Units { get; set; }
        public CSSUnit UnitCategory { get; set; }
        public string UnitString
        {
            get
            {
                var up = "";
                if ((this.Units != 0) && (this.UnitCategory != CSSUnit.None))
                {
                    var suffix = CSSUnitTypeAttribute.GetUnitSuffix<CSSUnit>(this.UnitCategory);
                    up = this.Units.ToString() + suffix;
                }
                return up;
            }
        }
        #endregion

        #region Members
        public override string ToString()
        {
            return UnitString;
        }
        public static CSSLengthUnit Parse(string input)
        {
            return new CSSLengthUnit(input);
        }
        public static bool TryParse(string input, out CSSLengthUnit value)
        {
            value = null;
            try
            {
                value = Parse(input);
                return true;
            }
            catch { };
            return false;
        }

        int IComparable<CSSLengthUnit>.CompareTo(CSSLengthUnit other)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}

