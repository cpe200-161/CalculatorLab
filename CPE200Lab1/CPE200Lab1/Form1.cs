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

        double a, b;
        string oper;
        bool isDisplay = false;

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (oper == "+")
            {
                b = double.Parse(lblDisplay.Text);
                double c = a + b;
                string ans = c.ToString();
                lblDisplay.Text = ans;
            }
            else if (oper == "-")
            {
                b = double.Parse(lblDisplay.Text);
                double c = a - b;
                string ans = c.ToString();
                lblDisplay.Text = ans;
            }
            else if (oper == "*")
            {
                b = double.Parse(lblDisplay.Text);
                double c = a * b;
                string ans = c.ToString();
                lblDisplay.Text = ans;
            }
            else if (oper == "/")
            {
                b = double.Parse(lblDisplay.Text);
                double c = a / b;
                string ans = c.ToString();
                lblDisplay.Text = ans;
            }
        }

        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || isDisplay) lblDisplay.Text = "";
            if (lblDisplay.Text.Length < 8) lblDisplay.Text += btn.Text;
            isDisplay = false;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            oper = "-";
            a = double.Parse(lblDisplay.Text);
            isDisplay = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            oper = "*";
            a = double.Parse(lblDisplay.Text);
            isDisplay = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            oper = "/";
            a = double.Parse(lblDisplay.Text);
            isDisplay = true;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            oper = "+";
            a = double.Parse(lblDisplay.Text);
            isDisplay = true;

        }
    }
}