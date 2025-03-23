﻿namespace BenefitCalculator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblFamilyMembers;
        private System.Windows.Forms.TextBox txtFamilyMembers;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label lblElectricity;
        private System.Windows.Forms.TextBox txtElectricity;
        private System.Windows.Forms.Label lblGas;
        private System.Windows.Forms.TextBox txtGas;
        private System.Windows.Forms.Label lblWater;
        private System.Windows.Forms.TextBox txtWater;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResult;
        
        private void InitializeComponent()
        {
            int labelWidth = 180;
            int inputWidth = 150;
            int startX = 10;
            int inputX = startX + labelWidth + 10;
            int rowHeight = 30;
            
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblFamilyMembers = new System.Windows.Forms.Label();
            this.txtFamilyMembers = new System.Windows.Forms.TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.lblElectricity = new System.Windows.Forms.Label();
            this.txtElectricity = new System.Windows.Forms.TextBox();
            this.lblGas = new System.Windows.Forms.Label();
            this.txtGas = new System.Windows.Forms.TextBox();
            this.lblWater = new System.Windows.Forms.Label();
            this.txtWater = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            
            // Labels and Inputs
            System.Windows.Forms.Label[] labels = { lblCategory, lblFamilyMembers, lblElectricity, lblGas, lblWater };
            System.Windows.Forms.Control[] inputs = { cmbCategory, txtFamilyMembers, txtElectricity, txtGas, txtWater };
            
            string[] labelTexts = {
                "Категорія пільговика:", "Кількість членів сім'ї:",
                "Витрати електроенергії (кВт):", "Витрати газу (м³):", "Витрати води (м³):"
            };
            
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = labelTexts[i];
                labels[i].Location = new System.Drawing.Point(startX, 10 + i * rowHeight);
                labels[i].Size = new System.Drawing.Size(labelWidth, 20);
                labels[i].AutoSize = false;
                
                inputs[i].Location = new System.Drawing.Point(inputX, 10 + i * rowHeight);
                inputs[i].Size = new System.Drawing.Size(inputWidth, 22);
            }
            
            this.cmbCategory.Items.AddRange(new object[] { "Одинокий інвалід", "Ветеран УПА (75%)", "Особа з інвалідністю (50%)" });
            
            // Buttons
            this.btnCalculate.Text = "Розрахувати";
            this.btnCalculate.Location = new System.Drawing.Point(startX, 200);
            this.btnCalculate.Size = new System.Drawing.Size(100, 30);
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            
            this.btnClear.Text = "Очистити";
            this.btnClear.Location = new System.Drawing.Point(inputX, 200);
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            

            
            // Result label
            this.lblResult.Location = new System.Drawing.Point(startX, 240);
            this.lblResult.Size = new System.Drawing.Size(300, 30);
            
            // Form1 settings
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.AddRange(labels);
            this.Controls.AddRange(inputs);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblResult);
            this.Text = "Розрахунок пільг";
            this.ResumeLayout(false);
        }
    }
}