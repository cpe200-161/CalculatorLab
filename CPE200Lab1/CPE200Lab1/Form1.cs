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
        string firstOperand;
        string secondOperand;
		string result;
		bool setFirstOperand = false;
        bool isStartSecondOperand = false;
		bool setDot = false;
		bool setPlus = false;
		bool setMinus = false;
		bool setMultiply = false;
		bool setDivide = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
			setDivide = true;
			setPlus = false;
			setMinus = false;
			setMultiply = false;
			firstOperand = lblDisplay.Text;
			setFirstOperand = true;
		}

        private void btnMultiply_Click(object sender, EventArgs e)
        {
			setMultiply = true;
			setPlus = false;
			setMinus = false;
			setDivide = false;
			firstOperand = lblDisplay.Text;
			setFirstOperand = true;
		}

        private void btnEqual_Click(object sender, EventArgs e)
        {
            secondOperand = lblDisplay.Text;
			if (setPlus == true)
			{
				result = (float.Parse(firstOperand) + float.Parse(secondOperand)).ToString();
				lblDisplay.Text = result;
			}
			else if (setMinus == true)
			{
				result = (float.Parse(firstOperand) - float.Parse(secondOperand)).ToString();
				lblDisplay.Text = result;
			}
			else if (setMultiply == true)
			{
				result = (float.Parse(firstOperand) * float.Parse(secondOperand)).ToString();
				lblDisplay.Text = result;
			}
			else if (setDivide == true)
			{
				result = (float.Parse(firstOperand) / float.Parse(secondOperand)).ToString();
				lblDisplay.Text = result;
			}
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" )
            {
                lblDisplay.Text = "";
            }
            if(setFirstOperand == true && isStartSecondOperand == false)
            {
                lblDisplay.Text = null;
                isStartSecondOperand = true;
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }    
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
			if (setDot == false)
			{
				lblDisplay.Text += ".";
			}
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
			setPlus = true;
			setMinus = false;
			setMultiply = false;
			setDivide = false;
			if (setFirstOperand == true)
			{
				secondOperand = lblDisplay.Text;
				result = (float.Parse(firstOperand) + float.Parse(secondOperand)).ToString();
				lblDisplay.Text = result;
				firstOperand = lblDisplay.Text;
				isStartSecondOperand = false;
				setPlus = false;
			}
			else if (setFirstOperand == false)
			{
				firstOperand = lblDisplay.Text;
				setFirstOperand = true;
			}
        }

		private void btnClear_Click(object sender, EventArgs e)
		{
			lblDisplay.Text = "0";
			setFirstOperand = false;
			isStartSecondOperand = false;
			setDot = false;
			setPlus = false;
			setMinus = false;
			setMultiply = false;
			setDivide = false;
		}

		private void btnMinus_Click(object sender, EventArgs e)
		{
			setMinus = true;
			setPlus = false;
			setMultiply = false;
			setDivide = false;
			if (setFirstOperand == true)
			{
				secondOperand = lblDisplay.Text;
				result = (float.Parse(firstOperand) - float.Parse(secondOperand)).ToString();
				lblDisplay.Text = result;
				firstOperand = lblDisplay.Text;
				isStartSecondOperand = false;
				setMinus = false;
			}
			else if (setFirstOperand == false)
			{
				firstOperand = lblDisplay.Text;
				setFirstOperand = true;
			}
		}
	}
}
