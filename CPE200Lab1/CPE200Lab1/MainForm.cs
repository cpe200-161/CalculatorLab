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
        private CalculatorEngine engine;
        private string PrevOperator;
        private double Memo = 0;

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
                    PrevOperator = operate;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "-":
                    PrevOperator = operate;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "X":
                    PrevOperator = operate;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "÷":
                    PrevOperator = operate;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    lblDisplay.Text = engine.calculate(operate, firstOperand, lblDisplay.Text);
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
            string result = engine.calculate(PrevOperator, firstOperand, secondOperand);
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

        private void button_sqrt(object sender, EventArgs e)
        {
            double tmp;
            firstOperand = lblDisplay.Text;
            tmp = Convert.ToDouble(firstOperand);
            double result = Math.Sqrt(Convert.ToDouble(firstOperand));
            if (tmp <=0)
            {
                lblDisplay.Text = "Error"; 
            }else
            {
                lblDisplay.Text = result.ToString().Substring(0,8);
            }
            

        }

        private void button_oneoverX(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            if (firstOperand == "0")
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                double result = 1 / (Convert.ToDouble(firstOperand));
                lblDisplay.Text = result.ToString().Substring(0, 8);
            }

        }

        private void button_Memory(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "MC")
            {
                Memo = 0;
                isAfterOperater = true;
            }
            else if (btn.Text == "MR")
            {
                lblDisplay.Text = Memo.ToString();
                isAfterOperater = true;
            }
            else if (btn.Text == "MS")
            {
                Memo = Convert.ToDouble(lblDisplay.Text);
                isAfterOperater = true;
            }
            else if (btn.Text == "M+")
            {
                Memo += Convert.ToDouble(lblDisplay.Text);
                isAfterOperater = true;
            }
            else if (btn.Text == "M-")
            {
                Memo -= Convert.ToDouble(lblDisplay.Text);
                isAfterOperater = true;
            }

         
        }

        private void button_CE(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }
    }
}
