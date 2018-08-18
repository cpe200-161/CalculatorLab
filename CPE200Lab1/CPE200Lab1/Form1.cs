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
        double FirstNumber;
        double SecondNumber;
        String Operator;
        bool Check = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                if ((Operator == "+" || Operator == "-" || Operator == "*" || Operator == "/") && Check == true)
                {
                    lblDisplay.Text = btn.Text;
                    Check = false;
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + btn.Text;
                }
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            btnDot.Enabled = true;
            FirstNumber = Convert.ToDouble(lblDisplay.Text);
            Operator = "+";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            btnDot.Enabled = true;
            FirstNumber = Convert.ToDouble(lblDisplay.Text);
            Operator = "-";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            btnDot.Enabled = true;
            FirstNumber = Convert.ToDouble(lblDisplay.Text);
            Operator = "*";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            btnDot.Enabled = true;
            FirstNumber = Convert.ToDouble(lblDisplay.Text);
            Operator = "/";
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }
            btnDot.Enabled = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            btnDot.Enabled = true;
            double Result;
            Check = true;
            SecondNumber = Convert.ToDouble(lblDisplay.Text);
            if (Operator == "+")
            {
                Result = (FirstNumber + SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            else if (Operator == "-")
            {
                Result = (FirstNumber - SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            else if (Operator == "*")
            {
                Result = (FirstNumber * SecondNumber);
                lblDisplay.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            else if (Operator == "/")
            {
                if (SecondNumber == 0)
                {
                    lblDisplay.Text = "หาร 0 ไม่ได้";
                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    lblDisplay.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Check = true;
            lblDisplay.Text = "0";
            Operator = "";
            btnDot.Enabled = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            double PercentResult;
            double PercentNum = Convert.ToDouble(lblDisplay.Text);
            PercentResult = (FirstNumber * PercentNum)/100;
            lblDisplay.Text = Convert.ToString(PercentResult);
            SecondNumber = PercentResult;
        }
    }
}
