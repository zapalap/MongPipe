using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.Pipeline
{
    public class MessageContext<TInput, TModel, TAccumulator> : IPipeContext<TInput, TModel, TAccumulator>
    {
        public TInput Input { get; set; }
        public TModel Model { get; set; }
        public TAccumulator Accumulator { get; set; }
        public bool ShouldHalt { get; set; }
        public IList<string> Errors { get; set; } = new List<string>();
    }
}
