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
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string oper;
        private double memory;
        string newOper;
        string secondOperand;
        private CalculatorEngine myEngine;

        private void resetAll()
        {
            lblDisplay.Text = "0";
            secondOperand = null;
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
        }

        public MainForm()
        {
            InitializeComponent();
            memory = 0;
            myEngine = new CalculatorEngine();
            resetAll();
        }

        private void number_Click(object sender, EventArgs e)
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
            lblDisplay.Text +=digit;
            isAfterOperater = false;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            if(firstOperand != null&& isAfterEqual==false)
            {
                 secondOperand= lblDisplay.Text;

            }
            oper = ((Button)sender).Text;
            if (oper != "%")
            {
                newOper = ((Button)sender).Text;
            }
            switch (oper)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "√":
                case "1/X":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    break;
            }
            if (isAfterEqual)
            {
                firstOperand = lblDisplay.Text;
                isAfterEqual = false;
            }else
            {
                string result;
                if (oper== "1/X"||oper=="%"||oper== "√")
                {
                    result = myEngine.calculate(oper, firstOperand);
                }
                else
                {
                    result = myEngine.calculate(oper, firstOperand, secondOperand);
                }
                
                if (result is "E" || result.Length > 8)
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    lblDisplay.Text = result;
                }
            }
            isAllowBack = false;
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;
            string result = myEngine.calculate(newOper, firstOperand, secondOperand);
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

        private void btnMP_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            memory += Convert.ToDouble(lblDisplay.Text);
            isAfterOperater = true;
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            memory -= Convert.ToDouble(lblDisplay.Text);
            isAfterOperater = true;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "error")
            {
                return;
            }
            lblDisplay.Text = memory.ToString();
        }
    }
}
