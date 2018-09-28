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
	public partial class ExtendForm : Form
	{
		private CalculatorEngine engine;

		public ExtendForm()
		{
			InitializeComponent();
			engine = Engine();
		}

		protected virtual CalculatorEngine Engine()
		{
			return new CalculatorEngine();
		}

		private bool isOperator(char ch)
		{
			switch (ch)
			{
				case '+':
				case '-':
				case 'X':
				case '÷':
					return true;
			}
			return false;
		}

		private void btnNumber_Click(object sender, EventArgs e)
		{
			if (lblDisplay.Text is "Error")
			{
				return;
			}



			string n = ((Button)sender).Text;
			engine.handleNumber(n);

			lblDisplay.Text = engine.Display();
		}

		public virtual void btnBinaryOperator_Click(object sender, EventArgs e)
		{
			if (lblDisplay.Text is "Error")
			{
				return;
			}
			string n = ((Button)sender).Text;
			engine.handleOperatorClick(n);
			lblDisplay.Text = engine.Display();
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			if (lblDisplay.Text is "Error")
			{
				return;
			}
			// check if the last one is operator
			string current = lblDisplay.Text;
			if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
			{
				lblDisplay.Text = current.Substring(0, current.Length - 3);
			}
			else
			{
				lblDisplay.Text = current.Substring(0, current.Length - 1);
			}
			if (lblDisplay.Text is "")
			{
				lblDisplay.Text = "0";
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{

			engine.handleClear();
			lblDisplay.Text = engine.Display();
		}

		private void btnEqual_Click(object sender, EventArgs e)
		{
			string result = engine.Process(lblDisplay.Text);
			if (result is "E")
			{
				lblDisplay.Text = "Error";
			}
			else
			{
				lblDisplay.Text = result;
			}
		}

		private void btnSign_Click(object sender, EventArgs e)
		{
			if (lblDisplay.Text is "Error")
			{
				return;
			}
			engine.handleSign();
			lblDisplay.Text = engine.Display();
		}

		private void btnDot_Click(object sender, EventArgs e)
		{
			if (lblDisplay.Text is "Error")
			{
				return;
			}
			engine.handleDot();
			lblDisplay.Text = engine.Display();
		}

		private void btnSpace_Click(object sender, EventArgs e)
		{
			if (lblDisplay.Text is "Error")
			{
				return;
			}
			engine.handleSpace();
			lblDisplay.Text = engine.Display();
		}
	}
}