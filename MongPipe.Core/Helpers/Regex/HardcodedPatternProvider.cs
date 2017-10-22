using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MongPipe.Core.Helpers
{
    class HardcodedPatternProvider : IPatternProvider
    {
        public IList<RegexAliasPattern> Provide()
        {
            return HardcodedPatterns.Patterns;
        }
    }
}
