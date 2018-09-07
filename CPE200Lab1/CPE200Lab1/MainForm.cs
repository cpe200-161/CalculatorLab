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
        private string operate;
        private string memory;
        private string memoryOperate;
        private CalculatorEngine engine;

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

            // 1. new CalculatorEngine() => instantiate an object
            // 2. reference to that object with engine variable
            // LHS = RHS
            engine = new CalculatorEngine();
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
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if (lblDisplay.Text is "0")
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
                case "-":
                case "X":
                case "÷":
                case "√":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    if (isAfterOperater == true)
                    {
                        string secondOperand = lblDisplay.Text;
                    }
                    break;
                case "1/X":
                    lblDisplay.Text = (1 / double.Parse(lblDisplay.Text)).ToString().Substring(0,8);
                    break;
            }
            isAllowBack = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;
            string result = engine.calculate(operate, firstOperand, secondOperand);
            if (result is "E")
            {
                lblDisplay.Text = "Error";
            }
            else if(result.Length > 8)
            {
                lblDisplay.Text = result.Substring(0,8);
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
            if (lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            }
            else
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
            if (lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if (rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void buttonMemory_Click(object sender, EventArgs e)
        {
            memoryOperate = ((Button)sender).Text;
            switch (memoryOperate)
            {
                case "MS": //Memory Saved
                    memory = lblDisplay.Text;
                    break;
                case "MR": //Memory Recalled
                    lblDisplay.Text = memory;
                    break;
                case "M+": //Memory Add
                    if (memory == null) return;
                    else
                    {
                        memory = (double.Parse(memory) + double.Parse(lblDisplay.Text)).ToString();
                        lblDisplay.Text = memory;
                        break;
                    }
                case "M-": //Memory Subtract
                    if (memory == null) return;
                    else
                    {
                        memory = (double.Parse(memory) - double.Parse(lblDisplay.Text)).ToString();
                        lblDisplay.Text = memory;
                        break;
                    }
                case "MC": //Memory Clear
                    memory = null;
                    isAfterOperater = false;
                    isAllowBack = true;
                    return;
            }
            isAfterOperater = true;
            isAllowBack = false;
        }
    }
}
