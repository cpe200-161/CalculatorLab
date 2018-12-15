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
        private int val = 0, val2 = 0,val3 = 0;
        private bool ope = false, ope1 = false, ope2 = false, ope3 = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            
                val = val * 10 + 1;
                lblDisplay.Text = val.ToString();
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
           
                val = val * 10 + 2;
                lblDisplay.Text = val.ToString();
            
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            val = val * 10 + 3;
            lblDisplay.Text = val.ToString();
            
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            val = val * 10 + 4;
            lblDisplay.Text = val.ToString();
            
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            val = val * 10 + 5;
            lblDisplay.Text = val.ToString();
            
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            val = val * 10 + 6;
            lblDisplay.Text = val.ToString();
            
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            val = val * 10 + 7;
            lblDisplay.Text = val.ToString();
            
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            val = val * 10 + 8;
            lblDisplay.Text = val.ToString();
            
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            val = val * 10 + 9;
            lblDisplay.Text = val.ToString();
            
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            val = val * 10 + 0;
            lblDisplay.Text = val.ToString();
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
            val = val * 0;
            val2 = val2 * 0;
            lblDisplay.Text = (val).ToString();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if(ope == true)
            {
                val = val + val2;
            }

            if (ope1 == true)
            {
                val = val2 - val;
            }
            if (ope2 == true)
            {
                val = val * val2;
            }
            if (ope3 == true)
            {
                val = val2 / val;
            }
            val2 = 0;
            ope = false; ope1 = false; ope2 = false; ope3 = false;
            lblDisplay.Text = val.ToString();
            
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            val = val * -1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
           
                val2 = val;
                val = 0;
                ope1 = true;
            
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
                
                val2 = val;
                val = 0;
                ope2 = true;
            
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            
                val2 = val;
                val = 0;
                ope3 = true;
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            val = val / 10;
            lblDisplay.Text = val.ToString();
        }
        
        private void btnPlus_Click(object sender, EventArgs e)
        {
                ope = false;
                val2 += val;
                val = 0;
                ope = true;
            
        }

    }
}
