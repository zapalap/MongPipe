using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.DSL.Interface
{
    public class Parsed<TInput, TModel, TAccumulator> : IParsed<TInput, TModel, TAccumulator>
    {
        public IPipe<TInput, TModel, TAccumulator> Pipeline { get; }

        public Parsed(IPipe<TInput, TModel, TAccumulator> pipeline)
        {
            Pipeline = pipeline;
        }

    }
}
