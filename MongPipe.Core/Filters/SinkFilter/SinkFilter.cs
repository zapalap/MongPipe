using MongPipe.Core.Helpers;
using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MongPipe.Core.Filters
{
    public class SinkFilter<TInput, TModel, TAccumulator> : IPipeFilter<TInput, TModel, TAccumulator>
    {
        readonly Action<IPipelineContext<TInput, TModel, TAccumulator>> SinkAction;

        public SinkFilter(Action<IPipelineContext<TInput, TModel, TAccumulator>> sinkAction)
        {
            SinkAction = sinkAction;
        }

        public void Apply(IPipelineContext<TInput, TModel, TAccumulator> message)
        {
            SinkAction.Invoke(message);

            message.Accumulator = default(TAccumulator);
        }
    }
}
