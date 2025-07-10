using System;
using Xunit;

namespace DeveloperSample.ClassRefactoring
{
    public class ClassRefactorTest
    {
        [Theory]
        [InlineData(SwallowType.African, SwallowLoad.None, 22)]
        [InlineData(SwallowType.African, SwallowLoad.Coconut, 18)]       
        public void SwallowAfrican_ReturnCorrectAirspeed(SwallowType type, SwallowLoad load, double expectedSpeed)
        {
          
            var swallow = SwallowFactory.GetSwallowInstance(type, load);
            var actualSpeed = swallow.GetAirspeedVelocity();           
            Assert.Equal(expectedSpeed, actualSpeed);
        }

        [Theory]
        [InlineData(SwallowType.European, SwallowLoad.None, 20)]
        [InlineData(SwallowType.European, SwallowLoad.Coconut, 16)]
        public void SwallowEuropean_ReturnCorrectAirspeed(SwallowType type, SwallowLoad load, double expectedSpeed)
        {

            var swallow = SwallowFactory.GetSwallowInstance(type, load);
            var actualSpeed = swallow.GetAirspeedVelocity();
            Assert.Equal(expectedSpeed, actualSpeed);
        }
        [Fact]
        public void AfricanSwallow_Throws_ForLoadIsInvalid()
        {

            var invalidLoad = (SwallowLoad)134;
            var swallow = new AfricanSwallow(invalidLoad);
            var exception = Assert.Throws<InvalidOperationException>(() => swallow.GetAirspeedVelocity());
            Assert.Contains("NotSupported load", exception.Message);
        }
        [Fact]
        public void SwallowFactory_Throws_ForUnknownSwallowType()
        {
           
            var invalidSwallowType = (SwallowType)345;           
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                SwallowFactory.GetSwallowInstance(invalidSwallowType, SwallowLoad.None));
            Assert.Contains("NotSupported swallow type", exception.Message);
        }        
        [Fact]
        public void EuropeanSwallow_Throws_ForInvalidLoad()
        {
            
            var invalidLoad = (SwallowLoad)111;
            var swallow = new EuropeanSwallow(invalidLoad);            
            var exception = Assert.Throws<InvalidOperationException>(() => swallow.GetAirspeedVelocity());
            Assert.Contains("NotSupported load", exception.Message);
        }
    }
}