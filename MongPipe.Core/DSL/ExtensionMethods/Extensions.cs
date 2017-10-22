using MongPipe.Core.DSL.Interface;
using MongPipe.Core.Filters;
using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.DSL
{
    public static class Extensions
    {
        public static IParsed<TInput, TModel, TAccumulator> Parse<TInput, TModel, TAccumulator>(this IPipe<TInput, TModel, TAccumulator> pipeline, Func<IPipeFilter<TInput, TModel, TAccumulator>> parseFilterFactory)
        {
            var parser = parseFilterFactory.Invoke();
            pipeline.RegisterFilter(parser);

            return new Parsed<TInput, TModel, TAccumulator>(pipeline);
        }

        public static IAccepted<TInput, TModel, TAccumulator> Accept<TInput, TModel, TAccumulator>(this IParsed<TInput, TModel, TAccumulator> parsed, Func<TModel, bool> predicate)
        {
            Func<IPipeContext<TInput, TModel, TAccumulator>, bool> acceptCondition = (ctx) => predicate.Invoke(ctx.Model);
            parsed.Pipeline.RegisterFilter(new AcceptFilter<TInput, TModel, TAccumulator>(acceptCondition));

            return new Accepted<TInput, TModel, TAccumulator>(parsed.Pipeline);
        }

        public static IPumpable<TInput, TModel, TAccumulator> Aggregate<TInput, TModel, TAccumulator>(this IAccepted<TInput, TModel, TAccumulator> accepted, Func<TInput, TModel, TAccumulator, TAccumulator> aggregator)
        {
            Func<IPipeContext<TInput, TModel, TAccumulator>, TAccumulator, TAccumulator> accumulate = (ctx, soFar) => aggregator.Invoke(ctx.Input, ctx.Model, soFar);
            accepted.Pipeline.RegisterFilter(new AggregateFilter<TInput, TModel, TAccumulator>(accumulate));
            return new Pumpable<TInput, TModel, TAccumulator>(accepted.Pipeline);
        }

        public static IPumpable<TInput, TModel, TAccumulator> HoldIf<TInput, TModel, TAccumulator>(this IPumpable<TInput, TModel, TAccumulator> actionable, Func<TAccumulator, bool> predicate)
        {
            actionable.Pipeline.RegisterFilter(new HoldIfFilter<TInput, TModel, TAccumulator>(predicate));
            return new Pumpable<TInput, TModel, TAccumulator>(actionable.Pipeline);
        }

        public static IPumpable<TInput, TModel, TAccumulator> Sink<TInput, TModel, TAccumulator>(this IPumpable<TInput, TModel, TAccumulator> actionable, Action<TInput, TModel, TAccumulator> sinkAction) 
        {
            Action<IPipeContext<TInput, TModel, TAccumulator>> action = (ctx) => sinkAction.Invoke(ctx.Input, ctx.Model, ctx.Accumulator);
            actionable.Pipeline.RegisterFilter(new SinkFilter<TInput, TModel, TAccumulator>(action));
            return new Pumpable<TInput, TModel, TAccumulator>(actionable.Pipeline);
        }
    }
}
