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
        private bool Xnum = false, Xoper = false, Dot = false;
        private string operand;
        private float first, second;

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (Dot == false)
            {
                lblDisplay.Text += ".";
            }
            Dot = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (Xoper)
            {
                second = float.Parse(lblDisplay.Text);
                if (operand == "+")
                {
                    float result = first + second;
                    lblDisplay.Text = result.ToString();
                }
                if (operand == "-")
                {
                    float result = first - second;
                    lblDisplay.Text = result.ToString();
                }
                if (operand == "X")
                {
                    float result = first * second;
                    lblDisplay.Text = result.ToString();
                }
                if (operand == "÷")
                {
                    float result = first / second;
                    lblDisplay.Text = result.ToString();
                }
                if (lblDisplay.Text.Length > 9)
                {
                    lblDisplay.Text = "Error       ";
                }
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (Xoper)
            {
                second = float.Parse(lblDisplay.Text);
                if (operand == "+")
                {
                    float result = first + (first * (second / 100));
                    lblDisplay.Text = result.ToString();
                }
                if (operand == "-")
                {
                    float result = first - (first * second / 100);
                    lblDisplay.Text = result.ToString();
                }
                if (operand == "X")
                {
                    float result = first * (second / 100);
                    lblDisplay.Text = result.ToString();
                }
                if (operand == "÷")
                {
                    float result = first / (second / 100);
                    lblDisplay.Text = result.ToString();
                }
                if (lblDisplay.Text.Length > 8)
                {
                    lblDisplay.Text = "Error       ";
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 1)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            }
            else
            {
                lblDisplay.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            Xnum = false;
            Xoper = false;
            Dot = false;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            first = float.Parse(lblDisplay.Text);
            operand = btn.Text;
            Xnum = true;
            Xoper = true;
            Dot = false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || Xnum)
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text += btn.Text;
            }
            Xnum = false;
        }
    }
}
