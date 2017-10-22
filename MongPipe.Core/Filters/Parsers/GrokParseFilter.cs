using System;
using System.Collections.Generic;
using System.Text;
using MongPipe.Core.Pipeline;
using MongPipe.Core.Helpers;
using System.Linq;


namespace MongPipe.Core.Filters.Parsers
{
    public class GrokParseFilter<TAccumulator> : IPipeFilter<string, IDictionary<string, string>, TAccumulator>
    {
        private readonly RegexPatternResolver RegexResolver;
        private readonly string Pattern;
        
        public GrokParseFilter(RegexPatternResolver regexResolver, string pattern)
        {
            RegexResolver = regexResolver;
            Pattern = pattern;
        }

        public void Apply(IPipeContext<string, IDictionary<string, string>, TAccumulator> message)
        {
            var model = RegexResolver.Reslove(message.Input, Pattern);

            if (!model.Any())
            {
                message.ShouldHalt = true;
                message.Errors.Add("Could not parse input string");
                return;
            }

            message.Model = model;
        }
    }
}
