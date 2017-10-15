using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.DSL.Interface
{
    public class Accepted<TInput, TModel, TAccumulator> : IAccepted<TInput, TModel, TAccumulator>
    {
        public IPipeline<TInput, TModel, TAccumulator> Pipeline { get; }

        public Accepted(IPipeline<TInput, TModel, TAccumulator> pipeline)
        {
            Pipeline = pipeline;
        }
    }
}
