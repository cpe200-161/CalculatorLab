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
        private string operate;
        private string memory;
        private string secondOperand;
        private string checkoperate;
        private CalculatorEngine engine;

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

            resetAll();
            //1.new calcultorEngine() => instantiate an object;
            //2.reference to that object with engine variable
            engine = new CalculatorEngine();
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
            operate = ((Button)sender).Text;
            
                switch (operate)
                {
                case "+":
                case "-":
                case "X":
                case "÷":
                    checkoperate = operate;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                case "√":
                case "1/x":
                    secondOperand = lblDisplay.Text;
                    lblDisplay.Text = engine.calculate(operate, firstOperand, secondOperand, memory);
                    isAfterOperater = true;
                    break;
                case "MC":
                    memory = "0";
                    isAfterOperater = true;
                    break;
                case "MS":
                case "M+":
                case "M-":
                case "MR":
                    secondOperand = lblDisplay.Text;
                    memory = lblDisplay.Text =  engine.calculate(operate, firstOperand, secondOperand, memory);
                    isAfterOperater = true;
                    break;

            }
            
            isAllowBack = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            secondOperand = lblDisplay.Text;
            string result = engine.calculate(checkoperate, firstOperand, secondOperand,memory);
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

        private void buttonX_Click(object sender, EventArgs e)
        {
            firstOperand=lblDisplay.Text;
            lblDisplay.Text= (1/Convert.ToDouble(firstOperand)).ToString();
        }

        private void buttonsqrt_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            lblDisplay.Text = (Math.Sqrt( Convert.ToDouble(firstOperand))).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
        }
    }
}
