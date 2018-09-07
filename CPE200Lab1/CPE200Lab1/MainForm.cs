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
        private string beforeOperate;
        private string memory;
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
                    firstOperand = lblDisplay.Text;
                    beforeOperate = "+";
                    isAfterOperater = true;
                    break;
                case "-":
                    firstOperand = lblDisplay.Text;
                    beforeOperate = "-";
                    isAfterOperater = true;
                    break;
                case "X":
                    firstOperand = lblDisplay.Text;
                    beforeOperate = "X";
                    isAfterOperater = true;
                    break;
                case "÷":
                    firstOperand = lblDisplay.Text;
                    beforeOperate = "÷";
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    secondOperand = lblDisplay.Text;
                    lblDisplay.Text = engine.calculate(operate, firstOperand, secondOperand);
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
            secondOperand = lblDisplay.Text;
            string result = engine.calculate(beforeOperate, firstOperand, secondOperand);
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

        private void btnoneOverX_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (1 / Convert.ToDouble(lblDisplay.Text)).ToString();
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (Math.Sqrt(Convert.ToDouble(lblDisplay.Text))).ToString();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memory = "0";
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = memory;
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            memory = lblDisplay.Text;
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            memory = (Convert.ToDouble(memory) + Convert.ToDouble(lblDisplay.Text)).ToString();
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            memory = (Convert.ToDouble(memory) - Convert.ToDouble(lblDisplay.Text)).ToString();
        }
    }
}
