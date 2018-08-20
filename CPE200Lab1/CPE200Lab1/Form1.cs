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
		int calNumber;
		bool setFirstOperand = false;
        bool isStartSecondOperand = false;
		bool setDot = false;
		void isEqual()
		{
			secondOperand = lblDisplay.Text;
			if (calNumber == 1)
			{
				result = (float.Parse(firstOperand) + float.Parse(secondOperand)).ToString();
				lblDisplay.Text = result;
			}
			else if (calNumber == 2)
			{
				result = (float.Parse(firstOperand) - float.Parse(secondOperand)).ToString();
				lblDisplay.Text = result;
			}
			else if (calNumber == 3)
			{
				result = (float.Parse(firstOperand) * float.Parse(secondOperand)).ToString();
				lblDisplay.Text = result;
			}
			else if (calNumber == 4)
			{
				result = (float.Parse(firstOperand) / float.Parse(secondOperand)).ToString();
				lblDisplay.Text = result;
			}
			else if (calNumber == 5)
			{
				result = ((float.Parse(firstOperand) * float.Parse(secondOperand) / 100)).ToString();
				lblDisplay.Text = result;
			}
			calNumber = 0;
			firstOperand = lblDisplay.Text;
			setFirstOperand = true;
			isStartSecondOperand = false;
		}

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
			if (isStartSecondOperand == true)
			{
				isEqual();
				calNumber = 4;
			}
			else if (setFirstOperand == false || isStartSecondOperand == false)
			{
				calNumber = 4;
				firstOperand = lblDisplay.Text;
				setFirstOperand = true;
			}
		}

        private void btnMultiply_Click(object sender, EventArgs e)
        {
			if (isStartSecondOperand == true)
			{
				isEqual();
				calNumber = 3;
			}
			else if (setFirstOperand == false || isStartSecondOperand == false)
			{
				calNumber = 3;
				firstOperand = lblDisplay.Text;
				setFirstOperand = true;
			}
		}

        private void btnEqual_Click(object sender, EventArgs e)
        {
			isEqual();
			calNumber = 0;
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
			if (isStartSecondOperand == true )
			{
				isEqual();
				calNumber = 1;
			}
			else if (setFirstOperand == false || isStartSecondOperand == false)
			{
				calNumber = 1;
				firstOperand = lblDisplay.Text;
				setFirstOperand = true;
			}
        }

		private void btnClear_Click(object sender, EventArgs e)
		{
			lblDisplay.Text = "0";
			setFirstOperand = false;
			isStartSecondOperand = false;
			calNumber = 0;
		}

		private void btnMinus_Click(object sender, EventArgs e)
		{
			if (isStartSecondOperand == true )
			{
				isEqual();
				calNumber = 2;
			}
			else if (setFirstOperand == false || isStartSecondOperand == false)
			{
				calNumber = 2;
				firstOperand = lblDisplay.Text;
				setFirstOperand = true;
			}
		}

		private void btnPercent_Click(object sender, EventArgs e)
		{
			if (isStartSecondOperand == true)
			{
				isEqual();
				calNumber = 5;
			}
			if (setFirstOperand == false || isStartSecondOperand == false)
			{
				calNumber = 5;
				firstOperand = lblDisplay.Text;
				setFirstOperand = true;
			}
		}
	}
}
