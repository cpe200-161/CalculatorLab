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
        private double sum;
        private string temp;
        private CalculatorEngine engine;
        private RPNCalculatorEngine RPNengine;

        public ExtendForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            RPNengine = new RPNCalculatorEngine();
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
            RPNengine.Process(lblDisplay.Text);
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
            RPNengine.Process(lblDisplay.Text);
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
            } else
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
            string result = RPNengine.Process(lblDisplay.Text);
            if (result is "E")
            {
                lblDisplay.Text = "Error";
            } else
            {
                lblDisplay.Text = result;
                isSpaceAllowed = true;
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

        private void Memory_Store_Click(object sender, EventArgs e)
        {
            sum = double.Parse(lblDisplay.Text);
        }

        private void Memory_recall_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = sum.ToString();
            RPNengine.Process(lblDisplay.Text);
            isSpaceAllowed = true;
        }

        private void Memory_clear_Click(object sender, EventArgs e)
        {
            sum = 0;
            lblDisplay.Text = sum.ToString();
        }

        private void Memory_Add_Click(object sender, EventArgs e)
        {
            temp = lblDisplay.Text;
            sum += double.Parse(temp);
        }

        private void Memory_minus_Click(object sender, EventArgs e)
        {
            temp = lblDisplay.Text;
            sum -= double.Parse(temp);
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            string[] keep = (lblDisplay.Text).Split(' ');
            if (keep.Length == 1)
            {
                keep[0] = Math.Sqrt(Convert.ToDouble(keep[0])).ToString();
                lblDisplay.Text = keep[0];
                isSpaceAllowed = true;
            }
            else if (isNumber(keep[keep.Length - 1]))
            {
                keep[keep.Length - 1] = Math.Sqrt(Convert.ToDouble(keep[keep.Length-1])).ToString(); ;
                for (int i = 0; i < keep.Length; i++)
                {
                    if (i == 0) { lblDisplay.Text = keep[i]; }
                    else {
                        lblDisplay.Text = lblDisplay.Text + " " + keep[i];
                    }

                }
                isSpaceAllowed = true;
            }
        }
//wanna fix
        private void one_overX_Click(object sender, EventArgs e)
        {
            string [] keep = lblDisplay.Text.Split(' ');
            if (keep.Length == 1)
            {
                keep[0] = (1.0 / Convert.ToDouble(keep[0])).ToString();
                lblDisplay.Text = keep[0];
                isSpaceAllowed = true;
            }
            else if (isNumber(keep[keep.Length - 1]) && keep.Length > 1)
            {
                keep[keep.Length - 1] = (1 / Convert.ToDouble(keep[keep.Length-1])).ToString(); 
                //string keep2 = (1 / Convert.ToDouble(keep[keep.Length - 1])).ToString();
                //keep[keep.Length - 1] = keep2;
                for (int i = 0; i < keep.Length; i++)
                {
                    if (i == 0)
                    {
                        lblDisplay.Text = keep[i];
                    }
                    else
                    {
                        lblDisplay.Text += " " + keep[i];
                    }
                }
                //lblDisplay.Text = keep2 + lblDisplay.Text;
                isSpaceAllowed = true;
                return;
            }
        }

        private void Percent_Click(object sender, EventArgs e)
        {
            string[] keep = (lblDisplay.Text).Split(' ');
            if (keep.Length ==1)
            {
                keep[0] = (Convert.ToDouble(keep[0])/100).ToString();
                lblDisplay.Text = keep[0];
                isSpaceAllowed = true;
            }
            else if (isNumber(keep[keep.Length-1])&& isNumber(keep[keep.Length - 2]))
            {
                keep[keep.Length - 1] = (Convert.ToDouble(keep[keep.Length - 1]) * (Convert.ToDouble(keep[keep.Length - 2]) / 100)).ToString();
                for(int i = 0; i < keep.Length; i++)
                {
                    if (i == 0) { lblDisplay.Text = keep[0]; }
                    else
                    {
                        lblDisplay.Text = lblDisplay.Text + " " + keep[i];
                    }
                    
                }
                isSpaceAllowed = true;
            }
            

            
        }
    }
}
