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

        public string text = null;

        private double num1 = 0;
        private double num2 = 0;
        private double result = 0;

        private char opperater;

        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            result = 0;
            this.lblDisplay.Text = "0";
            text = null;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            text += 1;
            this.lblDisplay.Text = text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            text += 2;
            this.lblDisplay.Text = text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            text += 3;
            this.lblDisplay.Text = text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            text += 4;
            this.lblDisplay.Text = text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            text += 5;
            this.lblDisplay.Text = text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            text += 6;
            this.lblDisplay.Text = text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            text += 7;
            this.lblDisplay.Text = text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            text += 8;
            this.lblDisplay.Text = text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            text += 9;
            this.lblDisplay.Text = text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if(text != null)
            {
                text += 0;
                this.lblDisplay.Text = text;
            }
            else
            {
                this.lblDisplay.Text = "0";
            }
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(text);
            result += num1;
            text = null;
            opperater = '+';
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(text);
            result += num1;
            text = null;
            opperater = '-';
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(text);
            result = num1;
            text = null;
            opperater = '*';
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(text);
            result /= num1;
            text = null;
            opperater = '/';
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            num2 = Convert.ToDouble(text);
            text = null;
            if(opperater == '+')
            {
                result += num2;
                text = Convert.ToString(result);
                opperater = ' ';
            }
            if (opperater == '-')
            {
                result -= num2;
                text = Convert.ToString(result);
                opperater = ' ';
            }
            if (opperater == '*')
            {
                result *= num2;
                text = Convert.ToString(result);
                opperater = ' ';
            }
            if (opperater == '/')
            {
                result /= num2;
                text = Convert.ToString(result);
                opperater = ' ';
            }
            this.lblDisplay.Text = text;

        }

    }
}
