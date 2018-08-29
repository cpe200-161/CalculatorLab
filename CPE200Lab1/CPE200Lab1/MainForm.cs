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
        private string secondOperand;
        private string memoryOperand;
        private string operate1;
        private string operate2;
        private string operateM;
        public CalculatorEngine engine;

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
            engine = new CalculatorEngine();
            engine.calculate(operate1, firstOperand, secondOperand, operate2);
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
            operate1 = ((Button)sender).Text;
            if(operate1 != "%")
            {
                operate2 = ((Button)sender).Text;
            }
            switch (operate1)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    secondOperand = lblDisplay.Text;
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
            if (operate1 != "%")
            {
                secondOperand = lblDisplay.Text;
            }

            string result = engine.calculate(operate1, firstOperand, secondOperand, operate2);
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

        private void btnSqrt(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (firstOperand == null)
            {
                firstOperand = lblDisplay.Text;
            }
            else
            {
                secondOperand = lblDisplay.Text;
            }
            string resultSqrt = engine.calculateSqrt(firstOperand, secondOperand);
            if (resultSqrt is "E" || resultSqrt.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = resultSqrt;
            }
        }

        private void btnOneOverX(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (firstOperand == null)
            {
                firstOperand = lblDisplay.Text;
            }
            else
            {
                secondOperand = lblDisplay.Text;
            }
            string resultOverX = engine.calculateOverX(firstOperand, secondOperand);
            if (resultOverX is "E" || resultOverX.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = resultOverX;
            }
        }

        private void buttonMemory_Click(object sender, EventArgs e)
        {
            operateM = ((Button)sender).Text;
            switch (operateM)
            {
                case "MS":
                    memoryOperand = lblDisplay.Text;
                    break;
                case "M+":
                    string resultMemory1 = engine.calculateMemory(memoryOperand, lblDisplay.Text, operateM);
                    memoryOperand = resultMemory1;
                    break;
                case "M-":
                    string resultMemory2 = engine.calculateMemory(memoryOperand, lblDisplay.Text, operateM);
                    memoryOperand = resultMemory2;
                    break;
                case "MR":
                    if (lblDisplay.Text is "Error")
                    {
                        return;
                    }
                    if (isAfterEqual)
                    {
                        resetAll();
                    }
                    lblDisplay.Text = memoryOperand;
                    break;
                case "MC":
                    memoryOperand = "0";
                    break;
            }
        }
    }
}
