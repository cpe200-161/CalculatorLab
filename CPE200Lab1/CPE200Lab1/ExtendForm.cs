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
        private bool isNumberPart = false;
        private bool hasDot = false;
        private bool isSpaceAllowed = false;
        private CalculatorEngine engine;
        private RPNCalculatorEngine myEngine;
        private double memory = 0;

        public ExtendForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            myEngine = new RPNCalculatorEngine();
        }

        private bool isOperator(char ch)
        {
            switch(ch) {
                case '+':
                case '-':
                case 'X':
                case '÷':
                case '%':
                    return true;
            }
            return false;
        }

        private void number_Click(object sender, EventArgs e)
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
                hasDot = false;
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
            hasDot = false;
            string current = lblDisplay.Text;
            if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2]))
            {
                lblDisplay.Text += " " + ((Button)sender).Text + " ";
                isSpaceAllowed = false;
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
            } else
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
            hasDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
           try
            {
                string result = engine.calculate(lblDisplay.Text);
                if (result is "E")
                {
                    result = myEngine.calculate(lblDisplay.Text);
                    if (result is "E")
                    {
                        lblDisplay.Text = "Error";
                    }
                    else
                    {
                        lblDisplay.Text = result;
                    }
                }
                else
                {
                    lblDisplay.Text = result;
                }
            }catch
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
            } else if (current[current.Length - 1] is '-')
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "")
                {
                    lblDisplay.Text = "0";
                }
            } else
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
            if(!hasDot)
            {
                hasDot = true;
                lblDisplay.Text += ".";
                isSpaceAllowed = false;
            }
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            if(isSpaceAllowed)
            {
                lblDisplay.Text += " ";
                isSpaceAllowed = false;
            }
        }

        private void btnSingleOperator_Click(object sender, EventArgs e)
        {
            string opt = ((Button)sender).Text;
            string result = engine.Calculate(opt, lblDisplay.Text, 4);
            if (result is "E")
            {
                lblDisplay.Text = "Error";
            }else
            {
                lblDisplay.Text = result;
            }
        }
        private void btnMemory_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string mem = ((Button)sender).Text;
            switch (mem)
            {
                case "MS":
                    memory = (Convert.ToDouble(lblDisplay.Text));
                    lblDisplay.Text = "0";
                    break;
                case "MC":
                    memory = 0;
                    break;
                case "M+":
                    memory = memory + (Convert.ToDouble(lblDisplay.Text));
                    lblDisplay.Text = "0";
                    break;
                case "M-":
                    memory = memory - (Convert.ToDouble(lblDisplay.Text));
                    lblDisplay.Text = "0";
                    break;
                case "MR":
                    lblDisplay.Text = memory.ToString();
                    break;
            }
        }
    }
}
