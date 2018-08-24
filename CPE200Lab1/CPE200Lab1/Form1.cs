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
		float Sum = 0;
		float R = 0;
		float H = 0;
		int count = 0;
		string X = "";
		bool check1 = false;
		bool check2 = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void btnx_Click(object sender, EventArgs e)
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
			if (lblDisplay.Text.Length <= 8)
			{
				lblDisplay.Text = lblDisplay.Text + btn.Text;
			}
			check2 = true;
		}



		/*-ต้องเซฟตัวแรกไว้ให้ได้ก่อน
		-ถ้ามีตัวแรก*/


		private void btnEqual_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			switch (X)
			{
				case "+":
					if (count == 1)
					{
						Sum = Sum + float.Parse(lblDisplay.Text);
						lblDisplay.Text = Sum.ToString();
					}
					break;
				case "-":
					if (count == 1) {
						Sum = Sum - float.Parse(lblDisplay.Text);
						lblDisplay.Text = Sum.ToString();
					}
					break;
				case "/":
					if (count == 1)
					{
						Sum = Sum / float.Parse(lblDisplay.Text);
						lblDisplay.Text = Sum.ToString();
					}
					break;
				case "X":
					if (count == 1)
					{
						Sum = Sum * float.Parse(lblDisplay.Text);
						lblDisplay.Text = Sum.ToString();
					}
					break;
			}
			Sum = float.Parse(lblDisplay.Text);
			if (Sum % 2 != 0)
			{
				check1 = true;
			}
			X = btn.Text;
			count = 2;
			check2 = false;
			check1 = false;
		}

		private void btndot_Click(object sender, EventArgs e)
		{
			if (check1 == false && count == 2)
			{
				lblDisplay.Text = "0" + ".";
				check1 = true;
			} else if (check1 == false)
			{
				lblDisplay.Text = lblDisplay.Text + ".";
				check1 = true;
			}
		}

		private void btnSign_Click(object sender, EventArgs e)
		{
			R = -float.Parse(lblDisplay.Text);
			lblDisplay.Text = R.ToString();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			lblDisplay.Text = string.Empty;
			lblDisplay.Text = "0";
			Sum = 0;
			R = 0;
			count = 0;
			X = "";
			check1 = false;
			check2 = false;
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			if (check2 == true)
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
			H = float.Parse(lblDisplay.Text);
			switch (X)
			{
				case "+":
					Sum = Sum + (Sum*(H / 100));
					break;
				case "-":
					Sum = Sum - (Sum * (H / 100));
					break;
				case "X":
					Sum = (Sum * (H / 100));
					break;
				case "/":
					Sum = (Sum / (H / 100));  
					break;
			}
			lblDisplay.Text = Sum.ToString();
			Sum = float.Parse(lblDisplay.Text);
			X = "";
		}
	}
	}

 