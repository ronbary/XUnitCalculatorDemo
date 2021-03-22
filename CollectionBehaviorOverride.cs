

using Xunit;

// this will ensure all the xUnit tests will run not in paraller
// but in sequence manner
[assembly: CollectionBehavior(DisableTestParallelization = true)]