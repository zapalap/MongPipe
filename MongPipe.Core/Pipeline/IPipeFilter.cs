using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Pipeline
{
    public interface IPipeFilter<TInput, TModel, TAccumulator>
    {
        void Apply(IPipelineContext<TInput, TModel, TAccumulator> message);
    }
}
