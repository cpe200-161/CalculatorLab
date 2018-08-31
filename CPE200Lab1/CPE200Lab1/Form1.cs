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
        public Form1()
        {
            InitializeComponent();
        }
        double number;
        double result;
        string symbol;
        private string order;

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" && btn.Text != ".")
            {
                lblDisplay.Text = "";
            }
            if (order == "clear")
            {
                lblDisplay.Text = "";
                lblDisplay.Text = btn.Text;
                order = " ";
            }
            else if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }  // all num




        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = null;
            lblDisplay.Text = "0";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {

            number = double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            symbol = "+";

            // result = result + float.Parse(lblDisplay.Text);
            // lblDisplay.Text = result.ToString();
            // result = 0;
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            number = double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            symbol = "-";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            number = double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            symbol = "X";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            number = double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            symbol = "/";
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            number = double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            symbol = "%";
        }


        private void btnEqual_Click(object sender, EventArgs e)
        {


            if (symbol == "+")
            {
                if (lblDisplay.Text.Length < 8)
                {
                    result = (number + double.Parse(lblDisplay.Text));
                    if (result >= 1e8)
                    {
                        lblDisplay.Text = "error";
                    }
                    else
                    {
                        lblDisplay.Text = Convert.ToString(result);
                        number = 0;
                    }
                }
                if (lblDisplay.Text.Length > 8)
                {
                    lblDisplay.Text = "error";
                }
            }
            if (symbol == "-")
            {
                result = (number - double.Parse(lblDisplay.Text));
                if (result < 0)
                {
                    lblDisplay.Text = "error";
                }
                else
                {
                    lblDisplay.Text = Convert.ToString(result);
                    number = 0;
                }
                if (symbol == "X")
                {
                    if (lblDisplay.Text.Length < 8)
                    {
                        result = (number * double.Parse(lblDisplay.Text));
                        if (result >= 1e8)
                        {
                            lblDisplay.Text = "error";
                        }
                        else
                        {
                            lblDisplay.Text = Convert.ToString(result);
                            number = 0;
                        }
                    }

                }
                if (symbol == "/")
                { if (lblDisplay.Text == "0")
                    {
                        lblDisplay.Text = "error";
                         }
                    else {
                        result = (number / double.Parse(lblDisplay.Text));
                    }
                    lblDisplay.Text = Convert.ToString(result);
                    number = 0;
                }

                if (symbol == "%")
                {
                    result = ((number * double.Parse(lblDisplay.Text)) / 100);
                    lblDisplay.Text = Convert.ToString(result);
                    number = 0;
                }
            }
        }
      
       
        

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "0.";

            }
            if (symbol == ".")
            {
                lblDisplay.Text = lblDisplay.Text;
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text + ".";
                symbol = ".";
            }
        }
    }


















    

}
