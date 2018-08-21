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
		bool setPercentage = false;

		void saveFirstOperand()
		{
			firstOperand = lblDisplay.Text;
			setFirstOperand = true;
		}
		void isClear()
		{
			calNumber = 0;
			setFirstOperand = false;
			isStartSecondOperand = false;
			setPercentage = false;
		}

		void isEqual()
		{
			if (isStartSecondOperand == true && lblDisplay.Text.Length <= 8)
			{
				if (setPercentage == true)
				{
					result = ((float.Parse(firstOperand) * float.Parse(lblDisplay.Text)) / 100).ToString();
					secondOperand = result;
				}
				else
				{
					secondOperand = lblDisplay.Text;
				}
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
				firstOperand = lblDisplay.Text;
				isClear();
				setFirstOperand = true;
			}
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
				saveFirstOperand();
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
				saveFirstOperand();
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
			if (setFirstOperand == true && calNumber == 0)
			{
				lblDisplay.Text = "";
				setFirstOperand = false;
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
			if (lblDisplay.Text.IndexOf(".") == -1)
			{
				lblDisplay.Text += ".";
			}
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
			if (isStartSecondOperand == true)
			{
				isEqual();
				calNumber = 1;
			}
			else if (setFirstOperand == false || isStartSecondOperand == false)
			{
				calNumber = 1;
				saveFirstOperand();
			}
        }

		private void btnClear_Click(object sender, EventArgs e)
		{
			lblDisplay.Text = "0";
			isClear();
		}

		private void btnMinus_Click(object sender, EventArgs e)
		{
			if (isStartSecondOperand == true)
			{
				isEqual();
				calNumber = 2;
			}
			else if (setFirstOperand == false || isStartSecondOperand == false)
			{
				calNumber = 2;
				saveFirstOperand();
			}
		}

		private void btnPercent_Click(object sender, EventArgs e)
		{
			if (isStartSecondOperand == true)
			{
				setPercentage = true;
			}
			if ((setFirstOperand == false || isStartSecondOperand == false)&&(lblDisplay.Text.Length <= 8))
			{
				firstOperand = lblDisplay.Text;
				result = (float.Parse(firstOperand)/100).ToString();
				lblDisplay.Text = result;
				firstOperand = lblDisplay.Text;
				isClear();
			}
		}

		private void btnSign_Click(object sender, EventArgs e)
		{
			result = (float.Parse(lblDisplay.Text) * (-1)).ToString();
			lblDisplay.Text = result;
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			if (lblDisplay.Text != "0")
			{
				lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
				if (lblDisplay.Text == "" || lblDisplay.Text == "-")
				{
					lblDisplay.Text = "0";
				}
			}
		}
	}
}
