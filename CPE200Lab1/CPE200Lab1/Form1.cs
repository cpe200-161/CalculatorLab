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
        bool check1 = true;
        bool sigh_check = true;
        bool percent = false;
        float num1, num2, num3;
        string opera;
        private int val = 0;
        public Form1()

        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;
            if (check1 || lblDisplay.Text == "0")
            {
                lblDisplay.Text = btnX.Text;
                check1 = false;
            }
            else
            {
                if (lblDisplay.Text.Length < 8)
                {
                    lblDisplay.Text = lblDisplay.Text + btnX.Text;
                }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            check1 = true;
        }

        private void opera_click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;
            opera = btnX.Text;
            num1 = float.Parse(lblDisplay.Text);
            check1 = true;

        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            percent = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            num2 = float.Parse(lblDisplay.Text);
            if (opera == "+")
            {
                if (percent)
                {
                    num3 = num1 + (num2 * num1 / 100);
                }
                else
                {
                    num3 = num1 + num2;
                }
            }
            else if (opera == "-")
            {
                if (percent)
                {
                    num3 = num1 - (num2 * num1 / 100);
                }
                else
                {
                    num3 = num1 - num2;
                }
            }
            else if (opera == "X")
            {

                if (percent)
                {
                    num3 = num1 * (num2 * num1 / 100);
                }
                else
                {
                    num3 = num1 * num2;
                }
            }
            else if (opera == "÷")
            {
                if (num2 == 0)
                {
                    lblDisplay.Text = "Error";
                }
                else if (percent)
                {

                    num3 = num1 + (num2 * num1 / 100);
                }
                else
                {
                    num3 = num1 + num2;
                }
            }
            if (lblDisplay.Text != "Error")
            {
                lblDisplay.Text = num3.ToString();
            }
            check1 = true;
            percent = false;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
           
                if (lblDisplay.Text[0] is '-')
                {
                    lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
                }
                else
                {
                    lblDisplay.Text = "-" + lblDisplay.Text;
                }
            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 0)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
            }
            if (lblDisplay.Text.Length == 0)
            {
                lblDisplay.Text = "0";
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!lblDisplay.Text.Contains("."))
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }

        }

    }
}
