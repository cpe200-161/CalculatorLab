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
		float result = 0;
		float inverse = 0;
		float value = 0;
		int count = 0;
		string operator_ = "";
		bool checkdot = false;
		bool checkback = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void btnNummber_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			if (count == 2)
			{
				lblDisplay.Text = string.Empty;
				count = 1;
			}
			if (lblDisplay.Text == "0")
			{
				lblDisplay.Text = "";
			}
			if (lblDisplay.Text.Length < 8)
			{
				lblDisplay.Text = lblDisplay.Text + btn.Text;
			}
			checkback = true;
		}

		private void btnOperation_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			switch (operator_)
			{
				case "+":
					if (count == 1)
					{
						result = result + float.Parse(lblDisplay.Text);
						lblDisplay.Text = result.ToString();
					}
					break;
				case "-":
					if (count == 1)
					{
						result = result - float.Parse(lblDisplay.Text);
						lblDisplay.Text = result.ToString();
					}
					break;
				case "/":
					if (count == 1)
					{
						result = result / float.Parse(lblDisplay.Text);
						lblDisplay.Text = result.ToString();
					}
					break;
				case "X":
					if (count == 1)
					{
						result = result * float.Parse(lblDisplay.Text);
						lblDisplay.Text = result.ToString();
					}
					break;
			}
			result = float.Parse(lblDisplay.Text);
			if (result % 2 != 0)
			{
				checkdot = true;
			}
			operator_ = btn.Text;
			count = 2;
			checkback = false;
			checkdot = false;
		}

		private void btndot_Click(object sender, EventArgs e)
		{
			if (checkdot == false && count == 2)
			{
				lblDisplay.Text = "0" + ".";
				checkdot = true;
			}
			else if (checkdot == false)
			{
				lblDisplay.Text = lblDisplay.Text + ".";
				checkdot = true;
			}
		}

		private void btnSign_Click(object sender, EventArgs e)
		{
			inverse = -float.Parse(lblDisplay.Text);
			lblDisplay.Text = inverse.ToString();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			lblDisplay.Text = string.Empty;
			lblDisplay.Text = "0";
			result = 0;
			inverse = 0;
			count = 0;
			operator_ = "";
			checkdot = false;
			checkback = false;
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			if (checkback == true)
			{
				if (lblDisplay.Text.Length > 1)
				{
					lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
				}
				else
				{
					lblDisplay.Text = "0";
				}
			}
		}

		private void btnpercent_Click(object sender, EventArgs e)
		{
			value = float.Parse(lblDisplay.Text);
			switch (operator_)
			{
				case "+":
					result = result + (result * (value / 100));
					break;
				case "-":
					result = result - (result * (value / 100));
					break;
				case "X":
					result = (result * (value / 100));
					break;
				case "/":
					result = (result / (value / 100));
					break;
			}
			lblDisplay.Text = result.ToString();
			result = float.Parse(lblDisplay.Text);
			operator_ = "";
		}
	}
}

