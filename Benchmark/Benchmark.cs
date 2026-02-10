using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using DriverMatcher;

namespace Benchmark
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private List<Driver> _drivers;
        private const int N = 10000;
        private const int OrderX = 50, OrderY = 50;

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random(42);
            _drivers = new List<Driver>();
            for (int i = 0; i < N; i++)
            {
                _drivers.Add(new Driver(i, random.Next(0, 100), random.Next(0, 100)));
            }
        }

        [Benchmark]
        public List<Driver> SortAlgorithm() => DriverSearcher.FindDrivers_Sort(_drivers, OrderX, OrderY);

        [Benchmark]
        public List<Driver> RadiusAlgorithm() => DriverSearcher.FindDrivers_Radius(_drivers, OrderX, OrderY);

        [Benchmark]
        public List<Driver> TopKAlgorithm() => DriverSearcher.FindDrivers_TopK(_drivers, OrderX, OrderY);

    }
}

