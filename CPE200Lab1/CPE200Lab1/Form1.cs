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
		int total = 0;
		int stage = 0;

		private void btnX_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			if (lblDisplay.Text == "0") lblDisplay.Text = "";
			if (lblDisplay.Text.Length <= 8) lblDisplay.Text = lblDisplay.Text + btn.Text;
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

		}

		private void btnPlus_Click(object sender, EventArgs e)
		{
			total = total + Int32.Parse(lblDisplay.Text);
			lblDisplay.Text = "";
			stage = 1;
			//lblDisplay.Text = lblDisplay.Text + "+";


		}

		private void btnEqual_Click(object sender, EventArgs e)
		{
			if (stage == 1)
			{
				total = total + Int32.Parse(lblDisplay.Text);
				lblDisplay.Text = total.ToString();
				lblDisplay.Text = "";
				total = 0;
			}
		}
	}
}
