h1 MongPipe 

MongPipe is a laser focused message processing pipeline that allows to easily aggregate incoming events based on arbitrary rules and then act upon those aggregates to your heart desire.

You want a quick ad hoc way to monitor for errors? Just spin up a basic MongPipe and send your logs trough it. It's easy!

``` csharp
var pipeline = new Pipeline<string, List<string>, int>(0);

pipeline
	.Parse(() => new SimpleComaSplitParseFilter<int>())
	.Accept(m => m.Any(s => s.Contains("ERROR")))
	.Aggregate((input, model, soFar) => soFar += 1)
	.HoldIf(a=>a < 10)
	.Sink((input, model, soFar) => EmailGateway.Send("alert@corp.com", "10 errors have occured"))
```

Or something more complicated

```csharp
	var pipeline = new Pipeline<string, IList<string>, IDictionary<string, int>>(new Dictionary<string, int>());

	pipeline
		.Parse(() => new SimpleComaSplitParseFilter<IDictionary<string, int>>())
		.Accept(m => m.Any(s => s.Contains("ERROR")))
		.Aggregate((input, model, accumulator) =>
		{
			if (accumulator.ContainsKey(input))
			{
				var count = accumulator[input];
				count++;
				accumulator[input] = count;
				return accumulator;
			}

			accumulator.Add(input, 1);
			return acccumulator;
		})
		.HoldIf(s => !s.Any(v => v.Value > 3))
		.Sink((input, model, accumulator) => EmailGateway.Send("alert@corp.com", "So many errors", $"The same error occured 3 times. {JsonConvert.SerializeObject(accumulator, Formatting.Indented)}"));
```csharp
