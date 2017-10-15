using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Filters
{
    public class HoldIfFilter<TInput, TModel, TAccumulator> : IPipeFilter<TInput, TModel, TAccumulator>
    {
        readonly Func<TAccumulator, bool> Predicate;

        public HoldIfFilter(Func<TAccumulator, bool> predicate)
        {
            Predicate = predicate;
        }
        
        public void Apply(IPipelineContext<TInput, TModel, TAccumulator> message)
        {
            if (Predicate.Invoke(message.Accumulator))
            {
                message.ShouldHalt = true;
                message.Errors.Add($"Halting because of the Hold rule: {Predicate}");
                return;
            }
        }
    }
}
