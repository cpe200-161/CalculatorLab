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
        String Operator;
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
                if (Operator == "+" || Operator == "-" || Operator == "*" || Operator == "/")
                {
                    lblDisplay.Text = btn.Text;
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + btn.Text;
                }
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(lblDisplay.Text);
            Operator = "+";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(lblDisplay.Text);
            Operator = "-";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(lblDisplay.Text);
            Operator = "*";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(lblDisplay.Text);
            Operator = "/";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            double SecondNumber;
            double Result;

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
                    lblDisplay.Text = "คูณ 0 ไม่ได้";
                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    lblDisplay.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                }
            }
        }
    }
}
