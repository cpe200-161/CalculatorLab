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
        private bool isPercent;
        private string firstOperand;
        private string operate;
        private string operatebefore;
        private string result;
        private double percent;
        private double resultpercent;
        private string memorybtn;
        private double memory;
        private double memoryrecord;
        private int first = 0;
        CalculatorEngine engine;


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
            engine = new CalculatorEngine();
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

        private void btnMemory_Click(object sender , EventArgs e)
        {
            memorybtn = ((Button)sender).Text;
            switch (memorybtn)
            {
                case "M+":
                    memory = Double.Parse(lblDisplay.Text);
                    memoryrecord = memoryrecord + memory;
                    break;
                case "M-":
                    memory = Double.Parse(lblDisplay.Text);
                    memoryrecord = memoryrecord - memory;
                    break;
                case "MS":
                    memory = Double.Parse(lblDisplay.Text);
                    memoryrecord = memory;
                    break;
                case "MR":
                    lblDisplay.Text = (memoryrecord).ToString() ;
                    break;
                case "MC":
                    memory = memoryrecord = 0;
                    break;
            }
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
            if (first == 0)
            {
                operate = ((Button)sender).Text;
            }
            if (((Button)sender).Text == "%")
            {
                percent = double.Parse(lblDisplay.Text);
                result = engine.calculatepercent(operate, percent, resultpercent, result);
                lblDisplay.Text = result;
                isAfterOperater = true;
                isPercent = true;
            }
            if (isPercent != true)
            {
                switch (operate)
                {
                    case "+":
                    case "-":
                    case "X":
                    case "÷":
                    case "√":
                    case "1/x":
                        firstOperand = lblDisplay.Text;
                        btnEqual_Click(sender, e);
                        resultpercent = double.Parse(result);
                        operatebefore = ((Button)sender).Text;
                        isAfterOperater = true;
                        break;
                }
            }
            else { isPercent =false; }
            first = 1;
            operate = ((Button)sender).Text;
            isAllowBack = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (isAfterEqual == false)
            {
                firstOperand = lblDisplay.Text;
                if (lblDisplay.Text is "Error")
                {
                    return;
                }
                result = engine.calculate(first,operate, operatebefore, percent,resultpercent, firstOperand, result);
                if (result is "E" || result.Length > 8)
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    lblDisplay.Text = result;
                }
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
            result = operate = "0";
            percent = resultpercent = first = 0;
            isPercent = false;
            resetAll();
        }
        private void btnCE_Click(object sender, EventArgs e)
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
