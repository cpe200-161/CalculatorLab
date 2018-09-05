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
        private string operate2;
        private double result1 = 0;
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
            //1. new CalculatorEngine() => instantiate an object
            //2. reference to that object whith engine variable
            //เอาค่าที่ได้ไปเก็บไว้ตัวแปลข้างซ้าย
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
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    operate2 = "+";
                    break;
                case "-":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    operate2 = "-";
                    break;
                case "X":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    operate2 = "X";
                    break;
                case "÷":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    string secondOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "√":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "1/x":
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
            string result = engine.calculate(operate2,operate, firstOperand, secondOperand, result1);
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
        private void btnCE_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }
        private void btnMplus_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            result1 += (Convert.ToDouble(firstOperand));
            resetAll();
        }
        private void btnMminus_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            result1 -= (Convert.ToDouble(firstOperand));
            resetAll();
        }
        private void btnMR_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = result1.ToString();
        }
        private void btnMS_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            result1 = (Convert.ToDouble(firstOperand));
            resetAll();
        }
        private void btnMC_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            result1 = 0;
        }
    }
}
