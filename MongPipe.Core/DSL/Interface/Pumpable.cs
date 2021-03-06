﻿using MongPipe.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongPipe.Core.DSL.Interface
{
    public class Pumpable<TInput, TModel, TAccumulator> : IPumpable<TInput, TModel, TAccumulator>
    {
        public IPipe<TInput, TModel, TAccumulator> Pipeline { get; }

        public Pumpable(IPipe<TInput, TModel, TAccumulator> pipeline)
        {
            Pipeline = pipeline;
        }

        public void Pump(TInput input)
        {
            Pipeline.Pump(input);
        }
    }
}
