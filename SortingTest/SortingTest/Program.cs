using BenchmarkDotNet.Running;
using SortingTest;

BenchmarkRunner.Run<PersonSorting>(new CustomConfig());