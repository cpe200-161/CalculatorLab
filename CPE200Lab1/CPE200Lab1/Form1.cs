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


        private int click = 0;
        private double num;
        private double n;
        private double val;
        private int dot = 0;

        public void input(double n)
        {
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text = lblDisplay.Text + n.ToString();
        }

        public void Enter()
        {
            val = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            dot = 0;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            input(9);
        }

        private void btn8_Click_1(object sender, EventArgs e)
        {
            input(8);
        }

        private void btn6_Click_1(object sender, EventArgs e)
        {
            input(6);
        }

        private void btn7_Click_1(object sender, EventArgs e)
        {
            input(7);
        }

        private void btn4_Click_1(object sender, EventArgs e)
        {
            input(4);
        }

        private void btn5_Click_1(object sender, EventArgs e)
        {
            input(5);
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            input(1);
        }

        private void btn2_Click_1(object sender, EventArgs e)
        {
            input(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            input(3);
        }

        private void btn0_Click_1(object sender, EventArgs e)
        {
            input(0);
        }

        private void btnDot_Click_1(object sender, EventArgs e)
        {
            if (dot == 0)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
                dot = 1;
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            dot = 0;

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            int x = lblDisplay.Text.Length;
            if (lblDisplay.Text == "")
            {
                lblDisplay.Text = "";
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text.Remove(x - 1);
            }
        }

        private void btnPercent_Click_1(object sender, EventArgs e)
        {
            n = Double.Parse(lblDisplay.Text);

            if (val == 0)
            {
                n = n / 100;
            }
            else
            {
                n = (n / 100) * val;
            }
            if (n % 1 == 0)
            {
                dot = 0;
            }
            else dot = 1;
            lblDisplay.Text = n.ToString();
        }

        private void btnDivide_Click_1(object sender, EventArgs e)
        {
            Enter();
            click = 3;
        }

        private void btnMultiply_Click_1(object sender, EventArgs e)
        {
            Enter();
            click = 0;
        }

        private void btnMinus_Click_1(object sender, EventArgs e)
        {
            Enter();
            click = 1;
        }

        private void btnPlus_Click_1(object sender, EventArgs e)
        {
            Enter();
            click = 2;
        }

        private void btnEqual_Click_1(object sender, EventArgs e)
        {
            num = Double.Parse(lblDisplay.Text);
            if (click == 0)
            {
                val = val * num;
            }
            else if (click == 1)
            {
                val = val - num;
            }
            else if (click == 2)
            {
                val = val + num;
            }
            else if (click == 3)
            {
                val = val / num;
            }

            lblDisplay.Text = val.ToString();
        }
    }
}
