using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Metrics
{
    public interface ITrace
    {
        Task Add(string key, string value);
    }

    public interface ISendMetricsCommand
    {
        Task Execute();
    }

    public class TraceBuilder : ITrace
    {
        private readonly Trace _trace;

        public TraceBuilder(Trace trace)
        {
            _trace = trace;
        }

        public async Task Add(string key, string value)
        {
            await _trace.Add(key, value);
        }
    }

    public class SendMetricsCommand : ISendMetricsCommand
    {
        private readonly Trace _trace;

        public SendMetricsCommand(Trace trace)
        {
            _trace = trace;
        }

        public async Task Execute()
        {
            await _trace.Complete();
        }
    }

    public class Trace
    {
        private readonly Dictionary<string, string> _dimensions = new Dictionary<string, string>();

        public Task Add(string key, string value)
        {
            _dimensions[key] = value;
            return Task.CompletedTask;
        }

        public Task Complete()
        {
            System.Console.WriteLine($"Got {_dimensions.Count} entries");

            foreach (var (key, value) in _dimensions)
            {
                System.Console.WriteLine($"{key} = {value}");
            }

            return Task.CompletedTask;
        }
    }
}
