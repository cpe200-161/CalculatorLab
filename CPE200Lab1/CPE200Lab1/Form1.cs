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
        private double first_number , result_number;
        private string operand;
        private bool flag_num = false , flag_oper = false; 

        public Form1()
        {
            InitializeComponent();
        }

        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if ( flag_num || lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }

            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
            flag_num = false;
        }

        private void btnoper_Click(object sender, EventArgs e)
        {
            if (!flag_oper)
            {
                Button btn = (Button)sender;
                first_number = (double.Parse(lblDisplay.Text));
                operand = btn.Text;
                flag_oper = true;
                flag_num = true;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (flag_oper)
            {
                result_number = (double.Parse(lblDisplay.Text));
                if(operand == "+")
                {
                    double ans = (result_number + first_number);
                    lblDisplay.Text = ans.ToString();

                }
                else if (operand == "-")
                {
                    double ans = (first_number - result_number);
                    lblDisplay.Text = ans.ToString();

                }
                else if (operand == "X")
                {
                    double ans = (result_number * first_number);
                    lblDisplay.Text = ans.ToString();

                }
                else if (operand == "÷")
                {
                    double ans = (first_number / result_number);
                    lblDisplay.Text = ans.ToString();

                }
                flag_oper = false;
            }
            
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.StartsWith("-"))
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1);
            }
            else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = ((double.Parse(lblDisplay.Text) * first_number / 100).ToString());
        }

       
    }
}
