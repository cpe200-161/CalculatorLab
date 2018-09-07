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
        private Double M;
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater,isAfterMem,isPercentage;
        private bool isAfterEqual;
        private string firstOperand ;
        private string operate,Mem_Operate;
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
            // 2. reference to that object with engine virable
            // LHS =RHS
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
            if (isAfterOperater||isAfterMem)
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
            isAfterMem = false;
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
            
            switch (((Button)sender).Text)
            {
                case "%":
                    isPercentage = true;
                    string secondOperand = lblDisplay.Text;
                    break;
                case "+":
                case "-":
                case "X":
                    case "√":
                case "1/X":
                case "÷":
                    operate = ((Button)sender).Text;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                
                
            }
            isAllowBack = false;
        }

        private void btnMemory_Click(object sender,EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            Mem_Operate = ((Button)sender).Text;

            switch (Mem_Operate)
            {
                case "MC": M = 0; break;
                case "MR": lblDisplay.Text = Convert.ToString(M); break;
                case "M+":M = M + Convert.ToDouble(lblDisplay.Text); isAfterMem = true; break;
                case "M-": M = M - Convert.ToDouble(lblDisplay.Text); isAfterMem = true; break;
                case "MS": M = Convert.ToDouble(lblDisplay.Text); isAfterMem = true; break;
            }
            
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
                lblDisplay.Text = result.Substring(0, 8);
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
