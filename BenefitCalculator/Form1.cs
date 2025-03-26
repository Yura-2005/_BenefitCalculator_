using System;
using System.Windows.Forms;

namespace BenefitCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string category = cmbCategory.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(category))
                {
                    MessageBox.Show("Будь ласка, виберіть категорію пільговика.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtFamilyMembers.Text, out int familyMembers) || familyMembers < 0)
                {
                    MessageBox.Show("Кількість членів сім'ї повинна бути цілим числом та більше або рівне нулю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtElectricity.Text, out double electricity) || electricity < 0)
                {
                    MessageBox.Show("Витрати на електроенергію повинні бути числом більше або рівним нулю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtGas.Text, out double gas) || gas < 0)
                {
                    MessageBox.Show("Витрати на газ повинні бути числом більше або рівним нулю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtWater.Text, out double water) || water < 0)
                {
                    MessageBox.Show("Витрати на воду повинні бути числом більше або рівним нулю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double totalCost = BenefitCalculator.Calculator.CalculateTotal(category, electricity, gas, water, 0);
                lblResult.Text = $"Сума до відшкодування: {totalCost:F2} грн";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = -1;
            txtFamilyMembers.Text = "";
            txtElectricity.Text = "";
            txtGas.Text = "";
            txtWater.Text = "";
            lblResult.Text = "";
        }
    }
}