using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Helpers.Regex
{
    public class RegexAlias
    {
        public string Alias { get; }
        public string Pattern { get; }

        public RegexAlias(string alias, string pattern)
        {
            Alias = alias;
            Pattern = pattern;
        }
    }
}
