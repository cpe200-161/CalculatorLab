﻿using System;
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
        bool CheckDot = true;
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
                if ((Operator == "+" || Operator == "-" || Operator == "*" || Operator == "/") && CheckDot == true)
                {
                    lblDisplay.Text = btn.Text;
                    CheckDot = false;
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
            CheckDot = true;
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
                lblDisplay.Text = Result.ToString("G8");
                FirstNumber = Result;
            }
            else if (Operator == "/")
            {
                if (SecondNumber == 0)
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    string ResultCheck = String.Format("{0:G}", Result);
                    if (Result % 1 == 0)
                    {
                        lblDisplay.Text = String.Format("{0:0}", Result);
                    }
                    else if(ResultCheck.Length >= 6)
                    {
                        lblDisplay.Text = String.Format("{0:F6}", Result);
                    }
                    else
                    {
                        lblDisplay.Text = String.Format("{0:G}", Result);
                    }
                    FirstNumber = Result;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CheckDot = true;
            lblDisplay.Text = "0";
            Operator = "";
            btnDot.Enabled = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            double PercentResult;
            double PercentNum = Convert.ToDouble(lblDisplay.Text);
            if(FirstNumber == 0)
            {
                PercentResult = PercentNum/ 100;
            }
            else
            {
                PercentResult = (FirstNumber * PercentNum) / 100;
            }
            lblDisplay.Text = Convert.ToString(PercentResult);
            SecondNumber = PercentResult;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text.Length > 1)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            }
            else
            {
                lblDisplay.Text = "0";
            }
        }
    }
}
