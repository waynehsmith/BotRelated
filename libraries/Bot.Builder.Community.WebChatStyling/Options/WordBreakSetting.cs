using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public enum WordBreakSetting
    {
        [CSSValue("normal")]
        Normal = 0,
        [CSSValue("break-all")]
        BreakAll,
        [CSSValue("break-word")] 
        BreakWord,
        [CSSValue("keep-all")] 
        KeepAll
    }
}
