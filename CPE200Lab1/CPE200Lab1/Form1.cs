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
        string operand;
        bool operandStatus = false,typeNext=false;

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (operandStatus)
            {
                secondNumber = double.Parse(lblDisplay.Text);
                if (operand == "+")
                {
                    double answer = firstNumber + secondNumber;
                    lblDisplay.Text = answer.ToString();
                }
                else if (operand == "-")
                {
                    double answer = firstNumber - secondNumber;
                    lblDisplay.Text = answer.ToString();
                }
                else if (operand == "X")
                {
                    double answer = firstNumber * secondNumber;
                    lblDisplay.Text = answer.ToString();
                }
                else if (operand == "÷")
                {
                    double answer = firstNumber / secondNumber;
                    lblDisplay.Text = answer.ToString();
                }
            }
            operandStatus = false;
        }

        private void num_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0"||typeNext) lblDisplay.Text = "";
            if (lblDisplay.Text.Length < 8) lblDisplay.Text += btn.Text;
            typeNext = false;
        }
        
        private void btnPercent_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = ((double.Parse(lblDisplay.Text))*firstNumber / 100).ToString();
        }

        private void Operand_Click(object sender, EventArgs e)
        {
            if (!operandStatus)
            {
                Button btn = (Button)sender;
                operand = btn.Text;
                firstNumber = double.Parse(lblDisplay.Text);
                operandStatus = true;
                typeNext = true;
            }
        }
        
    }
}