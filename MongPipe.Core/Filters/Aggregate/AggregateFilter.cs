using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Filters
{
    public class AggregateFilter<TInput, TModel, TAccumulator> : IPipeFilter<TInput, TModel, TAccumulator>
    {
        readonly Func<IPipeContext<TInput, TModel, TAccumulator>, TAccumulator, TAccumulator> Aggregation;

        public AggregateFilter(Func<IPipeContext<TInput, TModel, TAccumulator>, TAccumulator, TAccumulator> aggregation)
        {
            Aggregation = aggregation;
        }

        public void Apply(IPipeContext<TInput, TModel, TAccumulator> message)
        {
            message.Accumulator = Aggregation.Invoke(message, message.Accumulator);
        }
    }
}
