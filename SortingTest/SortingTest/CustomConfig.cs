using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;

namespace SortingTest;

public class CustomConfig : ManualConfig
{
    public CustomConfig()
    {
        AddJob(Job.Default
            .WithWarmupCount(10)
            .WithIterationCount(20));
        
        AddLogger(ConsoleLogger.Default);
        AddColumnProvider(DefaultColumnProviders.Instance);
    }
}