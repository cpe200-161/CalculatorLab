using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        double num1,num2,ans=0;
        int action=0;

        private void btnN_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || lblDisplay.Text == string.Format("{0:G}", num1) || lblDisplay.Text == string.Format("{0:G}", ans))
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8 )
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            num1 = 0; num2 = 0; ans = 0; action = 0;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(lblDisplay.Text);
            lblDisplay.Text = string.Format("{0:G}", num1);
            action = 1;

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(lblDisplay.Text);
            lblDisplay.Text = string.Format("{0:G}", num1);
            action = 4;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(lblDisplay.Text);
            lblDisplay.Text = string.Format("{0:G}", num1);
            action = 2;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(lblDisplay.Text);
            lblDisplay.Text = string.Format("{0:G}", num1);
            action = 3;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text + ".";
            //god damn dot
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (num1 != 0)
            {
                num2 = double.Parse(lblDisplay.Text);
                num2 = num1 * (num2 / 100);
                lblDisplay.Text = string.Format("{0:G}", num2);
            }
            else
            {
                num1 = double.Parse(lblDisplay.Text);
                num1 = num1 / 100.00;
                lblDisplay.Text = string.Format("{0:G}", num1);
                
            }
            
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            num2 = float.Parse(lblDisplay.Text);
            ans = 0;
            lblDisplay.Text = string.Format("{0:G}", num2);

            if (action == 1) ans = num1 + num2;
            else if (action == 2) ans = num1 - num2;
            else if (action == 3) ans = num1 * num2;
            else if (action == 4)
            {
                if (num2 != 0)
                {
                    ans = num1 / num2;
                }
                else
                {
                    lblDisplay.Text = "Error";
                    return;
                }
               
            }
            

            lblDisplay.Text = string.Format("{0:G}",ans);

        }
    }
}
