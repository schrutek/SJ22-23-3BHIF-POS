using Spg.SpengerSearch.DomainModel.Application;

namespace Spg.SpengerSearch.UnitTests
{
    public class CalculatorTest
    {
        [Fact]
        public void Calculator_Add_3_5_SuccessTest()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            int actual = calculator.Add(3, 5);

            // Assert
            Assert.Equal(8, actual);
        }

        [Fact]
        public void Calculator_Divide_3_5_SuccessTest()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            decimal actual = calculator.Divide(3, 5);

            // Assert
            Assert.Equal(0.6M, actual);
        }

        [Fact]
        public void Calculator_Divide_3_0_SuccessTest()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            decimal actual = calculator.Divide(3, 0);

            // Assert
            Assert.Equal(0M, actual);
        }
    }
}