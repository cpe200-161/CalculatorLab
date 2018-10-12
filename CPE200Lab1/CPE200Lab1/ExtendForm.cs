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
    public partial class ExtendForm : Form
    {
        private string firstOperand;
        protected string operate;
        private bool isNumberPart = false;
        protected bool isContainDot = false;
        private bool isSpaceAllowed = false;
        private CalculatorEngine engine;
        protected RPNCalculatorEngine RPNengine;

        public ExtendForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            RPNengine = new RPNCalculatorEngine();
        }

        public bool isOperator(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case '*':
                case '÷':
                case '%':
                case '√':

                    return true;
            }
            return false;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            lblDisplay.Text += ((Button)sender).Text;
            isSpaceAllowed = true;
        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            string current = lblDisplay.Text;
            if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2]))
            {
                lblDisplay.Text += " " + ((Button)sender).Text + " ";
                isSpaceAllowed = false;
            }
        }

        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            operate = ((Button)sender).Text;
            if (lblDisplay.Text.Length <= 1)
            {
                firstOperand = lblDisplay.Text;
            }

            string result = engine.calculate(operate, firstOperand);
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                isNumberPart = false;
                isContainDot = false;
                string current = lblDisplay.Text;
                if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2]))
                {
                    lblDisplay.Text += " " + ((Button)sender).Text + " ";
                    isSpaceAllowed = false;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            // check if the last one is operator
            string current = lblDisplay.Text;
            if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
            {
                lblDisplay.Text = current.Substring(0, current.Length - 3);
            }
            else
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
            }
            if (lblDisplay.Text is "")
            {
                lblDisplay.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                string result = engine.Process(lblDisplay.Text);
                    if (result is "E")
                {
                result = RPNengine.Process(lblDisplay.Text);
                    if (result is "E")
                {
                    lblDisplay.Text = "Error";
                }
                else lblDisplay.Text = result;
                return;
                }
                    lblDisplay.Text = result;
                }
            catch
            {
                lblDisplay.Text = lblDisplay.Text;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isNumberPart)
            {
                return;
            }
            string current = lblDisplay.Text;
            if (current is "0")
            {
                lblDisplay.Text = "-";
            }
            else if (current[current.Length - 1] is '-')
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "")
                {
                    lblDisplay.Text = "0";
                }
            }
            else
            {
                lblDisplay.Text = current + "-";
            }
            isSpaceAllowed = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (!isContainDot)
            {
                isContainDot = true;
                lblDisplay.Text += ".";
                isSpaceAllowed = false;
            }
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isSpaceAllowed)
            {
                lblDisplay.Text += " ";
                isSpaceAllowed = false;
            }
        }

        double memory = 0;
        string type;
        private void btnMemory_Click(object sender, EventArgs e)
        {
            type = ((Button)sender).Text;
            switch (type)
            {
                case "MC":
                    memory = 0;
                    lblDisplay.Text = "0";
                    break;
                case "MR":
                    lblDisplay.Text = Convert.ToString(memory);
                    break;
                case "MS":
                    memory = Convert.ToDouble(lblDisplay.Text);
                    lblDisplay.Text = "0";
                    break;
                case "M+":
                    memory += Convert.ToDouble(lblDisplay.Text);
                    lblDisplay.Text = "0";
                    break;
                case "M-":
                    memory -= Convert.ToDouble(lblDisplay.Text);
                    lblDisplay.Text = "0";
                    break;
            }
        }

    }
           
}