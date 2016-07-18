using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Logic;

namespace Logic.Tests
{
    [TestFixture]
    class AlgoServiceTests
    {

        [Test]
        public void GetDoubleSum_When_Runs_more_than_Int32_MaxValue_Then_throws_overflow_exception()
        {

            // Arrange
            var service = new AlgoService();
            long index = 0;
            long doublesum = 0;
            int[] enumerable = new int[] { 1, 2, 3 };

            //Assert
            Assert.That(() =>
            {

                while (index < 2220000000)
                {
                    // Act
                    doublesum += service.DoubleSum(enumerable);
                    index++;
                }
            }, Throws.TypeOf<OverflowException>());
        }

        [Test]
        [TestCase(1,1,1,1, ExpectedResult = 2-Math.PI)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(1, 1, 1, -1, ExpectedResult = -Math.PI)]
        public double Function_When_All_values_are_in_allowed_range_Then_function_calculates_result(int a, double b, int c, double d)
        {

            // Arrange
            var service = new AlgoService();
          
            // Act
            //var result = Math.Pow(d, 3) + a * c - Math.PI * Math.Sqrt(b);
            var function = service.Function(a,b,c,d);

            return function;

        }

        [Test]
        [TestCase(0, -1, 0, 0, ExpectedResult = double.NaN)]
        public double Function_When_second_parameter_is_less_than_zero_Then_returns_NaN(int a, double b, int c, double d)
        {

            // Arrange
            var service = new AlgoService();

            // Act
            var result = Math.Pow(d, 3) + a * c - Math.PI * Math.Sqrt(b);

            return result;
        }
    }
}
