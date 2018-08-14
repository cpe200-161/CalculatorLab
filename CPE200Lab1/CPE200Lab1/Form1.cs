using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        string input = string.Empty;
        string num1 = string.Empty;
        string num2 = string.Empty;
        char operation;
        double result = 0.0;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            this.lblDisplay.Text = "";
            input += btn.Text;
            this.lblDisplay.Text += input;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            num1 = input;
            operation = '+';
            input = string.Empty;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            num1 = input;
            operation = '-';
            input = string.Empty;

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            num1 = input;
            operation = '*';
            input = string.Empty;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            num1 = input;
            operation = '/';
            input = string.Empty;
        }
        
        
        private void btnEqual_Click(object sender, EventArgs e)
        {
            num2 = input;
            if (operation == '+')
            {
                result = Convert.ToDouble(num1) + Convert.ToDouble(num2);
            }else if (operation == '-')
            {
                result = Convert.ToDouble(num1) - Convert.ToDouble(num2);
            }
            else if (operation == '*')
            {
                result = Convert.ToDouble(num1) * Convert.ToDouble(num2);
            }
            else if (operation == '/')
            {
                result = Convert.ToDouble(num1) / Convert.ToDouble(num2);
            }
            
            input = string.Empty;
            this.lblDisplay.Text = result.ToString();
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            input = string.Empty;
            num1 = string.Empty;
            num2 = string.Empty;
            result = 0;
            this.lblDisplay.Text = "0";
        }
    }
}
