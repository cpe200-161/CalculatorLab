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
        public Form1()
        {
            InitializeComponent();
        }

        double firstNumber, secondNumber;
        string oper;
        bool isDisplay = false;

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (oper == "+")
            {
                secondNumber = double.Parse(lblDisplay.Text);
                lblDisplay.Text = (firstNumber + secondNumber).ToString();
            }
            else if (oper == "-")
            {
                secondNumber = double.Parse(lblDisplay.Text);
                lblDisplay.Text = (firstNumber - secondNumber).ToString();
            }
            else if (oper == "*")
            {
                secondNumber = double.Parse(lblDisplay.Text);
                lblDisplay.Text = (firstNumber * secondNumber).ToString();
            }
            else if (oper == "/")
            {
                secondNumber = double.Parse(lblDisplay.Text);
                lblDisplay.Text = (firstNumber / secondNumber).ToString();
            }
        }
        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || isDisplay)
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
            isDisplay = false;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            oper = "-";
            ConvertFirstNumber();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            oper = "*";
            ConvertFirstNumber();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            oper = "/";
            ConvertFirstNumber();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = ((double.Parse(lblDisplay.Text)) * (firstNumber / 100)).ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            oper = "+";
            ConvertFirstNumber();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            isDisplay = true;
        }

        private void ConvertFirstNumber()
        {
            firstNumber = double.Parse(lblDisplay.Text);
            isDisplay = true;
        }
    }
}