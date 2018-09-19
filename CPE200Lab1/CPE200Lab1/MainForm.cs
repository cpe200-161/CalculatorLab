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
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string secondOperand; //Declare for store second number
        private string operate;
        CalculatorEngine engine; //Call CaculatorEngine class
        int check;
        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            check = -1; //Default value
        }

        public MainForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine(); //Make new classtype CalculatorEngine name engine
            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if(lblDisplay.Text.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if(lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
        }
       
        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                    check = 0; //Store the check case then pass to calculator class in btnEqual click
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "-":
                    check = 1;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "X":
                    check = 2;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "÷":
                    check = 3;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "1/X":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "√":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    secondOperand = Convert.ToDouble(firstOperand).ToString(); //Store the second then pass to calculator class in btnEqual click
                    isAfterOperater = true;
                    break;
            }
            isAllowBack = false;
        }

        string result; //Store the result after calculate
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;
            result = engine.calculate(check,operate, firstOperand, secondOperand); //pass value to calculate
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            isAfterEqual = true;
        }
       
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if(lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            } else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if(lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if(rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if(lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        double M; 
        private void btnMplus_Click(object sender, EventArgs e)
        {
            M += Convert.ToDouble(lblDisplay.Text);
            lblDisplay.Text = "0";
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = M.ToString();
        }

        private void btnMminus_Click(object sender, EventArgs e)
        {
            M -= Convert.ToDouble(lblDisplay.Text);
            lblDisplay.Text = "0";
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            M = 0;
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            M = Convert.ToDouble(lblDisplay.Text);
           lblDisplay.Text = "0";
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
         if (firstOperand != "0")
            {
                double result;
                string[] parts;
                int remainLength;
           
                result = Math.Sqrt(Convert.ToDouble(lblDisplay.Text)); //Square root calculate
                parts = result.ToString().Split('.');
                if (parts[0].Length > 8)
                {
                     lblDisplay.Text = "E";
                }
                remainLength = 8- parts[0].Length - 1;
                lblDisplay.Text= result.ToString("N" + remainLength); //Show result after calculate
            }
        }

        private void btnOnedivideX_Click(object sender, EventArgs e)
        {
            if (firstOperand != "0")
            {
                double result;
                string[] parts;
                int remainLength;

                result = (1 / Convert.ToDouble(lblDisplay.Text)); //1/X calculate
                parts = result.ToString().Split('.');
                if (parts[0].Length > 8)
                {
                    lblDisplay.Text = "E";
                }
                remainLength = 8 - parts[0].Length - 1;
                lblDisplay.Text = result.ToString("N" + remainLength); //Show result after calculate
            }
        }
    }
}
