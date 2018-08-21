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
        string firstOperand = null;
        string secondOperand = null;

        bool setfirstOperand = false;
        bool isStartSecondOperand = false;
        bool plus = false;
        bool minus = false;
        bool mutiple = false;
        bool divide = false;
        bool equal = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void calculator()
        {
            if (isStartSecondOperand == true)
            {
                secondOperand = lblDisplay.Text;
                if (plus == true)
                {
                    firstOperand = (float.Parse(firstOperand) + float.Parse(secondOperand)).ToString();
                }
                else if (minus == true)
                {
                    firstOperand = (float.Parse(firstOperand) - float.Parse(secondOperand)).ToString();
                }
                else if (mutiple == true)
                {
                    firstOperand = (float.Parse(firstOperand) * float.Parse(secondOperand)).ToString();
                }
                else if (divide == true)
                {
                    firstOperand = (float.Parse(firstOperand) / float.Parse(secondOperand)).ToString();
                }
                lblDisplay.Text = firstOperand;
            }
            else
            {
                firstOperand = lblDisplay.Text;
            }

        }

        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || equal == true)
            {
                lblDisplay.Text = "";
                equal = false;
            }
            if (setfirstOperand == true)
            {
                lblDisplay.Text = "";
                isStartSecondOperand = true;
                setfirstOperand = false;
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            calculator();

            lblDisplay.Text = firstOperand;
            setfirstOperand = true;
            plus = true;
            minus = false;
            mutiple = false;
            divide = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            calculator();

            plus = false;
            minus = false;
            mutiple = false;
            divide = false;
            firstOperand = null;
            secondOperand = null;
            setfirstOperand = false;
            isStartSecondOperand = false;
            equal = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            firstOperand = null;
            secondOperand = null;
            setfirstOperand = false;
            isStartSecondOperand = false;

            plus = false;
            minus = false;
            mutiple = false;
            divide = false;
            equal = false;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            calculator();

            lblDisplay.Text = firstOperand;
            setfirstOperand = true;
            plus = false;
            minus = false;
            mutiple = false;
            divide = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            calculator();

            lblDisplay.Text = firstOperand;
            setfirstOperand = true;
            plus = false;
            minus = false;
            mutiple = true;
            divide = false;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            calculator();

            lblDisplay.Text = firstOperand;
            setfirstOperand = true;
            plus = false;
            minus = true;
            mutiple = false;
            divide = false;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(firstOperand) * float.Parse(lblDisplay.Text) / 100).ToString();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(lblDisplay.Text) * (-1)).ToString();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Contains('.') == false)
            {
                lblDisplay.Text += ".";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length == 1)
            {
                lblDisplay.Text = "0";
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            }
        }

    }
}
