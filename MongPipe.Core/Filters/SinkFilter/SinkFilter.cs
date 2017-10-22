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
        readonly Action<IPipeContext<TInput, TModel, TAccumulator>> SinkAction;

        public SinkFilter(Action<IPipeContext<TInput, TModel, TAccumulator>> sinkAction)
        {
            SinkAction = sinkAction;
        }

        public void Apply(IPipeContext<TInput, TModel, TAccumulator> message)
        {
            SinkAction.Invoke(message);

            if (message.Accumulator.GetType().GetTypeInfo().IsValueType)
            {
                message.Accumulator = default(TAccumulator);
            }
             else
            {
                message.Accumulator = (TAccumulator)Activator.CreateInstance(message.Accumulator.GetType());
            }
        }
    }
}
