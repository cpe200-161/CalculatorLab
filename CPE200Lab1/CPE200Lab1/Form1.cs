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
        private double val = 0;
        private bool plus = false,minus = false, multiply = false, divide = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void number(int n)
        {
            val = val * 10 + n;
            lblDisplay.Text = val.ToString();
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            number(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            number(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            number(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            number(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            number(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            number(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            number(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            number(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            number(9);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            number(0);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private double old = 0;
        private void btnMultiply_Click(object sender, EventArgs e)
        {

            
            old = val;
            val = 0;
            multiply = true;
        }

        
        private void btnPlus_Click(object sender, EventArgs e)
        {

            if (plus == true)
            {
                val = val + old;
            }

            lblDisplay.Text = val.ToString();

            old = val;
            val = 0;
            plus = true;
            
        }
       
        private void btnEqual_Click(object sender, EventArgs e)
        {
          if(plus == true)
            {
                val = val + old;
                plus = false;
            }
          else if(minus == true)
            {
                val = old - val;
                minus = false;
            }
          else if(multiply == true)
            {
                val = val * old;
                multiply = false;
            }
            else if (divide == true)
            {
                val = old / val;
                divide = false;
            }
            lblDisplay.Text = val.ToString();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            
            old = val;
            val = old - val;
            minus = true;
            val = 0;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
           
            old = val;
            val = 0;
            divide = true;
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length != 0)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            }else
            {
                lblDisplay.Text = "0";
            }
        }
    }
}
