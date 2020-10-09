using Bot.Builder.Community.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    [ExcludeRandom((int)CSSUnit.None)]
    public enum CSSUnit
    {        
        None = 0,
        [CSSUnitType("px", CSSUnitCategory.Absolute)]
        Pixels, //(1px = 1 / 96th of 1in)
        [CSSUnitType("cm", CSSUnitCategory.Absolute)]
        Centimeters,
        [CSSUnitType("mm", CSSUnitCategory.Absolute)]
        Millimeters,
        [CSSUnitType("in", CSSUnitCategory.Absolute)]
        Inches, //(1in = 96px = 2.54cm)

        [CSSUnitType("pt", CSSUnitCategory.Absolute)]
        Points, //(1pt = 1 / 72 of 1in)
        [CSSUnitType("pc", CSSUnitCategory.Absolute)]
        Picas, //(1pc = 12 pt)

        [CSSUnitType("em", CSSUnitCategory.Relative)]
        Element, //Relative to the font-size of the element (2em means 2 times the size of the current font)	
        [CSSUnitType("ex", CSSUnitCategory.Relative)]
        XHeight, //Relative to the x-height of the current font(rarely used)
        [CSSUnitType("ch", CSSUnitCategory.Relative)]
        ZeroWidth, //Relative to the width of the "0" (zero)
        [CSSUnitType("rem", CSSUnitCategory.Relative)]
        ElementRoot, //Relative to font-size of the root element
        [CSSUnitType("vw", CSSUnitCategory.Relative)]
        ViewportWidth, //Relative to 1% of the width of the viewport*	
        [CSSUnitType("vh", CSSUnitCategory.Relative)]
        ViewportHeight, //Relative to 1% of the height of the viewport*	
        [CSSUnitType("vmin", CSSUnitCategory.Relative)]
        ViewportMin, //Relative to 1% of viewport's* smaller dimension	
        [CSSUnitType("vmax", CSSUnitCategory.Relative)]
        ViewportMax, //Relative to 1% of viewport's* larger dimension	
        [CSSUnitType("%", CSSUnitCategory.Relative)]
        Percent //Relative to the parent element            
    }

}
