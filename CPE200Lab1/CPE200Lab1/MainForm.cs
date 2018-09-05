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
        private string before_operate;
        //LinkedList<double> memory = new LinkedList<double>();
        double memory = 0;
        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
        }
        CalculatorEngine engine = new CalculatorEngine();
        public MainForm()
        {
            InitializeComponent();
            //CalculatorEngine engine = new CalculatorEngine();
            resetAll();
        }

        private void Memory_function(string operate)
        {
            switch (operate)
            {
                case "MC":
                    {
                        //memory.Clear();
                        memory = 0;
                        break;
                    }
                case "MR":
                    {
                        //lblDisplay.Text = (memory.First.Value).ToString();
                        lblDisplay.Text = memory.ToString();
                        break;
                    }
                case "M+":
                    {
                        /*
                        bool isEmpty = !memory.Any();
                        double result;
                        if (isEmpty)
                        {
                            result = memory.First.Value + Convert.ToDouble(lblDisplay.Text);
                            memory.RemoveFirst();
                            memory.AddFirst(result);
                        }
                        */
                        memory += Convert.ToDouble(lblDisplay.Text);
                        break;
                    }
                case "M-":
                    {
                        /*
                        bool isEmpty = !memory.Any();
                        double result;
                        if (isEmpty)
                        {
                            result = memory.First.Value - Convert.ToDouble(lblDisplay.Text);
                            memory.RemoveFirst();
                            memory.AddFirst(result);
                        }
                        */
                        memory -= Convert.ToDouble(lblDisplay.Text);
                        break;
                    }
                case "MS":
                    {
                        memory = Convert.ToDouble(lblDisplay.Text);
                        break;
                    }
            }
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
                    before_operate = operate;
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    //firstOperand = lblDisplay.Text;
                    string secondOperand = lblDisplay.Text;
                    lblDisplay.Text = engine.calculate(operate, firstOperand, secondOperand, 8);
                    break;
                case "1/x":
                    firstOperand = lblDisplay.Text;
                    lblDisplay.Text = engine.calculate(operate, firstOperand, firstOperand, 8);
                    //isAfterOperater = true;
                    break;
                case "√":
                    firstOperand = lblDisplay.Text;
                    lblDisplay.Text = engine.calculate(operate, firstOperand, firstOperand, 8);
                    //isAfterOperater = true;
                    break;
                case "MC":
                case "MS":
                case "MR":
                case "M+":
                case "M-":
                    {
                        Memory_function(operate);
                        break;
                    }
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
            string result = engine.calculate(before_operate, firstOperand, secondOperand);
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
    }
}
