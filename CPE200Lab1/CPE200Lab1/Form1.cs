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
		float FOP = 0, Sop = 0, Res = 0, Check = 0, HeroB = 0;
		int countdot = 0, countOP = 0, n = 0 , m = 0;

		public Form1()
		{
		InitializeComponent();
		}


		private void btnNum_Click(object sender, EventArgs e)
		{
		Button btn = (Button)sender;
		countOP = 0;
		m++;
		if (lblDisplay.Text == "0")
		{
		lblDisplay.Text = "";
		}
		if (lblDisplay.Text.Length < 8)
		{
		lblDisplay.Text = lblDisplay.Text + btn.Text;
		}
		}



		private void btnDot_Click(object sender, EventArgs e)
		{
		if (countdot == 0)
		{
		lblDisplay.Text = lblDisplay.Text + ".";
		countdot++;
		}

		}



		private void btnOP_click(object sender, EventArgs e)
		{
		Button btn = (Button)sender;
		n += 1;
		m++;
		if (countOP == 0)
		{
		if (((btn.Text == "+") || (btn.Text == "-") || (btn.Text == "X") || (btn.Text == "÷")) & Check != 0)
		{
		Sop = float.Parse(lblDisplay.Text);
		if (Check == 1)
		{
		Res = FOP + Sop;
		lblDisplay.Text = "";
		}
		if (Check == 2)
		{
		Res = FOP - Sop;
		lblDisplay.Text = "";
		}
		if (Check == 3)
		{
		Res = FOP * Sop;
		lblDisplay.Text = "";
		}
		if (Check == 4)
		{
		Res = FOP / Sop;
		lblDisplay.Text = "";
		}
		lblDisplay.Text = Convert.ToString(Res);
		FOP = 0;
		Sop = 0;
		Check = 0;
		countdot = 0;
		}

		if (btn.Text == "+")
		{
		FOP = float.Parse(lblDisplay.Text);
		lblDisplay.Text = "";
		Check = 1;
		}
		if (btn.Text == "-")
		{
		FOP = float.Parse(lblDisplay.Text);
		lblDisplay.Text = "";
		Check = 2;
		}
		if (btn.Text == "X")
		{
		FOP = float.Parse(lblDisplay.Text);
		lblDisplay.Text = "";
		Check = 3;
		}
		if (btn.Text == "÷")
		{
		FOP = float.Parse(lblDisplay.Text);
		lblDisplay.Text = "";
		Check = 4;
		}
		countdot = 0;
		countOP++;
		}
		if (countOP != 0)
		{
		lblDisplay.Text = "";
		if (btn.Text == "+") Check = 1;
		if (btn.Text == "-") Check = 2;
		if (btn.Text == "X") Check = 3;
		if (btn.Text == "÷") Check = 4;
		}
		/*	if (n % 2 == 0)
		{
		lblDisplay.Text = Convert.ToString(Res);
		lblDisplay.Text = lblDisplay.Text;
		}
		if (m % 3 == 1 & m >= 4 )
		{
		lblDisplay.Text = "";
		}*/
		}


		private void btnClear_Click(object sender, EventArgs e)
		{
		lblDisplay.Text = "";
		FOP = 0;
		Sop = 0;
		Res = 0;
		countdot = 0;
		HeroB = 0;
		}



		private void btnRes_Click(object sender, EventArgs e)
		{
		Button btn = (Button)sender;
		if (Check == 5)
		{
		lblDisplay.Text = Convert.ToString(Res);
		}
		if (btn.Text == "=" & countOP == 0)
		{
		Sop = float.Parse(lblDisplay.Text);
		if (Check == 1)
		{
		Res = FOP + Sop;
		}
		if (Check == 2)
		{
		Res = FOP - Sop;
		}
		if (Check == 3)
		{
		Res = FOP * Sop;
		}
		if (Check == 4)
		{
		Res = FOP / Sop;
		}
		lblDisplay.Text = Convert.ToString(Res);
		}
		else
		{
		Res = FOP;
		lblDisplay.Text = Convert.ToString(Res);
		}
		FOP = 0;
		Sop = 0;
		Res = 0;
		Check = 0;
		countdot = 0;
		HeroB = 0;
		}
		private void btnPercentage_Click(object sender, EventArgs e)
		{
		Button btn = (Button)sender;
		if(FOP == 0) FOP = float.Parse(lblDisplay.Text);
		else if(FOP != 0) Sop = float.Parse(lblDisplay.Text);
		lblDisplay.Text = "";
		if (btn.Text == "%")
		{
		if (countOP == 0 & Check == 0)
		{
		Res = FOP / 100;
		Check = 5;
		}
		else
		{
		HeroB = Sop / 100;
		if (Check == 1)
		{
		Res = FOP + (((FOP + 1) * HeroB) - HeroB);
		}
		if (Check == 2)
		{
		Res = FOP - (((FOP + 1) * HeroB) - HeroB);
		}
		if (Check == 3)
		{
		Res = FOP * (((FOP + 1) * HeroB) - HeroB);
		}
		if (Check == 4)
		{
		Res = FOP / (((FOP + 1) * HeroB) - HeroB);
		}
		Check = 5;
		}
		}
		countdot = 0;
		}
		}
		}


