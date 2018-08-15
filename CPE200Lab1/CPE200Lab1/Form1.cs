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
        //bool isStartSecondOperand = false;
        bool plus = false;
        bool minus = false;
        bool muti = false;
        bool divide = false;

        string result = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (setfirstOperand == true)
            {
                lblDisplay.Text = "";
            //    isStartSecondOperand = false;
                setfirstOperand = false;
            }

            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (firstOperand != null)
            {
                secondOperand = lblDisplay.Text;
                result = (float.Parse(firstOperand) + float.Parse(secondOperand)).ToString();
                lblDisplay.Text = result;
                firstOperand = result;
            }
            else
            {
                firstOperand = lblDisplay.Text;
                setfirstOperand = true;
            }
            plus = true;
            minus = false;
            muti = false;
            divide = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            secondOperand = lblDisplay.Text;
            if (plus == true)
            {
                result = (float.Parse(firstOperand) + float.Parse(secondOperand)).ToString();
            }
            else if(minus == true)
            {
                result = (float.Parse(firstOperand) - float.Parse(secondOperand)).ToString();
            }
            else if(muti == true)
            {
                result = (float.Parse(firstOperand) * float.Parse(secondOperand)).ToString();
            }
            else if(divide == true)
            {
                result = (float.Parse(firstOperand) / float.Parse(secondOperand)).ToString();
            }
            lblDisplay.Text = result;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            firstOperand = null;
            secondOperand = null;
            setfirstOperand = false;
            //    isStartsecondOperand = false;

            plus = false;
            minus = false;
            muti = false;
            divide = false;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (setfirstOperand == true)
            {
                secondOperand = lblDisplay.Text;
                firstOperand = (float.Parse(firstOperand) / float.Parse(secondOperand)).ToString();
            }
            else
            {
                firstOperand = lblDisplay.Text;
                setfirstOperand = true;
            }
            plus = false;
            minus = false;
            muti = false;
            divide = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (setfirstOperand == true)
            {
                secondOperand = lblDisplay.Text;
                firstOperand = (float.Parse(firstOperand) * float.Parse(secondOperand)).ToString();
            }
            else
            {
                firstOperand = lblDisplay.Text;
                setfirstOperand = true;
            }
            plus = false;
            minus = false;
            muti = true;
            divide = false;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (setfirstOperand == true)
            {
                secondOperand = lblDisplay.Text;
                firstOperand = (float.Parse(firstOperand) - float.Parse(secondOperand)).ToString();
            }
            else
            {
                firstOperand = lblDisplay.Text;
                setfirstOperand = true;
            }
            plus = false;
            minus = true;
            muti = false;
            divide = false;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(lblDisplay.Text)/100).ToString();
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
