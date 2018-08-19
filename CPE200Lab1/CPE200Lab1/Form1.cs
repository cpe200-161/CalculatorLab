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
        public Form1()
        {
            InitializeComponent();
        }
		int total = 0 , a = 0, b = 0 ;
		int stage = 0;
		string order = " ";

		private void btnX_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			if (lblDisplay.Text == "0") lblDisplay.Text = "";

			if (order == "clear")
			{
				lblDisplay.Text = "";
				lblDisplay.Text = btn.Text;
				order = " ";
			} else if (lblDisplay.Text.Length <= 8)
			{
				lblDisplay.Text = lblDisplay.Text + btn.Text;
			}
		}


		private void btn1_Click(object sender, EventArgs e)
		{

		}

		private void btn2_Click(object sender, EventArgs e)
		{

		}

		private void btn3_Click(object sender, EventArgs e)
		{

		}

		private void btn4_Click(object sender, EventArgs e)
		{

		}

		private void btn5_Click(object sender, EventArgs e)
		{

		}

		private void btn6_Click(object sender, EventArgs e)
		{

		}

		private void btn7_Click(object sender, EventArgs e)
		{

		}

		private void btn8_Click(object sender, EventArgs e)
		{

		}

		private void btn9_Click(object sender, EventArgs e)
		{

		}

		private void btn0_Click(object sender, EventArgs e)
		{

		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			lblDisplay.Text = "0";
			total = 0;
			stage = 0;
			a = b = 0;
		}

		private void btnPlus_Click(object sender, EventArgs e)
		{
			if (stage != 1)
			{
				a = Int32.Parse(lblDisplay.Text);
			}
			else if(stage == 1)
			{
				b = Int32.Parse(lblDisplay.Text);
			}

			order = "clear";
			total = a + b;
			a = total;
			stage = 1;
			lblDisplay.Text = total.ToString();
			//lblDisplay.Text = lblDisplay.Text + "+";


		}

		private void btnEqual_Click(object sender, EventArgs e)
		{
			if (stage == 1)
			{
				b = Int32.Parse(lblDisplay.Text);
				total = a + b; 
			}
			if (stage == 2)
			{
				b = Int32.Parse(lblDisplay.Text);
				total = a - b;
			}
			if (stage == 3)
			{

				b = Int32.Parse(lblDisplay.Text);
				total = a * b;
			}

			lblDisplay.Text = total.ToString();
			stage = 0;
			order = "clear";


		}

			private void btnMinus_Click(object sender, EventArgs e)
		{
			if (stage != 2)
			{
				a = Int32.Parse(lblDisplay.Text);
			}
			else if (stage == 2)
			{
				b = Int32.Parse(lblDisplay.Text);
			}

			order = "clear";
			total = a - b;
			a = total;
			stage = 2;
			lblDisplay.Text = total.ToString();
		}

		private void btnMultiply_Click(object sender, EventArgs e)
		{
			order = "puss";
			if (stage == 0)
			{
				a = Int32.Parse(lblDisplay.Text);
				b = 1;
			}
			else
			{
				b = Int32.Parse(lblDisplay.Text);
			}
			stage = 3;
			total = a * b;
			a = total;
			lblDisplay.Text = total.ToString();
		}
	}
}
