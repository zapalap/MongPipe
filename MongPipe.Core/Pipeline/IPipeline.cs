using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Pipeline
{
    public interface IPipeline<TInput, TModel, TAccumulator>
    {
        void RegisterFilter(IPipeFilter<TInput,TModel, TAccumulator> filter);
        IPipeline<TInput,TModel, TAccumulator> Start();
        void Pump(TInput message);
    }
}
