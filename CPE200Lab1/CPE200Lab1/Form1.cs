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

        private double sum;
        private int i;
        private double x;
        private double y;
        private double d = 0;

        public void clearZero()
        {
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            clearZero();
            lblDisplay.Text += "1";

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            clearZero();
            lblDisplay.Text += "2";

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            clearZero();
            lblDisplay.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            clearZero();
            lblDisplay.Text += "4";

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            clearZero();
            lblDisplay.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            clearZero();
            lblDisplay.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            clearZero();
            lblDisplay.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            clearZero();
            lblDisplay.Text += "8";

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            clearZero();
            lblDisplay.Text += "9";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            sum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            i = 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            sum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            i = 2;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            sum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            i = 3;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            sum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            i = 4;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            y = Double.Parse(lblDisplay.Text);
            if (sum == 0)
            {
                y = y / 100;
            }
            else
            {
                y = (y / 100) * sum;
            }
            if (y % 1 == 0)
            {
                d = 0;

            }
            else d = 1;
            lblDisplay.Text = y.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length == 1)
            {
                lblDisplay.Text = "0";
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            lblDisplay.Text = "0";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            x = Double.Parse(lblDisplay.Text);
            if (i == 1)
            {
                sum = sum + x;

            }
            if (i == 2)
            {
                sum = sum - x;
            }
            if (i == 3)
            {
                sum = sum * x;
            }
            if (i == 4)
            {
                sum = sum / x;
            }
            if (i == 5)
            {
                sum = sum / 100;
            }


            lblDisplay.Text = sum.ToString();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (d == 0)
            {
                lblDisplay.Text += ".";
                d = 1;
            }

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(lblDisplay.Text) * (-1)).ToString();

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            clearZero();
            lblDisplay.Text += "0";
        }
    }
}
