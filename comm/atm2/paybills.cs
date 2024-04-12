﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace atm2
{
    public partial class paybills : Form
    {
        int accountBalance = GlobalVariables.GlobalIntVariable;
        private int withdrawalAmount = 0;

        public paybills()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BillsBox_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            this.Hide();
            Form2.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            if (comboBox1.SelectedItem == "Electric")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Angeles Electric Corporation (AEC)");
                comboBox2.Items.Add("San Fernando Electric Light and Power Company (SFELAPCO)");
                comboBox2.Items.Add("Mabalacat Electric Corporation (MECO)");
                comboBox2.Items.Add("Apalit Electric Corporation (APEC)");
            }
            if (comboBox1.SelectedItem == "Water")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Pampanga Water District (PAMWD)");
                comboBox2.Items.Add("Angeles Water District (AWD)");
                comboBox2.Items.Add("San Fernando Water District (SFWMD)");
                comboBox2.Items.Add("Mabalacat City Water District (MCWD)");
            }
            if (comboBox1.SelectedItem == "Credit Card")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Land Bank of the Philippines (Landbank)");
                comboBox2.Items.Add("Philippine National Bank (PNB)");
                comboBox2.Items.Add("Development Bank of the Philippines (DBP)");
                comboBox2.Items.Add("Security Bank Corporation");
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                withdrawalAmount = int.Parse(guna2TextBox1.Text);
            }
            catch
            {
                withdrawalAmount = 0;
            }

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Press Ok again to Confirm?", "Confirm?", MessageBoxButtons.YesNoCancel);
            // (Start) if yes run the function 
            if (result == DialogResult.Yes)
            {

                //check if withdrawalamount is enough
                if (withdrawalAmount > accountBalance)
                {
                    MessageBox.Show("Not enough money", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (withdrawalAmount <= 0)
                {
                    MessageBox.Show("Please enter an amount greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                GlobalVariables.GlobalIntVariable -= withdrawalAmount;

                var receipt = MessageBox.Show("Would you like a receipt", "Dispensing!", MessageBoxButtons.YesNo);
                if (receipt == DialogResult.Yes)
                {
                    Receipt Receipt = new Receipt();


                    Receipt.TransactionType = "Amount Paid : ";
                    Receipt.Amount = withdrawalAmount;

                    if (comboBox2.SelectedItem != null)
                    {
                        string selectedCompany = comboBox2.SelectedItem.ToString();
                        Receipt.Issuer = selectedCompany;
                        Receipt.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please select the company for the corresponding bill type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    
                    

                    


                    

                }
            }
        }
    }
}
