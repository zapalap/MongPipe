using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Pipeline
{
    public class Pipeline<TInput, TModel, TAccumulator> : IPipeline<TInput, TModel, TAccumulator>
    {
        private TAccumulator AccumulatorState;

        public bool Started { get; private set; }

        private readonly IList<IPipeFilter<TInput, TModel, TAccumulator>> Filters = new List<IPipeFilter<TInput,TModel, TAccumulator>>();

        public Pipeline(TAccumulator initialAccumulatorValue)
        {
            AccumulatorState = initialAccumulatorValue;
        }

        public IPipeline<TInput,TModel, TAccumulator> Start()
        {
            Started = true;
            return this;
        }

        public void RegisterFilter(IPipeFilter<TInput,TModel, TAccumulator> filter)
        {
            Filters.Add(filter);
        }

        public void Pump(TInput message)
        {
            var context = new MessageContext<TInput, TModel, TAccumulator>()
            {
                Input = message,
                Accumulator = AccumulatorState
            };

            foreach (var filter in Filters)
            {
                filter.Apply(context);
                if (context.ShouldHalt)
                    break;
            }

            AccumulatorState = context.Accumulator;
        }
    }
}
