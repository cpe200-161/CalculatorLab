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
        string operate = " ";
        float num1 = 0;
        float num2 = 1;
        float sum = 0;
        string display = "0";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text += btnDot.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = " ";
            num1 = 0; num2 = 1; display = "0"; operate = " ";
        }

        private void btnoperator(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (operate == " ")
            {
                operate = btn.Text;
            }
            if (operate == "+")
            {
                num1 += float.Parse(display);
                operate = btn.Text;
            }
            else if(operate == "-")
            {
                if (num1 == 0)
                {
                    num1 += float.Parse(display);
                }
                else
                {
                    num1 -= float.Parse(display);
                }
                operate = btn.Text;
            }
            else if(operate == "X")
            {
                num2 *= float.Parse(display);
                operate = btn.Text;
            }
            else if (operate == "÷")
            {
                if (num2 == 1)
                {
                    num2 = float.Parse(display)/num2;
                }
                else
                {
                    num2 /= float.Parse(display);
                }
                operate = btn.Text;
            }

            if(operate == "+" || operate == "-")
            {
                lblDisplay.Text = " ";
                lblDisplay.Text = num1.ToString();
            }
            else if(operate == "X" || operate == "÷")
            {
                lblDisplay.Text = " ";
                lblDisplay.Text = num2.ToString();
            }
        }

        private void btnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (display == "0")
            {
                lblDisplay.Text = " ";
            }
            if(num1 != 0 || num2 != 1)
            {
                lblDisplay.Text = " ";
                display = " ";
            }
            lblDisplay.Text += btn.Text;
            display = lblDisplay.Text;

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if(operate == "+")
            {
                num1 += float.Parse(display);
                lblDisplay.Text = " ";
                lblDisplay.Text = num1.ToString();
                display = num1.ToString();
                num1 = 0;

            }
            else if(operate == "-")
            {
                num1 -= float.Parse(display);
                lblDisplay.Text = " ";
                lblDisplay.Text = num1.ToString();
                display = num1.ToString();
                num1 = 0;
            }
            else if (operate == "X")
            {
                num2 *= float.Parse(display);
                lblDisplay.Text = " ";
                lblDisplay.Text = num2.ToString();
                display = num1.ToString();
                num1 = 0;
            }
            else if (operate == "÷")
            {
                num2 /= float.Parse(display);
                lblDisplay.Text = " ";
                lblDisplay.Text = num2.ToString();
                display = num1.ToString();
                num1 = 0;
            }
            else if(operate == "%")
            {
                float num = float.Parse(display);
                num = (sum/100) * num;
                lblDisplay.Text = " ";
                lblDisplay.Text = num.ToString();
                display = lblDisplay.Text;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int longs = display.Length - 1;
            //lblDisplay.Text = ;
            display = lblDisplay.Text;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            float num = float.Parse(display) * -1;
            lblDisplay.Text = num.ToString();
            display = lblDisplay.Text;
       }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            sum = float.Parse(display);
            operate = btn.Text;
            display = "0";
        }
    }
}
