using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Helpers
{
    public class RegexAliasPattern
    {
        public string Alias { get; }
        public string Pattern { get; }

        public RegexAliasPattern(string alias, string pattern)
        {
            Alias = alias;
            Pattern = pattern;
        }
    }
}
