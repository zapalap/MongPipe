using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Pipeline
{
    public interface IPipe<TInput, TModel, TAccumulator>
    {
        void RegisterFilter(IPipeFilter<TInput,TModel, TAccumulator> filter);
        IPipe<TInput,TModel, TAccumulator> Start();
        void Pump(TInput message);
    }
}
