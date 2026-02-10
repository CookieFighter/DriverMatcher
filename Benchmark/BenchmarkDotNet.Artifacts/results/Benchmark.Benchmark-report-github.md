```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i5-10210U CPU 1.60GHz (Max: 2.11GHz), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.13, 8.0.1325.6609), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 8.0.13 (8.0.13, 8.0.1325.6609), X64 RyuJIT x86-64-v3


```
| Method          | Mean       | Error    | StdDev   | Gen0    | Gen1    | Allocated |
|---------------- |-----------:|---------:|---------:|--------:|--------:|----------:|
| SortAlgorithm   |   816.3 μs |  3.86 μs |  3.22 μs | 62.5000 | 20.5078 |  200400 B |
| RadiusAlgorithm | 2,079.3 μs |  7.41 μs |  6.57 μs |       - |       - |     968 B |
| TopKAlgorithm   | 1,248.7 μs | 18.71 μs | 16.59 μs |       - |       - |     344 B |
