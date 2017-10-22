using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Filters
{
    public class AcceptFilter<TInput, TModel, TAccumulator> : IPipeFilter<TInput, TModel, TAccumulator>
    {
        private readonly Func<IPipeContext<TInput, TModel, TAccumulator>, bool> Predicate;

        public AcceptFilter(Func<IPipeContext<TInput, TModel, TAccumulator>, bool> predicate)
        {
            Predicate = predicate;
        }
        
        public void Apply(IPipeContext<TInput, TModel, TAccumulator> message)
        {
            var shouldAccept = Predicate.Invoke(message);

            if (!shouldAccept)
            {
                message.ShouldHalt = true;
                message.Errors.Add($"Rejecting. Rule failed: {Predicate}");
            }
        }
    }
}
