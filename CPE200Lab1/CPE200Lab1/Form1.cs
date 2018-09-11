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
        string firstOperand, secondOperand, format, result, temp = null;
        bool setFirstOperand = false, setDot = false, setAns = false, setBackspace = false;
        int setFormat = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(lblDisplay.Text) * (-1)).ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length == 1)
            {
                lblDisplay.Text = "0";
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
            }
        }

        private void btnPercent_Click_1(object sender, EventArgs e)
        {
            secondOperand = lblDisplay.Text;
            result = (float.Parse(firstOperand) * (float.Parse(secondOperand) / 100)).ToString();
            lblDisplay.Text = result;
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
            temp = null;

            Button btn = (Button)sender;

            if (btn.Text == "+")
            {
                format = "plus";
                setFormat += 1;
            }
            else if (btn.Text == "-")
            {
                format = "minus";
                setFormat += 1;
            }
            else if (btn.Text == "X")
            {
                format = "multi";
                setFormat += 1;
            }
            else if (btn.Text == "÷")
            {
                format = "divide";
                setFormat += 1;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            secondOperand = lblDisplay.Text;
            if (temp == null)
            {
                temp = lblDisplay.Text;
            }

            if (format == "plus")
            {
                result = (float.Parse(firstOperand) + float.Parse(secondOperand)).ToString();

            }
            else if (format == "minus")
            {
                result = (float.Parse(firstOperand) - float.Parse(secondOperand)).ToString();

            }
            else if (format == "multi")
            {
                result = (float.Parse(firstOperand) * float.Parse(secondOperand)).ToString();

            }
            else if (format == "divide")
            {
                result = (float.Parse(firstOperand) / float.Parse(secondOperand)).ToString();

            }

            lblDisplay.Text = result;
            firstOperand = temp;
            setAns = true;
            setDot = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "0" || setFirstOperand == true)
            {
                lblDisplay.Text = "0";
            }
            firstOperand = "0";
            secondOperand = "0";
            setDot = false;
            setFirstOperand = false;
            setAns = false;
            temp = null;
        }
    }
}
