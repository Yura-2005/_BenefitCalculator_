using System;
using System.Windows.Forms;

namespace BenefitCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string category = cmbCategory.SelectedItem.ToString();
                int familyMembers = int.Parse(txtFamilyMembers.Text);
                double electricity = double.Parse(txtElectricity.Text);
                double gas = double.Parse(txtGas.Text);
                double water = double.Parse(txtWater.Text);

                double discount = 0;
                if (category == "Одинокий інвалід")
                    discount = 1.0; // 100%
                else if (category == "Особа з інвалідністю (50%)")
                    discount = 0.5; // 50%
                else if (category == "Ветеран УПА (75%)")
                    discount = 0.25; // 75%

                // double totalBeforeDiscount = (electricity * 1.44) + (gas * 7) + (water * 10) + (area * 20);
                // double totalCost = totalBeforeDiscount * (1 - discount);

                double totalBeforeDiscount = (electricity * 4.32) + (gas * 8) + (water * 90);

                double totalCost;
                if (discount == 1.0)
                {
                    totalCost = totalBeforeDiscount; // Повне повернення коштів
                }
                else
                {
                    totalCost = totalBeforeDiscount * (1 - discount);
                }

                lblResult.Text = $"Сума до відшкодування: {totalCost:F2} грн";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка! Переконайтесь, що введені дані правильні.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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