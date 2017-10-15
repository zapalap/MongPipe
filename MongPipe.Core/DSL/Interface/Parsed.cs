using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.DSL.Interface
{
    public class Parsed<TInput, TModel, TAccumulator> : IParsed<TInput, TModel, TAccumulator>
    {
        public IPipeline<TInput, TModel, TAccumulator> Pipeline { get; }

        public Parsed(IPipeline<TInput, TModel, TAccumulator> pipeline)
        {
            Pipeline = pipeline;
        }

    }
}
