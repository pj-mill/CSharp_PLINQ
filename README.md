# CSharp_PLINQ
Some examples demonstrating Parallel Linq.

---
|Feature |Description |
|--------|------------|
|Basics | Basic examples that reads customers from a csv file and outputs to the console using AsParallel |
|Order Preservation | Demonstrates how to process collection items in order (& reverse order) |
|Exception Handling | Demonstrates PLINQ exception handling with 'AggregateException' |
|Query Cancelling | CancellationTokenSource used to cancel query processes |
|Aggregate Function| Example calculates the standard deviation of a sequence of integers using an aggregate function|
|Merge Options| Demonstrates and compares NotBuffered, FullyBuffered & AutoBuffered options |
|File Iteration | 2 examples that use System.IO & PLINQ to access and process files for a given directory (make sure you change the path)|

---
####Language Features
|Feature|
|-------|
|AsParallel()|
|AsOrdered()|
|Take(n)|
|Reverse()|
|ElementAt(n)|
|AggregateException|
|OperationCanceledException|
|ConcurrentQueue|
|CancellationTokenSource|
|Random.Next|
|Thread|
|WithMergeOptions(option)|
|ParallelMergeOptions|
|Stopwatch|
|Enumerable.Range|
|Directory.GetFiles|
|Directory.EnumerateFiles|


---
####Resources
| Title | Author | Publisher |
|--------------|---------|--------|
| Pro C# 5.0 and the .NET 4.5 Framework| Andrew Troelsen | APRESS |
| [Task Parallelism (Task Parallel Library)](https://msdn.microsoft.com/en-us/library/dd537609(v=vs.110).aspx) |  | MSDN |
| [Parallel LINQ (PLINQ)](https://msdn.microsoft.com/en-us/library/dd460688(v=vs.110).aspx) |  | MSDN |
| [ParallelMergeOptions Enumeration](https://msdn.microsoft.com/en-us/library/system.linq.parallelmergeoptions(v=vs.100).aspx) |  | MSDN |
