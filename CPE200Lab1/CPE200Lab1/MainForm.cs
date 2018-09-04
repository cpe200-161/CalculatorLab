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
        private string secondOperand;   //add secondOperand for store
        private string operate;
        public CalculatorEngine engine; //add engine Calculator for call CalculatorEngine.cs
        public string FristOperate;     //for store +, -, * and / Operate
        public string memoryStoreNumber;//for store number

        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
        }

        public MainForm()
        {
            InitializeComponent();

            resetAll();
            engine = new CalculatorEngine();
            engine.calculate(operate, firstOperand, secondOperand, FristOperate);
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
            if(operate == "+" || operate == "-" || operate == "X" || operate == "÷") //this line for percentage
            {
                FristOperate = operate;
            }
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    hasDot = false;  //edit dot in secondOperand
                    break;
                case "%":
                    // your code here
                    secondOperand = lblDisplay.Text;
                    break;
                case "√":
                    secondOperand = lblDisplay.Text;
                    lblDisplay.Text = engine.calculate(operate, firstOperand, secondOperand, FristOperate);
                    break;
                case "1/x":
                    secondOperand = lblDisplay.Text;
                    lblDisplay.Text = engine.calculate(operate, firstOperand, secondOperand, FristOperate);
                    break;
            }
            isAllowBack = false;
        }

        private void btnSpecialSign_Click(object sender, EventArgs e)
        {
            string button = ((Button)sender).Text;
            string temp;
            switch (button)
            {
                case "MC":
                    memoryStoreNumber = null;
                    break;
                case "MR":
                    lblDisplay.Text = memoryStoreNumber;
                    break;
                case "MS":
                    memoryStoreNumber = lblDisplay.Text;
                    break;
                case "M+":
                    temp = (Convert.ToDouble(memoryStoreNumber) + Convert.ToDouble(lblDisplay.Text)).ToString();
                    memoryStoreNumber = temp;
                    break;
                case "M-":
                    temp = (Convert.ToDouble(memoryStoreNumber) - Convert.ToDouble(lblDisplay.Text)).ToString();
                    memoryStoreNumber = temp;
                    break;
                case "CE":
                    lblDisplay.Text = "0";
                    break;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;
            string result = engine.calculate(operate, firstOperand, secondOperand, FristOperate);
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
            if (isAfterEqual)
            {
                resetAll();
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
    }
}
