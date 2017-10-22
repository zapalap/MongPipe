using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace MongPipe.Core.Helpers
{
    public class RegexPatternResolver
    {
        private IDictionary<string, string> Aliases { get; }

        public RegexPatternResolver(IList<RegexAliasPattern> aliases)
        {
            Aliases = aliases.ToDictionary(a => a.Alias, a => a.Pattern);
        }

        public IDictionary<string, string> Reslove(string input, string pattern)
        {
            var output = new Dictionary<string, string>();

            var grok = new Regex(@"%{(\w+):(\w+)}");

            MatchEvaluator evaluator = match => string.Format("(?<{0}>{1})", match.Groups[2].Value, Aliases[match.Groups[1].Value]);

            var regex = new Regex(grok.Replace(pattern, evaluator));

            var matches = regex.Match(input);

            foreach (string name in regex.GetGroupNames())
                output.Add(name, matches.Groups[name].Value);

            return output;
        }

    }
}
