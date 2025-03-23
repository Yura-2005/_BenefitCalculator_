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
                string category = cmbCategory.SelectedItem.ToString();

                // Перевірка на відсутність вибору категорії
                if (string.IsNullOrEmpty(category))
                {
                    MessageBox.Show("Будь ласка, виберіть категорію пільговика.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Перевірка на правильність вводу кількості членів сім'ї
                if (!int.TryParse(txtFamilyMembers.Text, out int familyMembers) || familyMembers < 0)
                {
                    MessageBox.Show("Кількість членів сім'ї повинна бути цілим числом та більше або рівне нулю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Перевірка на правильність вводу витрат на електроенергію
                if (!double.TryParse(txtElectricity.Text, out double electricity) || electricity < 0)
                {
                    MessageBox.Show("Витрати на електроенергію повинні бути числом більше або рівним нулю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Перевірка на правильність вводу витрат на газ
                if (!double.TryParse(txtGas.Text, out double gas) || gas < 0)
                {
                    MessageBox.Show("Витрати на газ повинні бути числом більше або рівним нулю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Перевірка на правильність вводу витрат на воду
                if (!double.TryParse(txtWater.Text, out double water) || water < 0)
                {
                    MessageBox.Show("Витрати на воду повинні бути числом більше або рівним нулю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double discount = 0;
                if (category == "Одинокий інвалід")
                    discount = 1.0; // 100%
                else if (category == "Особа з інвалідністю (50%)")
                    discount = 0.5; // 50%
                else if (category == "Ветеран УПА (75%)")
                    discount = 0.25; // 75%

                // Розрахунок загальної суми до знижки
                double totalBeforeDiscount = (electricity * 4.32) + (gas * 8) + (water * 90);

                // Розрахунок вартості після застосування знижки
                double totalCost = discount == 1.0 ? totalBeforeDiscount : totalBeforeDiscount * (1 - discount);

                lblResult.Text = $"Сума до відшкодування: {totalCost:F2} грн";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка! Перевірте введені дані.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
