using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;


// demonstration how to use the same Context guid number / or same
// context for all the tests (same id)
// we need to use calss that implement IClassFixture



// also any clear down like tearDown() , with xUnit
// we use the concept of IDispose and there we can do some clear of objects



namespace XUnitCalculatorDemo
{
    //define collection definition class to create same guid context 
    // to use it through all tests
    [CollectionDefinition("Guid Generator")]
    public class GuidGeneratorDefinition : ICollectionFixture<GuidGenerator> { };


    // the way to do dispose of any resource is to implement IDisposable

    [Collection("Guid Generator")]
    public class GuidGeneratorTestOne : IDisposable
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        // the way to inject the GuidGenerator object instance into the 
        // ctor , this is done by using annotation ->  [Collection("Guid Generator")]
        // above the class
        public GuidGeneratorTestOne(ITestOutputHelper output,
                        GuidGenerator guidGenerator)
        {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        public void Dispose()
        {
            _output.WriteLine($"The object was disposed , do some clearing job here !");
        }

        [Fact]
        public void GuidTest1()
        {
            var guid = _guidGenerator.RandowmGuid;
            _output.WriteLine($"The guid was {guid}");

        }

        [Fact]
        public void GuidTest2()
        {
            var guid = _guidGenerator.RandowmGuid;
            _output.WriteLine($"The guid was {guid}");

        }


    }

    public class GuidGeneratorTestTwo
    {

    }
}
