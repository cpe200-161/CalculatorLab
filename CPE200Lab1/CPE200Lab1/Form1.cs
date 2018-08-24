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
    public partial class Form1 : Form
    {
        string operation;
        int check = 0;
        float number1;
        float number2;
        float result;
        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnX_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (check == 0)
            {
                check = 1;
                lblDisplay.Text = "";
            }
            if (check == 2)
            {
                check = 3;
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!lblDisplay.Text.Contains("."))
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }  
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                number1 = float.Parse(lblDisplay.Text);
                check = 2;
            }
            else if (check == 3)
            {
                number2 = float.Parse(lblDisplay.Text);
                if (operation == "+")
                {
                    result = number1 + number2;
                }
                else if (operation == "-")
                {
                    result = number1 - number2;
                }
                else if (operation == "*")
                {
                    result = number1 * number2;
                }
                else if (operation == "/")
                {
                    result = number1 / number2;
                }

                if (operation == "/" && number2 == 0)
                {
                    lblDisplay.Text = "Can't divide";
                    number1 = 0;
                    number2 = 0;
                }
                else
                {
                    lblDisplay.Text = Convert.ToString(result);
                    number1 = result;
                }
                check = 2;
            }
            operation = "+";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                number1 = float.Parse(lblDisplay.Text);
                check = 2;
            }
            else if (check == 3)
            {
                number2 = float.Parse(lblDisplay.Text);
                if (operation == "+")
                {
                    result = number1 + number2;
                }
                else if (operation == "-")
                {
                    result = number1 - number2;
                }
                else if (operation == "*")
                {
                    result = number1 * number2;
                }
                else if (operation == "/")
                {
                    result = number1 / number2;
                }

                if (operation == "/" && number2 == 0)
                {
                    lblDisplay.Text = "Can't divide";
                    number1 = 0;
                    number2 = 0;
                }
                else
                {
                    lblDisplay.Text = Convert.ToString(result);
                    number1 = result;
                }
                check = 2;
            }
            operation = "-";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                number1 = float.Parse(lblDisplay.Text);
                check = 2;
            }
            else if (check == 3)
            {
                number2 = float.Parse(lblDisplay.Text);
                if (operation == "+")
                {
                    result = number1 + number2;
                }
                else if (operation == "-")
                {
                    result = number1 - number2;
                }
                else if (operation == "*")
                {
                    result = number1 * number2;
                }
                else if (operation == "/")
                {
                    result = number1 / number2;
                }

                if (operation == "/" && number2 == 0)
                {
                    lblDisplay.Text = "Can't divide";
                    number1 = 0;
                    number2 = 0;
                }
                else
                {
                    lblDisplay.Text = Convert.ToString(result);
                    number1 = result;
                }
                check = 2;
            }
            operation = "*";
        }
    
        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                number1 = float.Parse(lblDisplay.Text);
                check = 2;
            }
            else if (check == 3)
            {
                number2 = float.Parse(lblDisplay.Text);
                if (operation == "+")
                {
                    result = number1 + number2;
                }
                else if (operation == "-")
                {
                    result = number1 - number2;
                }
                else if (operation == "*")
                {
                    result = number1 * number2;
                }
                else if (operation == "/")
                {
                    result = number1 / number2;
                }

                if (operation == "/" && number2 == 0)
                {
                    lblDisplay.Text = "Can't divide";
                    number1 = 0;
                    number2 = 0;
                }
                else
                {
                    lblDisplay.Text = Convert.ToString(result);
                    number1 = result;
                }
                check = 2;
            }
            operation = "/";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 1)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length -1);
            }
            else
            {
                lblDisplay.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            number1 = 0;
            number2 = 0;
            check = 0;
            operation = null;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            number2 = float.Parse(lblDisplay.Text);
            if (operation == "+")
            {
                result = number1 + number2;
            }
            else if (operation == "-")
            {
                result = number1 - number2;
            }
            else if (operation == "*")
            {
                result = number1 * number2;
            } 
            else if (operation == "/")
            {
                result = number1 / number2; 
            }

            if (operation == "/" && number2 == 0)
            {
                lblDisplay.Text = "Can't divide";
                number1 = 0;
                number2 = 0;
                check = 0;
            }
            else
            {
                lblDisplay.Text = Convert.ToString(result);
                number1 = result;
                check = 2;
            }
            operation = null; 
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                lblDisplay.Text = "0";
                number1 = float.Parse(lblDisplay.Text);
                check = 0;
            }
            else if (check == 3)
            {
                number2 = float.Parse(lblDisplay.Text);
                lblDisplay.Text = Convert.ToString(number1 * number2 / 100);
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (!lblDisplay.Text.Contains('-'))
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text.Trim('-');
            }

            if (check == 2)
            {
                number1 = float.Parse(lblDisplay.Text);
            }
            else if (check == 3)
            {
                number2 = float.Parse(lblDisplay.Text);
            }
        }
    }
}
