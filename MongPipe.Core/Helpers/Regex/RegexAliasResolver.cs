using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MongPipe.Core.Helpers.Regex
{
    public class RegexAliasResolver
    {
        private IDictionary<string, string> Aliases { get; }

        public RegexAliasResolver(IList<RegexAlias> aliases)
        {
            Aliases = aliases.ToDictionary(a => a.Alias, a => a.Pattern);
            if (Aliases.Any(a => !(a.Key.StartsWith("%{") && a.Key.EndsWith("}"))))
            {
                throw new InvalidOperationException("Some aliases do not conform to the %{ALIAS} name convention");
            }
        }

        public string Reslove(string input)
        {
            while (true)
            {
                var nextAlias = SplitOnNext(input);

                if (nextAlias == null)
                    break;

                if (!Aliases.ContainsKey(nextAlias.Item2))
                    throw new InvalidOperationException($"Pattern {nextAlias.Item2} after {nextAlias.Item1} not found");

                var pattern = Aliases[nextAlias.Item2];

                input = $"{nextAlias.Item1}{pattern}{nextAlias.Item3}";
            }

            return input;
        }

        private Tuple<string, string, string> SplitOnNext(string input)
        {
            var startOfAlias = input.IndexOf("%{");
            var endOfAlias = input.IndexOf("}");

            if (startOfAlias == -1)
                return null;

            var soFar = input.Substring(0, startOfAlias);
            var alias = input.Substring(startOfAlias, endOfAlias + 1 - startOfAlias);
            var after = endOfAlias == input.Length - 1 ? "" : input.Substring(endOfAlias + 1, input.Length - (endOfAlias + 1));

            return new Tuple<string, string, string>(soFar, alias, after);
        }
    }
}
