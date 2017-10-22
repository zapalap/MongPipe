using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Helpers
{
    public static class HardcodedPatterns
    {
        public static IList<RegexAliasPattern> Patterns = new List<RegexAliasPattern>()
        {
            new RegexAliasPattern("USERNAME", "[a-zA-Z0-9._-]+"),
            new RegexAliasPattern("WORD", @"\b\w+\b"),
            new RegexAliasPattern("DATA", ".*?"),
            new RegexAliasPattern("GREEDYDATA", ".*"),
            new RegexAliasPattern("UUID", "[A-Fa-f0-9]{8}-(?:[A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}"),
            new RegexAliasPattern("IPV4", "(?<![0-9])(?:(?:[0-1]?[0-9]{1,2}|2[0-4][0-9]|25[0-5])[.](?:[0-1]?[0-9]{1,2}|2[0-4][0-9]|25[0-5])[.](?:[0-1]?[0-9]{1,2}|2[0-4][0-9]|25[0-5])[.](?:[0-1]?[0-9]{1,2}|2[0-4][0-9]|25[0-5]))(?![0-9])"),
        };
    }
}
