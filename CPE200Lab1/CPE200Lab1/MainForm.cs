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
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string prev_operate;
        private string operate;
        CalculatorEngine cal;
        private string secondOperand;
        private string result = "0";
        private double mem;
        private double allmem;

        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
        }
        
        public MainForm()
        {
            InitializeComponent();
            cal = new CalculatorEngine();
            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if(lblDisplay.Text.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if(lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            prev_operate = operate;
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    double sumpercent;
                    double resultper = double.Parse(firstOperand);
                    sumpercent = double.Parse(lblDisplay.Text);
                    sumpercent = double.Parse(firstOperand) * (sumpercent / 100.00);
                    lblDisplay.Text = sumpercent.ToString();
                    break;
                // your code here
                case "1/X":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    result = cal.calculate(operate,firstOperand,secondOperand,prev_operate);
                    lblDisplay.Text = result;
                    operate = prev_operate;
                    break;
                case "√":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    result = cal.calculate(operate, firstOperand, secondOperand, prev_operate);
                    lblDisplay.Text = result;
                    operate = prev_operate;
                    break;
            }
            isAllowBack = false;
        }

        private void btnMemory_Click(object sender, EventArgs e)
        {
            string member = ((Button)sender).Text;
            switch (member)
            {
                case "M+":
                    mem = double.Parse(lblDisplay.Text);
                    allmem = allmem + mem;
                    break;
                case "M-":
                    mem = double.Parse(lblDisplay.Text);
                    allmem = allmem - mem;
                    break;
                case "MS":
                    mem = double.Parse(lblDisplay.Text);
                    allmem = mem;
                    break;
                case "MR":
                    lblDisplay.Text = (allmem).ToString();
                    break;
                case "MC":
                    allmem = mem = 0;
                    break;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            
            secondOperand = lblDisplay.Text;
            result = cal.calculate(operate, firstOperand, secondOperand,prev_operate);
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            isAfterEqual = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if(lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            } else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if(lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if(rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if(lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }
    }
}
