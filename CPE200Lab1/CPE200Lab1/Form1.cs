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
        private double firstnum = 0;
        private double secnum = 0;
        private double result = 0;
        private string sum = null;
        private string operation = null;
        private double firstper = 0;
        private bool percent = false;

        public Form1()
        {
            InitializeComponent();
        }

       
        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
           if(lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstnum = double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            operation = "+";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (operation == "+")
            {
                if (percent == true)
                {
                    result = firstnum + firstper;
                    percent = false;
                }
                else
                {
                    secnum = double.Parse(lblDisplay.Text);
                    result = firstnum + secnum;
                }
            }

            if(operation == "-")
            {
                if (percent == true)
                {
                    result = firstnum - firstper;
                    percent = false;
                }
                else
                {
                    secnum = double.Parse(lblDisplay.Text);
                    result = firstnum - secnum;
                }
            }
            if (operation == "*")
            {
                if (percent == true)
                {
                    result = firstnum * firstper;
                    percent = false;
                }
                else
                {
                    secnum = double.Parse(lblDisplay.Text);
                    result = firstnum * secnum;
                }
            }
            if (operation == "/")
            {
                if (percent == true)
                {
                    result = firstnum / firstper;
                    percent = false;
                }
                else
                {
                    secnum = double.Parse(lblDisplay.Text);
                    result = firstnum / secnum;
                }
            }
            sum = Convert.ToString(result);
            lblDisplay.Text = sum;
            firstnum = 0;
            secnum = 0;
            firstper = 0;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            firstnum = double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            operation = "-";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            firstnum = double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            operation = "*";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            firstnum = double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            operation = "/";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            firstnum = 0;
            secnum = 0;
            lblDisplay.Text = "0";
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            percent = true;
            firstper = firstnum * double.Parse(lblDisplay.Text) / 100;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text + ".";
        }
    }
}
