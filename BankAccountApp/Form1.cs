using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class Form1 : Form

    {
        List<BankAccount> AllAccount = new List<BankAccount>();
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;


            BankAccount bankaccount = new BankAccount(textBox1.Text);
            
            AllAccount.Add(bankaccount);
            RefreshGrid();
            MessageBox.Show("Account Create Succesfully");
        } 

        public void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AllAccount;
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankAccount SelectAcc = dataGridView1.SelectedRows[0].DataBoundItem as BankAccount;
            SelectAcc.Balance += numericUpDown1.Value;
            RefreshGrid();
            numericUpDown1.Value = 0;
            MessageBox.Show("Deposit Succesfully", "My Pop-up1", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BankAccount SelectAcc = dataGridView1.SelectedRows[0].DataBoundItem as BankAccount;

            if (numericUpDown1.Value > SelectAcc.Balance)
            {
                MessageBox.Show("Insufficient balance!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SelectAcc.Balance -= numericUpDown1.Value;
                RefreshGrid();
                numericUpDown1.Value = 0;
                MessageBox.Show("Withdraw Successfully", "My Pop-up", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
