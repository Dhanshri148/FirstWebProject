using System;
using Xunit;
using Xunit.Abstractions;

namespace LMS.xUnitTestProject
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
            int expectedResult = 4;
            int actualResult = 0;
            int a = 1, b = 3;

            //ACT
            actualResult = a + b;

            _testOutputHelper.WriteLine($"Input Values are {a} and {b}");
            _testOutputHelper.WriteLine($"expectedResult = {expectedResult}, ActualResult = {actualResult}");

            //ASSERT
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
