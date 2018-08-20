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
		public void CalculateStage()
		{
			if (stage == 0)
			{
				a = Convert.ToDouble(lblDisplay.Text);
			}
			if (stage != 0 && step != "chain")
			{
				b = Convert.ToDouble(lblDisplay.Text);
			}
			if (stage == 1)
			{
				lblDisplay.Text = (a + b).ToString();
			}
			if (stage == 2)
			{
				lblDisplay.Text = (a - b).ToString();
			}
			if (stage == 3)
			{
				lblDisplay.Text = (a * b).ToString();
			}
			if (stage == 4)
			{
				if (b == 0) lblDisplay.Text = "Error";
				else lblDisplay.Text = (a / b).ToString();
			}
			if(lblDisplay.Text != "Error") a = Convert.ToDouble(lblDisplay.Text);
			order = "clear";
		}


        public Form1()
        {
            InitializeComponent();
        }
		double a = 0, b = 0 ,c = 0;
		int stage = 0;
		string order = " ",step = " ";

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

		private void btnClear_Click(object sender, EventArgs e)
		{
			lblDisplay.Text = "0";
			stage = 0;
			a = b = 0;
		}

		private void btnEqual_Click(object sender, EventArgs e)
		{
			CalculateStage();
			step = "chain";

		}
	private void btnPlus_Click(object sender, EventArgs e)
		{
			if (step != "chain")
			{
				CalculateStage();
			}
			stage = 1;
			step = " ";

			/*if (stage != 1)
			{
				a = Int32.Parse(lblDisplay.Text);
			}
			else if (stage == 1)
			{
				b = Int32.Parse(lblDisplay.Text);
				lblDisplay.Text = (a + b).ToString();
			}

			order = "clear";
			stage = 1;
			//lblDisplay.Text = lblDisplay.Text + "+";*/
		}

		private void btnDivide_Click(object sender, EventArgs e)
		{
			if (step != "chain")
			{
				CalculateStage();
			}
			stage = 4;
			step = " ";
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			if (Convert.ToDouble(lblDisplay.Text) > -10 && Convert.ToDouble(lblDisplay.Text) < 10)
			{
				lblDisplay.Text = "0";
			}
			else
			{

				lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
			}
		}

		private void btnPercent_Click(object sender, EventArgs e)
		{
			b = Convert.ToDouble(lblDisplay.Text) / 100;
			lblDisplay.Text = b.ToString();

			if (stage == 1 || stage == 2)
			{
				b = a * b;
				lblDisplay.Text = b.ToString();
			}
			else if (stage == 3 || stage == 4)
			{
			}

			step = " ";
			//CalculateStage();
		}

		private void btnSign_Click(object sender, EventArgs e)
		{
			lblDisplay.Text = ((-1) * Convert.ToDouble(lblDisplay.Text)).ToString();
			step = " ";
		}

		private void btnMinus_Click(object sender, EventArgs e)
		{
			if (step != "chain")
			{
				CalculateStage();
			}
			step = " ";
			stage = 2;
		}

		private void btnMultiply_Click(object sender, EventArgs e)
		{
			if (step != "chain")
			{
				CalculateStage();
			}
			stage = 3;
			step = " ";
		}
	}
}
