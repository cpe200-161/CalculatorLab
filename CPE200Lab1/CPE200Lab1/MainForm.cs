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
       
        private int maxOutputSize = 8;
        private string operate;
        private string operate2;
        private double memory;
               
        public CalculatorEngine engine;

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
            engine.calculate(operate,firstOperand,secondOperand,operate2 ,maxOutputSize);
            Btn_MC.Enabled = false;     //close function until click MS
            Btn_MR.Enabled = false;     //close function until click MS


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
            operate2 = operate;
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                case "√":
                case "1/x":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    isAfterOperater = true;
                    break;

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
            string result = engine.calculate(operate, firstOperand, secondOperand,operate2);
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

        private void Btn_MS_Click(object sender, EventArgs e)
        {
            memory = double.Parse(lblDisplay.Text);
            Btn_MC.Enabled = true;
            Btn_MR.Enabled = true;
        }

        private void Btn_MR_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = memory.ToString();
        }

        private void memory_equal_Click(object sender, EventArgs e)
        {
            memory += Convert.ToDouble(lblDisplay.Text);
        }

        private void Btn_MC_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            memory = 0;
            Btn_MC.Enabled = false;
            Btn_MR.Enabled = false;
        }

        private void memory_minus_Click(object sender, EventArgs e)
        {
            memory -= Convert.ToDouble(lblDisplay.Text);
        }
    }
}
