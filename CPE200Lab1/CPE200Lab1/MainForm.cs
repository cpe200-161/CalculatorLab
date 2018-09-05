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
        private string secondOperand;
        private string operate;
        
        int per;

        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
        }
        CalculatorEngine engine;
        public MainForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            resetAll();
            memory = 0;
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
                    per = 0;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "-":
                    per = 1;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "X":
                    per = 2;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "÷":
                    per = 3;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    secondOperand = firstOperand;
                    isAfterOperater = true;
                    break;
                    
                case "√":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "1/X":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
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
            string result = engine.calculate(per,operate, firstOperand, secondOperand);
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

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private double memory;
        private string operateMemory;
        private void btnMemory_Click(object sender, EventArgs e)
        {
            operateMemory = ((Button)sender).Text;
            switch (operateMemory)
            {
                case "Ms":
                    memory = Double.Parse(lblDisplay.Text);
                    break;
                case "Mc":
                    memory = 0;
                    break;
                case "Mr":
                    lblDisplay.Text = memory.ToString();
                    break;
                case "M+":
                   
                    memory += Convert.ToDouble(lblDisplay.Text);
                    lblDisplay.Text = "0";
                    break;
                case "M-":
                    memory -= Convert.ToDouble(lblDisplay.Text);
                    lblDisplay.Text = "0";
                    break;

                default:
                    break;
            }

            Console.WriteLine(operateMemory);
            Console.WriteLine(memory);
        }

        private void btnOnedivX_Click(object sender, EventArgs e)
        {
            // Not allow devide be zero
            if (firstOperand != "0")
            {
                double result;
                string[] parts;
                int remainLength;

                result = (1 / Convert.ToDouble(lblDisplay.Text));
                // split between integer part and fractional part
                parts = result.ToString().Split('.');
                // if integer part length is already break max output, return error
                if (parts[0].Length > 8)
                {
                    lblDisplay.Text = "E";
                }
                // calculate remaining space for fractional part.
                remainLength = 8 - parts[0].Length - 1;
                // trim the fractional part gracefully. =
                lblDisplay.Text = result.ToString("N" + remainLength);
            }
        }
    }
}
