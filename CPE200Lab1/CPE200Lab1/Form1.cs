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
        bool checknum1 = false;
        bool percent = false;
        float num1, num2;
        string opera;
        string opera_before;
     
        public Form1()

        {
            InitializeComponent();
        }

        private void calculate_1(float num1, string opera)
        {
            num2 = float.Parse(lblDisplay.Text);
            if (opera == "+")
            {
                if (percent)
                {
                    num1 = num1 + (num2 * num1 / 100);
                }
                else
                {
                    num1 = num1 + num2;
                }
            }
            else if (opera == "-")
            {
                if (percent)
                {
                    num1 = num1 - (num2 * num1 / 100);
                }
                else
                {
                    num1 = num1 - num2;
                }
            }
            else if (opera == "X")
            {

                if (percent)
                {
                    num1 = num1 * (num2 * num1 / 100);
                }
                else
                {
                    num1 = num1 * num2;
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

                    num1 = num1 / (num2 * num1 / 100);
                }
                else
                {
                    num1 = num1 / num2;
                }
            }
            if (lblDisplay.Text != "Error")
            {
                lblDisplay.Text = num1.ToString();
            }
            check1 = true;
            percent = false;
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
            checknum1 = false;

        }

        private void opera_click(object sender, EventArgs e)
        {
            opera_before = opera;
            Button btnX = (Button)sender;
            opera = btnX.Text;
            if (!checknum1)
            {
                num1 = float.Parse(lblDisplay.Text);
                checknum1 = true; check1 = true;
            }
            else {
                calculate_1(num1, opera_before );
                num1 = float.Parse(lblDisplay.Text);
            }
            

        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            percent = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            calculate_1(num1, opera);
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
