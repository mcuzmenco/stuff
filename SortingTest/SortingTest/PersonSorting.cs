using BenchmarkDotNet.Attributes;

namespace SortingTest;

public class PersonSorting
{
    private List<Person> _collection;
    private List<int> _ids;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();
        _ids = Enumerable.Range(1, 1000)
            .Select(_ => random.Next(1, 1000000))
            .Distinct()
            .Take(1000) // might be less than 1k, but whatever
            .ToList();

        _collection = _ids.Select(x => new Person()
        {
            Id = x
        }).ToList();
        
        // sorting ids after collection initialization but leave collection unsorted
        _ids.Sort();
    }

    [Benchmark]
    public void Version1()
    {
        var newCollection = _collection.OrderBy(x => _ids.IndexOf(x.Id)).ToList();
    }
    
    [Benchmark]
    public void Version2()
    {
        var dict = _collection.ToDictionary(x => x.Id);
        var newCollection = _ids.Select(id => dict[id]).ToList();
    }
}