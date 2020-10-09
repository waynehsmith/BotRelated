using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class CSSBorder : CSSLengthUnit
    {
        public CSSBorder()
        {

        }
        public CSSBorder(string input)
        {
            ParseBorder(input);
        }

        public void ParseBorder(string input)
        {
            string ParsePattern =
                @"^((?<Width>\d+(\w{1,4}|%)) +)?" +
                "((?<Style>dotted|dashed|solid|double|groove|ridge|inset|outset|none|hidden) ?){1,4}" +
                @"((?<Width>\d+(\w{1,4}|%)) +)?(?<Color>.+)?$";
            var match = Regex.Match(input, ParsePattern, RegexOptions.IgnoreCase);
            string invalidMsg = $"{input} is not a valid border";
            if (!match.Success)
            {
                throw new ArgumentException(invalidMsg);
            }
            if (!CSSLengthUnit.TryParse(match.Groups["Width"].Value, out var lu))
            {
                throw new ArgumentException(invalidMsg);
            }
            if (lu.UnitCategory == CSSUnit.None)
            {
                throw new ArgumentException(invalidMsg);
            }
            this.UnitCategory = lu.UnitCategory;
            this.Units = lu.Units;
            var parsedStyles = match.Groups["Style"].Captures;
            var styles = parsedStyles.Select(c =>
                (CSSBorderStyle)Enum.Parse(typeof(CSSBorderStyle), c.Value.Trim(), true))
                .ToArray<CSSBorderStyle>();
            this.StyleSides = styles;
            this.Style = styles[0];
            this.Color = match.Groups["Color"].Value.Trim();
        }

        public CSSBorderStyle Style { get; set; }
        public CSSBorderStyle[] StyleSides { get; set; }

        public string Color { get; set; }

        public string CSSText
        {
            get
            {
                return this.ToString();
            }
        }
        public override string ToString()
        {
            if ((this.Style == CSSBorderStyle.none) && (this.StyleSides?.Length == 0))
            {
                return "";
            }
            else
            {
                var bp = this.Style == CSSBorderStyle.none ? "" : this.Style.ToString();
                var up = this.UnitString + " ";
                var cp = "";

                if (!String.IsNullOrEmpty(this.Color))
                {
                    cp = " " + this.Color;
                }
                return $"{up}{bp}{cp}".Trim();
            }
        }
        
    }

}
/*
p.dotted {border-style: dotted;}
p.dashed {border-style: dashed;}
p.solid {border-style:  solid;}
p.double {border-style: double;}
p.groove {border-style: groove;}
p.ridge {border-style:  ridge;}
p.inset {border-style:  inset;}
p.outset {border-style: outset;}
p.none {border-style:   none;}
p.hidden {border-style: hidden;}
p.mix {border-style: dotted dashed solid double;}
(?<Style>\w+)

dotted|dashed|solid|double|groove|ridge|inset|outset|none|hidden




    */
