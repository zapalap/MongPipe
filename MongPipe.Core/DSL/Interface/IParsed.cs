using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.DSL.Interface
{
    public interface IParsed<TInput, TModel, TAccumulator>
    {
        IPipeline<TInput, TModel, TAccumulator> Pipeline { get; }
    }
}
