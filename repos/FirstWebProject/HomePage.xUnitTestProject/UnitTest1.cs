using System;
using Xunit;
using Xunit.Abstractions;

namespace HomePage.xUnitTestProject
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        public void Test1()
        {
            //ARRANGE
            int expectedResult = 5;
            int actualResult = 5;
            int a = 50, b = 10;


            //ACT
            actualResult = a / b;

            _testOutputHelper.WriteLine($"Input Values are:{a} and {b}");
            _testOutputHelper.WriteLine($"expectedResult = {expectedResult} and actualResult = {actualResult}");
            //ASSERT

            Assert.Equal(expectedResult, actualResult); 
        }
    }
}
