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
        private bool isAfterOperate;
        private bool isAfterEqual;
        private string firstOperand;
        private string secondOperand;
        private string operate;
        private string operater;
        private string anyM;
        private string rememM;

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
            if (isAfterOperate)
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
            isAfterOperate = false;
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperate)
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
                    firstOperand = lblDisplay.Text;
                    isAfterOperate = true;
                    Display.Text = lblDisplay.Text + operate;
                    break;
                case "1/x":
                    Display.Text = Display.Text + "1/" + lblDisplay.Text;
                    firstOperand = lblDisplay.Text;
                    isAfterOperate = true;
                    break;
                case "√":
                    Display.Text = Display.Text + "√" + lblDisplay.Text;
                    firstOperand = lblDisplay.Text;
                    isAfterOperate = true;
                    break;
            }
            isAllowBack = false;
        }

        private void btnSecondOperate_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operater = ((Button)sender).Text;
            switch (operater)
            {
                case "%":
                    Display.Text = Display.Text + lblDisplay.Text + "%" ;
                    secondOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
               
            }
            isAllowBack = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Display.Text = "";
                if (lblDisplay.Text is "Error")
                {
                    return;
                }
                secondOperand = lblDisplay.Text;
                string result = engine.calculate(operate, firstOperand, secondOperand, operater );
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

        private void AnyM_Click(object sender, EventArgs e)
        {
            anyM = ((Button)sender).Text;
            if (anyM == "MC")   rememM = "";
            else if (anyM == "MS")  rememM = lblDisplay.Text;
            else if (anyM == "MR")  lblDisplay.Text = rememM;
            else if (anyM == "M+")  rememM = (Convert.ToDouble(rememM) + Convert.ToDouble(lblDisplay.Text)).ToString();
            else if (anyM == "M-")  rememM = (Convert.ToDouble(rememM) - Convert.ToDouble(lblDisplay.Text)).ToString();
        }
    }
}
