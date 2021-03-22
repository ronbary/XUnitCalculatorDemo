using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitCalculatorDemo
{
    public class CalculatorTests
    {
        private readonly Calculator sut;

        public CalculatorTests()
        {
            sut = new Calculator();
        }

        [Fact]
        public void AddTwoNumbersShouldEqualTheirEqual()
        {
            sut.Add(5);
            sut.Add(9);
            Assert.Equal(14, sut.Value);
        }



        // example for test with parameters

        [Theory]
        [InlineData(13,5,8)]
        [InlineData(0, -3, 3)]
        [InlineData(0, -1, 1)]
        public void AddTwoNumbersShouldEqualTheirEqualTheory(
            decimal expected,decimal firstToAdd,decimal secondToAdd)
        {
            sut.Add(firstToAdd);
            sut.Add(secondToAdd);
            Assert.Equal(expected, sut.Value);
        }

        // example of using another method TestData()
        // to create IEnumerable<object> 
        // as input testing data

        [Theory]
        [MemberData(nameof(TestData))]
        public void AddManyNumbersShouldEqualTheirEqualTheory(
            decimal expected, params decimal[] valuesToAdd)
        {
            foreach (var value in valuesToAdd)
            {
                sut.Add(value);
            }
            Assert.Equal(expected, sut.Value);
        }

  


        //this method create IEnumerable of Object[] 
        // to use the data for other method for testing
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 15, new decimal[] {10,5 } };
            yield return new object[] { 15, new decimal[] { 5, 5, 5 } };
            yield return new object[] { -10, new decimal[] { -30,20 } };
        }


        //the data for the test is taken from the class CalculatorTestData
        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void DivedeManyNumbersTheory(decimal expected, params decimal[] valuesToDivide)
        {
            foreach (var value in valuesToDivide)
            {
                sut.Divide(value);
            }
            Assert.Equal(expected, sut.Value);
        }


        /// <summary>
        /// CalculatorTestData in the [ClassData] attribute. 
        /// This class must implement IEnumerable<object[]>, 
        /// where each item returned is an array of objects to use as the method parameters.
        /// </summary>
        public class CalculatorTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { 30, new decimal[] { 60, 2 } };
                yield return new object[] { 40, new decimal[] { 80, 2 } };
                yield return new object[] { 0, new decimal[] { 0, 2 } };
                yield return new object[] { 1, new decimal[] { 50, 50 } };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

 
    }
}
