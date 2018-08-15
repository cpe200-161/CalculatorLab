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
        string firstOperand, secondOperand, format, result;
        bool setFirstOperand = false, setDot = false, setAns = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(lblDisplay.Text) * (-1)).ToString();
        }

        private void btnx_Click(object sender, EventArgs e)
        {


            Button btn = (Button)sender;

            if (lblDisplay.Text == "0" || setFirstOperand == true || setAns == true)
            {
                lblDisplay.Text = "";
                setFirstOperand = false;
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
            setAns = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (setAns == true)
            {
                lblDisplay.Text = "0";
            }
            if (setDot == false)
            {
                lblDisplay.Text += ".";
            }
            setDot = true;
            setAns = false;
        }

         private void Calc_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            setFirstOperand = true;
            setDot = false;
            setAns = false;

            Button btn = (Button)sender;
            if (btn.Text == "+") format = "plus";
            else if (btn.Text == "-") format = "minus";
            else if (btn.Text == "X") format = "multi";
            else if (btn.Text == "÷") format = "divide";
        }


        private void btnEqual_Click(object sender, EventArgs e)
        {
            secondOperand = lblDisplay.Text;
            if (format == "plus") result = (float.Parse(firstOperand) + float.Parse(secondOperand)).ToString();
            else if(format == "minus") result = (float.Parse(firstOperand) - float.Parse(secondOperand)).ToString();
            else if (format == "multi") result = (float.Parse(firstOperand) * float.Parse(secondOperand)).ToString();
            else if (format == "divide") result = (float.Parse(firstOperand) / float.Parse(secondOperand)).ToString();

            lblDisplay.Text = result;
            setAns = true;
            setDot = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "0" || setFirstOperand == true) lblDisplay.Text = "0";
            firstOperand = "0";
            secondOperand = "0";
            setDot = false;
            setFirstOperand = false;
            setAns = false;
        }
    }
}
