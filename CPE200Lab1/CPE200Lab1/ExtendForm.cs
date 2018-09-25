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
        private double memMory = 0;
        private RPNCalculatorEngine engine;

        public ExtendForm()
        {
            InitializeComponent();
            engine = new RPNCalculatorEngine();
        }

        private bool isOperator(char str)
        {
            switch (str)
            {
                case '+':
                case '-':
                case 'X':
                case '÷':
                    return true;
            }
            return false;
        }

        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
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

            lblDisplay.Text += " " + ((Button)sender).Text + " ";
            isSpaceAllowed = false;
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
            isSpaceAllowed = true;
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
            string result = engine.Process(lblDisplay.Text);
            if (result is "E")
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            isSpaceAllowed = true;
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

        private void memmory_Cleanr(object sender, EventArgs e)
        {
            memMory = 0;
        }

        private void memory_Show(object sender, EventArgs e)
        {
            if (memMory != 0)
            {
                lblDisplay.Text = memMory.ToString();
                isSpaceAllowed = true;
            }
        }

        private void memory_Save(object sender, EventArgs e)
        {
            memMory = Convert.ToDouble(lblDisplay.Text);
        }

        private void memory_Plus(object sender, EventArgs e)
        {
            memMory += Convert.ToDouble(lblDisplay.Text);
        }

        private void memory_Minus(object sender, EventArgs e)
        {
            memMory -= Convert.ToDouble(lblDisplay.Text);
        }

        private void sQrt_Click(object sender, EventArgs e)
        {
            string[] memBers = lblDisplay.Text.Split(' ');

            if (memBers.Length < 2 && isNumber(memBers[0]))
            {
                lblDisplay.Text = (Math.Sqrt(Convert.ToDouble(memBers[0]))).ToString();
                return;
            }
            else if (memBers.Length >= 2 && isNumber(memBers[memBers.Length - 1]))
            {
                memBers[memBers.Length - 1] = (Math.Sqrt(Convert.ToDouble(memBers[memBers.Length - 1]))).ToString();

                for (int i = 0; i < memBers.Length; i++)
                {
                    if (i == 0)
                    {
                        lblDisplay.Text = memBers[0];
                    }
                    else
                    {
                        lblDisplay.Text += " " + memBers[i];
                    }
                }
                return;
            }
            else
            {
                string result = engine.Process(lblDisplay.Text);
                if (result is "E")
                {
                    lblDisplay.Text = "Error";
                    return;
                }
                else
                {
                    lblDisplay.Text = (Math.Sqrt(Convert.ToDouble(result))).ToString();
                    return;
                }
            }
        }

        private void oneOverx_Click(object sender, EventArgs e)
        {
            string[] memBers = lblDisplay.Text.Split(' ');

            if (memBers.Length < 2 && isNumber(memBers[0]))
            {
                lblDisplay.Text = (1 / Convert.ToDouble(memBers[0])).ToString();
                return;
            }
            else if (memBers.Length >= 2 && isNumber(memBers[memBers.Length - 1]))
            {
                memBers[memBers.Length - 1] = (1 / Convert.ToDouble(memBers[memBers.Length - 1])).ToString();

                for (int i = 0; i < memBers.Length; i++)
                {
                    if (i == 0)
                    {
                        lblDisplay.Text = memBers[0];
                    }
                    else
                    {
                        lblDisplay.Text += " " + memBers[i];
                    }
                }
                return;
            }
            else
            {
                string result = engine.Process(lblDisplay.Text);
                if (result is "E")
                {
                    lblDisplay.Text = "Error";
                    return;
                }
                else
                {
                    lblDisplay.Text = (1 / Convert.ToDouble(result)).ToString();
                    return;
                }
            }
        }

        private void perCen_Click(object sender, EventArgs e)
        {
            string[] memBers = lblDisplay.Text.Split(' ');

            if (memBers.Length < 2 && isNumber(memBers[0]))
            {
                lblDisplay.Text = (Convert.ToDouble(memBers[0]) / 100).ToString();
                return;
            }

            else if (memBers.Length >= 2 && isNumber(memBers[memBers.Length - 1]) && isNumber(memBers[memBers.Length - 2]))
            {
                memBers[memBers.Length - 1] = (Convert.ToDouble(memBers[memBers.Length - 1]) / 100 * Convert.ToDouble(memBers[memBers.Length - 2])).ToString();

                for (int i = 0; i < memBers.Length; i++)
                {
                    if (i == 0)
                    {
                        lblDisplay.Text = memBers[0];
                    }
                    else
                    {
                        lblDisplay.Text += " " + memBers[i];
                    }
                }
                return;
            }
            else
            {
                string result = engine.Process(lblDisplay.Text);
                if (result is "E")
                {
                    lblDisplay.Text = "Error";
                    return;
                }
                else
                {
                    lblDisplay.Text = (Convert.ToDouble(result) / 100).ToString();
                    return;
                }
            }
        }
    }
}
