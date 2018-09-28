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
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        private RPNCalculatorEngine engine;

        public ExtendForm()
        {
            InitializeComponent();
            engine = new RPNCalculatorEngine();
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
            try
            {
                if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2]))
                {
                    if (lblDisplay.Text.Last() != ' ')
                    {
                        lblDisplay.Text += " " + ((Button)sender).Text + " ";
                        isSpaceAllowed = false;
                    }
                    else
                    {
                        lblDisplay.Text += ((Button)sender).Text + " ";
                        isSpaceAllowed = false;
                    }
                }
                if (((Button)sender).Text == "%" && engine.GetType().Name == "CalculatorEngine")//เพิ่มมา %
                {
                    double result;
                    int index1, index2;
                    index1 = lblDisplay.Text.LastIndexOfAny("+-X÷".ToCharArray());
                    index2 = lblDisplay.Text.LastIndexOfAny("%".ToCharArray());
                    result = Convert.ToDouble(lblDisplay.Text.Substring(index1 + 1, index2 - index1 - 1));
                    result = result * 0.01;
                    lblDisplay.Text = lblDisplay.Text.Substring(0, index1 + 1) + " " + result.ToString();
                    if (index1 < 0)
                    {
                        lblDisplay.Text = "0";
                    }
                    if (result.ToString().IndexOf(".") >= 0)
                    {
                        isContainDot = true;
                    }
                }
            }
            catch(Exception er)
            {
                Console.WriteLine(er.ToString());
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
            try
            {
                if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
                {
                    lblDisplay.Text = current.Substring(0, current.Length - 3);
                }
                else
                {
                    lblDisplay.Text = current.Substring(0, current.Length - 1);
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.ToString());
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
                string result = engine.calculate(lblDisplay.Text);
                if (result is "E")
                {
                    lblDisplay.Text = "Error";
                } else
                {
                    lblDisplay.Text = result;
                }
                //เพิ่มมา
                if (lblDisplay.Text.IndexOf(".") >= 0)
                {
                    isContainDot = true;
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
            if(!isContainDot)
            {
                isContainDot = true;
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

        //เพิ่มมา
        private void btnSingleOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (engine.GetType().Name == "CalculatorEngine")
            {
                lblDisplay.Text = engine.Calculate(((Button)sender).Text, lblDisplay.Text);
                if (lblDisplay.Text.IndexOf(".") >= 0)
                {
                    isContainDot = true;
                }
            }
            else
            {
                if (lblDisplay.Text.Last() != ' ')
                {
                    lblDisplay.Text += " " + ((Button)sender).Text + " ";
                    isSpaceAllowed = false;
                }
                else
                {
                    lblDisplay.Text += ((Button)sender).Text + " ";
                    isSpaceAllowed = false;
                }
            }
        }
    }
}
