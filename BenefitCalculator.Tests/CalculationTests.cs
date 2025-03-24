using Xunit;
using BenefitCalculator;

namespace BenefitCalculator.Tests
{
    public class CalculationTests
    {
        private readonly Form1 form;

        public CalculationTests()
        {
            form = new Form1();
        }

        [Fact]
        public void TestFullDiscount_ValidInput_ReturnsFullAmount()
        {
            // Arrange
            form.cmbCategory.SelectedIndex = 0; // "Одинокий інвалід" (100%)
            form.txtElectricity.Text = "100";   // Витрати на електроенергію
            form.txtGas.Text = "50";           // Витрати на газ
            form.txtWater.Text = "20";         // Витрати на воду

            // Act
            form.btnCalculate.PerformClick();

            // Assert
            double totalBeforeDiscount = (100 * 4.32) + (50 * 8) + (20 * 90); // Загальна сума
            double actualResult = ParseResult(form.lblResult.Text);          // Отримуємо числове значення з lblResult

            Assert.Equal(totalBeforeDiscount, actualResult);
        }

        [Fact]
        public void TestHalfDiscount_ValidInput_ReturnsCorrectAmount()
        {
            // Arrange
            form.cmbCategory.SelectedIndex = 2; // "Особа з інвалідністю (50%)"
            form.txtElectricity.Text = "100";   // Витрати на електроенергію
            form.txtGas.Text = "50";           // Витрати на газ
            form.txtWater.Text = "20";         // Витрати на воду

            // Act
            form.btnCalculate.PerformClick();

            // Assert
            double totalBeforeDiscount = (100 * 4.32) + (50 * 8) + (20 * 90); // Загальна сума
            double totalCost = totalBeforeDiscount * (1 - 0.5);               // Знижка 50%
            double actualResult = ParseResult(form.lblResult.Text);          // Отримуємо числове значення з lblResult

            Assert.Equal(totalCost, actualResult);
        }

        [Fact]
        public void TestInvalidInput_ReturnsEmptyResult()
        {
            // Arrange
            form.cmbCategory.SelectedIndex = 0; // "Одинокий інвалід" (100%)
            form.txtElectricity.Text = "-100";  // Негативне значення (неправильний ввід)

            // Act
            form.btnCalculate.PerformClick();

            // Assert
            Assert.Equal("", form.lblResult.Text); // Результат не повинен оновлюватися
        }

        // Допоміжний метод для отримання числового значення з lblResult
        private double ParseResult(string resultText)
        {
            // Приклад тексту: "Сума до відшкодування: 2632.00 грн"
            string numericPart = resultText.Split(':')[1].Trim().Replace("грн", "").Trim();
            return double.Parse(numericPart);
        }
    }
}