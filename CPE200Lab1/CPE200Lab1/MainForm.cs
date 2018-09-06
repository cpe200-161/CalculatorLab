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
        private string r1;
        private string operate;
        private string operate_before;
        private string save;
        public CalculatorEngine engine;

        private void resetAll()
        {
            operate_before = "";
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
            //1.new calculatorengine = > instantiate an object
            //2.reference to that object with engine variable
            // LHS = RHS
            engine = new CalculatorEngine();
            engine.calculate(operate, firstOperand, secondOperand, 8);
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
                case "-":
                case "X":
                case "÷":
                    operate_before = operate;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    //operate_before = operate;
                    secondOperand = lblDisplay.Text;
                    lblDisplay.Text = engine.calculate(operate, firstOperand, secondOperand, 8);
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
            string result = engine.calculate(operate_before, firstOperand, secondOperand);       //hereeeeeeeeeeeeeeeeeeeeeeeeeee//
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            isAfterEqual = true;                                                       //equal check true
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

        private void button3_Click(object sender, EventArgs e)
        {
            resetAll();
            firstOperand = "0";
        }

        private void btnMplus_Click(object sender, EventArgs e)
        {
            secondOperand = lblDisplay.Text;
            save = engine.calculatefuncM("M+", secondOperand, save);
            lblDisplay.Text = "0";
            
            hasDot = false;
            isAllowBack = false;
            isAfterOperater = true;
            
        }

        private void btnMresult_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = save;
        }

        private void btnMc_Click(object sender, EventArgs e)
        {
            save = "0";
        }

        private void btnMminus_Click(object sender, EventArgs e)
        {
            secondOperand = lblDisplay.Text;
            save = engine.calculatefuncM("M-",secondOperand,save);
            hasDot = false;
            isAllowBack = false;
            isAfterOperater = true;
        }

        private void btnMs_Click(object sender, EventArgs e)
        {
            save = lblDisplay.Text;
            lblDisplay.Text = "0";
        }
    }
}
