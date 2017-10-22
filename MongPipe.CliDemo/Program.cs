using MongPipe.Core.Pipeline;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongPipe.Core.DSL;
using MongPipe.Core.Filters;
using MongPipe.Core.Factories;

namespace MongPipe.CliDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipeline = new Pipe<string, IDictionary<string, string>, IDictionary<string, int>>(new Dictionary<string, int>());

            pipeline
                .Parse(() => GrokFilter<IDictionary<string,int>>.Create("%{USERNAME:user} %{WORD:loglevel}"))
                .Accept(m => m["loglevel"] == "ERROR")
                .Aggregate((input, model, soFar) =>
                {
                    if (soFar.ContainsKey(input))
                    {
                        var count = soFar[input];
                        count++;
                        soFar[input] = count;
                        return soFar;
                    }

                    soFar.Add(input, 1);
                    return soFar;
                })
                .HoldIf(s => !s.Any(v => v.Value > 3))
                .Sink((input, model, accumulator) => Console.WriteLine($"Error threshold reached. More than 3 errors happend. {JsonConvert.SerializeObject(accumulator, Formatting.Indented)}"));

            var command = "";

            while (command != "exit")
            {
                command = Console.ReadLine();
                pipeline.Pump(command);
            }
        }
    }
}
