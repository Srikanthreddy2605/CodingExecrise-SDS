using System;
using System.Runtime.InteropServices;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public  void GetFactorial_WithPositiveInput_ReturnsCorrectResult()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
        }

        [Fact]
        public void GetFactorial_WithNegativeInput_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.GetFactorial(-5));
        }
        [Fact]
        public void GetFactorial_WithZeroInput_ReturnsOne()
        {
            Assert.Equal(1, Algorithms.GetFactorial(0));
        }

        [Fact]
        public void FormatSeparators_ThreeItems_ReturnsCommaSeparatedWithAnd()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }

        [Fact]
        public void FormatSeparators_NullInput_ReturnsNull()
        {

            Assert.Equal(Algorithms.FormatSeparators(null),string.Empty);            
          
        }

        [Fact]
        public void FormatSeparators_SingleItem_ReturnsWithAndPrefix()
        {                     
            Assert.Equal(" and a", Algorithms.FormatSeparators("a"));
        }

        [Fact]
        public void FormatSeparators_TwoItems_ReturnsWithAndBetween()
        {

            string result = Algorithms.FormatSeparators("x", "y");
            Assert.Equal("x and y", result);
        }

    }
}