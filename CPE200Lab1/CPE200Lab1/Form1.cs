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
        string operation = string.Empty;
        double result = 0.0;
        bool flag_percent = false;
        bool flag_equal = false;
        bool flag_operation = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (flag_equal == true)
            {
                input = string.Empty;
                num1 = string.Empty;
                num2 = string.Empty;
                result = 0;
                this.lblDisplay.Text = "0";
                flag_equal = false;
                flag_percent = false;
            }
            if(flag_operation == true)
            {
                this.lblDisplay.Text = "0";
            }
            if (this.lblDisplay.Text == "0")
            {
                this.lblDisplay.Text = string.Empty;
            }
            if(btn.Text == ".")
            {
                if(!input.Contains(".") && !this.lblDisplay.Text.Contains("."))
                {
                    this.lblDisplay.Text += btn.Text;
                    input += btn.Text;
                }

            }
            else
            {
                input += btn.Text;
                this.lblDisplay.Text += btn.Text;
            }  
        }
        private void btnOperator_Click(object sender, EventArgs e)
        {
            this.lblDisplay.Text = "0";
            
            if (flag_operation == false)
            {
                Button btn = (Button)sender;
                operation = btn.Text;
                num1 = input;
                input = string.Empty;
                flag_equal = false;
                flag_operation = true;
            }
            else
            {
                num2 = input;
                
                if (operation == "+")
                {
                    result = Convert.ToDouble(num1) + Convert.ToDouble(num2);
                }
                else if (operation == "-")
                {
                    result = Convert.ToDouble(num1) - Convert.ToDouble(num2);
                }
                else if (operation == "X")
                {
                    result = Convert.ToDouble(num1) * Convert.ToDouble(num2);
                }
                else if (operation == "÷")
                {
                    result = Convert.ToDouble(num1) / Convert.ToDouble(num2);
                }
                input = result.ToString();
                num1 = result.ToString();
                this.lblDisplay.Text = result.ToString();
                input = string.Empty;
                num2 = string.Empty;
                Button btn = (Button)sender;
                operation = btn.Text;
            }

        }
        
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if(flag_percent == true)
            {
                num2 = ((Convert.ToDouble(input) * Convert.ToDouble(num1)) / 100).ToString();
            }
            else if(flag_percent == false && flag_equal == false)
            {
                num2 = input;
            }
            
            if (operation == "+")
            {
                result = Convert.ToDouble(num1) + Convert.ToDouble(num2);
            }
            else if (operation == "-")
            {
                result = Convert.ToDouble(num1) - Convert.ToDouble(num2);
            }
            else if (operation == "X")
            {
                result = Convert.ToDouble(num1) * Convert.ToDouble(num2);
            }
            else if (operation == "÷")
            {
                result = Convert.ToDouble(num1) / Convert.ToDouble(num2);
            }
            input = result.ToString();
            num1 = result.ToString();
            this.lblDisplay.Text = result.ToString();
            flag_equal = true;
            flag_percent = false;
            flag_operation = false;
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            input = string.Empty;
            num1 = string.Empty;
            num2 = string.Empty;
            result = 0;
            this.lblDisplay.Text = "0";
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            
            if(num1 == string.Empty)
            {
                input = string.Empty;
                num1 = string.Empty;
                num2 = string.Empty;
                result = 0;
                this.lblDisplay.Text = "0";
                flag_percent = false;
            }
            else
            {
                flag_percent = true;
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }
    }
}
