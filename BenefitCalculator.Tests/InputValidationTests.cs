using Xunit;
using BenefitCalculator;
using System.Windows.Forms;
using Moq;

namespace BenefitCalculator.Tests
{
    public class InputValidationTests
    {
        private readonly Form1 form;

        public InputValidationTests()
        {
            form = new Form1();
        }

        [Theory]
        [InlineData("-1")]  // Від’ємне число
        [InlineData("abc")] // Некоректне значення
        [InlineData("")]    // Порожнє поле
        public void TestInvalidFamilyMembersInput(string input)
        {
            // Arrange
            form.txtFamilyMembers.Text = input;

            // Act
            form.btnCalculate.PerformClick();

            // Assert
            Assert.Equal("", form.lblResult.Text); // Результат не повинен оновлюватися
            // Перевірка, що MessageBox.Show був викликаний (можна реалізувати через Moq)
        }

        [Theory]
        [InlineData("-10")] 
        [InlineData("text")] 
        [InlineData("")]    
        public void TestInvalidElectricityInput(string input)
        {
            // Arrange
            form.txtElectricity.Text = input;

            // Act
            form.btnCalculate.PerformClick();

            // Assert
            Assert.Equal("", form.lblResult.Text); // Результат не повинен оновлюватися
            // Перевірка, що MessageBox.Show був викликаний (можна реалізувати через Moq)
        }

        [Theory]
        [InlineData("-50")] 
        [InlineData("invalid")] 
        [InlineData("")]    
        public void TestInvalidGasInput(string input)
        {
            // Arrange
            form.txtGas.Text = input;

            // Act
            form.btnCalculate.PerformClick();

            // Assert
            Assert.Equal("", form.lblResult.Text); // Результат не повинен оновлюватися
            // Перевірка, що MessageBox.Show був викликаний (можна реалізувати через Moq)
        }

        [Theory]
        [InlineData("-100")] 
        [InlineData("xyz")] 
        [InlineData("")]    
        public void TestInvalidWaterInput(string input)
        {
            // Arrange
            form.txtWater.Text = input;

            // Act
            form.btnCalculate.PerformClick();

            // Assert
            Assert.Equal("", form.lblResult.Text); // Результат не повинен оновлюватися
            // Перевірка, що MessageBox.Show був викликаний (можна реалізувати через Moq)
        }

        [Fact]
        public void TestNoCategorySelected()
        {
            // Arrange
            form.cmbCategory.SelectedIndex = -1; // Категорія не вибрана

            // Act
            form.btnCalculate.PerformClick();

            // Assert
            Assert.Equal("", form.lblResult.Text); // Результат не повинен оновлюватися
            // Перевірка, що MessageBox.Show був викликаний (можна реалізувати через Moq)
        }
    }
}