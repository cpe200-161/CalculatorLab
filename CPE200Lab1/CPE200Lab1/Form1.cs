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
        double first;
        double second;
        int third;
        double sum;
        double percent;
        public Form1()
        {
            InitializeComponent();
        }
        public void calculate()
        {
            if (third == 1)
            {
                sum = first + second;
            }
            if (third == 2)
            {
                sum = first - second;
            }
            if (third == 3)
            {
                sum = first * second;
            }
            if (third == 4)
            {
                sum = first / second;
            }
        }
        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }

        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            third = 1;
            first = Convert.ToDouble(lblDisplay.Text);
            if (first > 0)
            {
                lblDisplay.Text = "";
            }
            calculate();
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            third = 2;
            first = Convert.ToDouble(lblDisplay.Text);
            if (first > 0)
            {
                lblDisplay.Text = "";
            }
            calculate();

        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            third = 3;
            first = Convert.ToDouble(lblDisplay.Text);
            if (first > 0)
            {
                lblDisplay.Text = "";
            }
            calculate();

        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            third = 4;
            first = Convert.ToDouble(lblDisplay.Text);
            if (first > 0)
            {
                lblDisplay.Text = "";
            }
            calculate();

        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            second = Convert.ToDouble(lblDisplay.Text);
            switch (third)
            {
                case 1: percent = first + (first * (second / 100)); break;
                case 2: percent = first - (first * (second / 100)); break;
                case 3: percent = first * (second/100); break;
                case 4: percent = first / (second / 100); break;
                default: percent = second / 100; break;
            }
            lblDisplay.Text = Convert.ToString(percent);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            first = 0;
            second = 0;
            lblDisplay.Text = "0";

        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            second = Convert.ToDouble(lblDisplay.Text);
            calculate();
            lblDisplay.Text = Convert.ToString(sum);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text + ".";
        }
    }
}
