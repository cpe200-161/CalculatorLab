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

        
        private double x;
		private double z;
		private int dot = 0;
		
        public Form1()
        {
            InitializeComponent();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
			if(lblDisplay.Text == "0")
			{
				lblDisplay.Text = "";
			}
			lblDisplay.Text = lblDisplay.Text + "4";	
		}

        private void btn7_Click(object sender, EventArgs e)
        {
			if (lblDisplay.Text == "0")
			{
				lblDisplay.Text = "";
			}
			lblDisplay.Text = lblDisplay.Text + "7";

		}

        private void btn0_Click(object sender, EventArgs e)
        {
			if (lblDisplay.Text == "0")
			{
				lblDisplay.Text = "";
			}
			lblDisplay.Text = lblDisplay.Text + "0";
		}

        private void btn1_Click(object sender, EventArgs e)
        {

			if (lblDisplay.Text == "0")
			{
				lblDisplay.Text = "";
			}
			lblDisplay.Text = lblDisplay.Text + "1";
		}

        private void btn2_Click(object sender, EventArgs e)
        {
			if (lblDisplay.Text == "0")
			{
				lblDisplay.Text = "";
			}
			lblDisplay.Text = lblDisplay.Text + "2";
		}

        private void btn3_Click(object sender, EventArgs e)
        {
			if (lblDisplay.Text == "0")
			{
				lblDisplay.Text = "";
			}
			lblDisplay.Text = lblDisplay.Text + "3";
		}

        private void btn5_Click(object sender, EventArgs e)
        {
			if (lblDisplay.Text == "0")
			{
				lblDisplay.Text = "";
			}
			lblDisplay.Text = lblDisplay.Text + "5";
		}

        private void btn6_Click(object sender, EventArgs e)
        {
			if (lblDisplay.Text == "0")
			{
				lblDisplay.Text = "";
			}
			lblDisplay.Text = lblDisplay.Text + "6";
		}

        private void btn8_Click(object sender, EventArgs e)
        {
			if (lblDisplay.Text == "0")
			{
				lblDisplay.Text = "";
			}
			lblDisplay.Text = lblDisplay.Text + "8";
		}

        private void btn9_Click(object sender, EventArgs e)
        {
			if (lblDisplay.Text == "0")
			{
				lblDisplay.Text = "";
			}
			lblDisplay.Text = lblDisplay.Text + "9";
		}

        private void btnClear_Click(object sender, EventArgs e)
        {
			lblDisplay.Text = "0";
			dot = 0;
        }
        private int num = 0;
        private void btnEqual_Click(object sender, EventArgs e)
        {
			double y = Double.Parse(lblDisplay.Text);
			if (num == 0)
			{
				x = x - y;
			}
			else if(num == 1)
			{
				x = x + y;
			}
			else if(num == 2)
			{
				x = x * y;
			}
			else if(num == 3)
			{
				x = x / y;
			}


            lblDisplay.Text = x.ToString();
            
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
			x = Double.Parse(lblDisplay.Text);
			lblDisplay.Text = "0";
			num = 0;
			dot = 0;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
			x = Double.Parse(lblDisplay.Text);
			lblDisplay.Text = "0";
            num = 1;
			dot = 0;
     
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
			x = Double.Parse(lblDisplay.Text);
			lblDisplay.Text = "0";
            num = 2;
			dot = 0;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
			x = Double.Parse(lblDisplay.Text);
			lblDisplay.Text = "0";
            num = 3;
			dot = 0;
        }
		
        private void btnDot_Click(object sender, EventArgs e)
        {
			if (dot == 0)
			{
				lblDisplay.Text = lblDisplay.Text + ".";
				dot = 1;
			}
			
	    }
		
		
		private void btnPercent_Click(object sender, EventArgs e)
		{
			z = Double.Parse(lblDisplay.Text);
			if (x == 0)
			{
				z = z / 100;
			}
			else
			{
				z = (z / 100) * x;
			}
			if (z % 1 == 0)
			{
				dot = 0;
			}
			else dot = 1;
			lblDisplay.Text = z.ToString();
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			int a = lblDisplay.Text.Length;
			if(lblDisplay.Text == "")
			{
				lblDisplay.Text = "";
			}
			else
			{
				lblDisplay.Text = lblDisplay.Text.Remove(a - 1);
			}
			
		}
	}
}
