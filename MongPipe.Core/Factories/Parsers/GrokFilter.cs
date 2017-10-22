using System;
using System.Collections.Generic;
using System.Text;
using MongPipe.Core.Filters.Parsers;
using MongPipe.Core.Helpers;

namespace MongPipe.Core.Factories
{
    public static class GrokFilter<TAccumluator>
    {
        public static GrokParseFilter<TAccumluator> Create(string pattern)
        {
            var resolver = new RegexPatternResolver(HardcodedPatterns.Patterns);
            var filter = new GrokParseFilter<TAccumluator>(resolver, pattern);
            return filter;
        }
    }
}
