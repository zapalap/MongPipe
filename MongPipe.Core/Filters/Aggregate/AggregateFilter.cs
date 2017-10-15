using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Filters
{
    public class AggregateFilter<TInput, TModel, TAccumulator> : IPipeFilter<TInput, TModel, TAccumulator>
    {
        readonly Func<IPipelineContext<TInput, TModel, TAccumulator>, TAccumulator, TAccumulator> Aggregation;

        public AggregateFilter(Func<IPipelineContext<TInput, TModel, TAccumulator>, TAccumulator, TAccumulator> aggregation)
        {
            Aggregation = aggregation;
        }

        public void Apply(IPipelineContext<TInput, TModel, TAccumulator> message)
        {
            message.Accumulator = Aggregation.Invoke(message, message.Accumulator);
        }
    }
}
