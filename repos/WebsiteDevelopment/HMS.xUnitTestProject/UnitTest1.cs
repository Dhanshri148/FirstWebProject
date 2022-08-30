using System;
using Xunit;
using Xunit.Abstractions;

namespace HMS.xUnitTestProject
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOuptputHelper;
        public UnitTest1(ITestOutputHelper testOuptputHelper)
        {
            _testOuptputHelper = testOuptputHelper;
        }

        [Fact]
        public void Test1()
        {
            //ARRANGE
            int expectedResult = 10;
            int actualResult = 10;
            int a = 5, b = 5;

            //ACT
            actualResult = a + b;

            _testOuptputHelper.WriteLine($"Input values are {a} and {b} ");
            _testOuptputHelper.WriteLine($"expectedResult = {expectedResult} and actualResult = {actualResult}");

            //ASSERT
            Assert.Equal(expectedResult, actualResult);

        }
    }
}
