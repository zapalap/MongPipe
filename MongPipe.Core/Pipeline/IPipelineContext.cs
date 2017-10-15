using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Pipeline
{
    public interface IPipelineContext<TInput, TModel,  TAccumulator>
    {
        TInput Input { get; set; }
        TModel Model { get; set; }
        TAccumulator Accumulator { get; set; }

        bool ShouldHalt { get; set; }
        IList<string> Errors { get; set; }
    }
}
