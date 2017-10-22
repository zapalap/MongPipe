using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Filters
{
    public class SimpleComaSplitParseFilter<TAccumulator>: IPipeFilter<string, IList<string>, TAccumulator>
    {
        public SimpleComaSplitParseFilter()
        {

        }

        public void Apply(IPipeContext<string, IList<string>, TAccumulator> message)
        {
            message.Model = message.Input.Split(',');
            return;
        }
    }
}
