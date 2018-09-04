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
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        private string memory;
        public CalculatorEngine engine;

        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            isAfterOperater = false;
            isAfterEqual = false;
        }

        private void resetDisplay()
        {
            isAfterOperater = true;
        }

        public MainForm()
        {
            InitializeComponent();

            resetAll();
            memoryReset();
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
            string btnOperator = ((Button)sender).Text;
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            switch (btnOperator)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    operate = btnOperator;
                    firstOperand = lblDisplay.Text;
                    resetDisplay();
                    break;
                case "%":
                    // your code here
                    if (isAfterOperater)
                    {
                        lblDisplay.Text = engine.calculate(btnOperator, firstOperand, null);
                    }
                    else
                    {
                        lblDisplay.Text = engine.calculate(btnOperator, firstOperand, lblDisplay.Text);
                    }
                    System.Console.WriteLine(firstOperand);
                    break;
                case "√":
                case "1/X":
                    lblDisplay.Text = engine.calculate(btnOperator, lblDisplay.Text, null); 
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
            if (lblDisplay.Text.IndexOf('.') == -1)
            {
                lblDisplay.Text += ".";
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
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if(lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnMemoryStoring_Click(object sender, EventArgs e)
        {
            // Enable MC and MR button
            if(memory == null)
            {
                btnMemoryClear.Enabled = true;
                btnMemoryRecall.Enabled = true;
            }

            string btnMemoryOption = ((Button)sender).Text;
            // Edit memory
            switch (btnMemoryOption)
            {
                case "MS":
                    memory = lblDisplay.Text;
                    break;
                case "M-":
                    memory = engine.calculate("-", (memory == null) ? "0" : memory, lblDisplay.Text);
                    break;
                case "M+":
                    memory = engine.calculate("+", (memory == null) ? "0" : memory, lblDisplay.Text);
                    break;
            }
            resetDisplay();
        }

        private void btnMemoryRecall_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = memory;
            resetDisplay();
        }

        private void btnMemoryClear_Click(object sender, EventArgs e)
        {
            memoryReset();
        }

        private void memoryReset()
        {
            memory = null;
            //Disable MC and MR button
            btnMemoryClear.Enabled = false;
            btnMemoryRecall.Enabled = false;
        }
    }
}
