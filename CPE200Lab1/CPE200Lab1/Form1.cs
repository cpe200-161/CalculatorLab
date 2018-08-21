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
            sum = 0; display = "0"; operate = " ";
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
                sum += float.Parse(display);
            }
            else if(operate == "-")
            {
                if (sum == 0)
                {
                    sum += float.Parse(display);
                }
                else
                {
                    sum -= float.Parse(display);
                }
            }
            else if(operate == "X")
            {
                if(sum == 0)
                {
                    sum += 1;
                }
                sum *= float.Parse(display);
            }
            else if (operate == "÷")
            {
                if (sum == 0)
                {
                    sum = float.Parse(display);
                }
                else
                {
                    sum /= float.Parse(display);
                }
            }
            lblDisplay.Text = " ";
            lblDisplay.Text = sum.ToString();
            operate = btn.Text;
        }

        private void btnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (display == "0")
            {
                lblDisplay.Text = " ";
            }
            if(sum != 0)
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
                sum += float.Parse(display);
                lblDisplay.Text = " ";
                lblDisplay.Text = sum.ToString();
                display = sum.ToString();

            }
            else if(operate == "-")
            {
                sum -= float.Parse(display);
                lblDisplay.Text = " ";
                lblDisplay.Text = sum.ToString();
                display = sum.ToString();
            }
            else if (operate == "X")
            {
                sum *= float.Parse(display);
                lblDisplay.Text = " ";
                lblDisplay.Text = sum.ToString();
                display = sum.ToString();
            }
            else if (operate == "÷")
            {
                sum /= float.Parse(display);
                lblDisplay.Text = " ";
                lblDisplay.Text = sum.ToString();
                display = sum.ToString();
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
