``` ini

BenchmarkDotNet=v0.10.8, OS=Windows 10 Redstone 1 (10.0.14393)
Processor=Intel Core i5-4460 CPU 3.20GHz (Haswell), ProcessorCount=4
Frequency=3117781 Hz, Resolution=320.7409 ns, Timer=TSC
dotnet cli version=1.0.0
  [Host]     : .NET Core 4.6.25009.03, 64bit RyuJITDEBUG [AttachedDebugger]
  DefaultJob : .NET Core 4.6.25009.03, 64bit RyuJIT


```
 |            Method |      Mean |     Error |    StdDev |    Median |
 |------------------ |----------:|----------:|----------:|----------:|
 | GetCaculateNumber | 0.2837 ns | 0.1083 ns | 0.3194 ns | 0.1879 ns |
