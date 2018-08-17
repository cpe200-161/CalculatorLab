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
        private int val = 0;
        private int sum;
        private int i;
        private string

        





            

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            val = val * 0;
            lblDisplay.Text = val.ToString();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            val = val * 10 + 1;
            lblDisplay.Text = val.ToString();

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

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

        private void btnPlus_Click(object sender, EventArgs e)
        {
            
            sum = Convert.ToInt32(lblDisplay.Text);
            lblDisplay.Text = Convert.ToString(sum);
            val = val * 0;
            i = 1;
          
   

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            sum = Convert.ToInt32(lblDisplay.Text);
            lblDisplay.Text = Convert.ToString(sum);
            val = val * 0;
            i = 2;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            sum = Convert.ToInt32(lblDisplay.Text);
            lblDisplay.Text = Convert.ToString(sum);
            val = val * 0;
            i = 3;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            
            sum = Convert.ToInt32(lblDisplay.Text);
            lblDisplay.Text = Convert.ToString(sum);
            val = val * 0;
            i = 4;
           
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            val = val + ".";
            lblDisplay.Text = val.ToString();
        }


       

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                val = val + sum;
                lblDisplay.Text = val.ToString();

            }
            if (i == 2)
            {
                val = val - sum;
                lblDisplay.Text = val.ToString();
            }
            if (i == 3)
            {
                val = val * sum;
                lblDisplay.Text = val.ToString();

            }
            if (i == 4)
            {
                val = val / sum;
                lblDisplay.Text = val.ToString();
            }






        }
    }
}
