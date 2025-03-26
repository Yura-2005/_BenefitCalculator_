using Xunit;

namespace BenefitCalculator.Tests
{
    public class BenefitCalculatorTests
    {
        [Fact]
        public void CalculateDiscount_ShouldReturnCorrectValue()
        {
            // Arrange
            var category = "Одинокий інвалід"; // 100% знижка
            double electricity = 100;
            double gas = 50;
            double water = 30;
            double area = 40;

            double expectedTotal = (electricity * 4.32) + (gas * 8) + (water * 90);

            // Act
            double actualTotal = BenefitCalculator.Calculator.CalculateTotal(category, electricity, gas, water, area);

            // Assert
            Assert.Equal(expectedTotal, actualTotal);
        }
    }
}