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
        private string firstOperand = null;
        private string secondOperand = null;
        private string operate;
        private string tempOperate = null;
        private bool percentOperate = false;
        private string[] memoryAdd = new string[100];
        private string tempEqualM = null;
        private int count = 0;


        public CalculatorEngine engine;


        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;

            percentOperate = false;

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

            operate = ((Button)sender).Text;

            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = lblDisplay.Text;
                    tempOperate = operate;
                    isAfterOperater = true;
                    break;
                case "%":
                    if (tempOperate == null)
                    {
                        lblDisplay.Text = "Error";
                        break;
                    }
                    secondOperand = lblDisplay.Text;
                    secondOperand = ((Convert.ToDouble(secondOperand) / 100) * Convert.ToDouble(firstOperand)).ToString();
                    lblDisplay.Text = secondOperand;
                    operate = tempOperate;
                    percentOperate = true;
                    
                    break;

                case "1/x":
                  
                    string tempx = (1 / Convert.ToDouble(lblDisplay.Text)).ToString();

                    if (firstOperand == null) firstOperand = tempx;
                    else
                    {
                        secondOperand = tempx;
                        operate = tempOperate;
                    }
                    lblDisplay.Text = tempx;
                    isAfterOperater = true;


                    break;



                case "√":

                    double x = Convert.ToDouble(lblDisplay.Text);
                    string tempsqroot = Convert.ToDouble(Math.Sqrt(x)).ToString();
                    if (firstOperand == null) firstOperand = tempsqroot;
                    else
                    {
                        secondOperand = tempsqroot;
                        operate = tempOperate;
                    }
                    lblDisplay.Text = tempsqroot;
                    isAfterOperater = true;
                    break;

                case "M+":
                    memoryAdd[count] = lblDisplay.Text;
                    if (count >= 2) tempEqualM = (Convert.ToDouble(tempEqualM) + Convert.ToDouble(memoryAdd[count])).ToString();
                    if (count == 1)
                    {
                        tempEqualM = (Convert.ToDouble(memoryAdd[count - 1]) + Convert.ToDouble(memoryAdd[count])).ToString();

                    }
                    count++;
                    isAfterOperater = true;
                    break;
                case "M-":
                    tempEqualM = (Convert.ToDouble(tempEqualM) - Convert.ToDouble(lblDisplay.Text)).ToString();
                    isAfterOperater = true;
                    break;


                case "MR":

                    lblDisplay.Text = tempEqualM;
                    operate = tempOperate;
                    isAfterOperater = true;

                    break;
                case "MC":
                    count = 0;
                    for (int i = 0; i < memoryAdd.Length; i++)
                    {
                        memoryAdd[i] = "0";
                    }
                    tempEqualM = "0";
                    isAfterOperater = true;
                    break;
                case "MS":
                    count = 0;
                    for (int i = 0; i < memoryAdd.Length; i++)
                    {
                        memoryAdd[i] = "0";
                    }
                    tempEqualM = "0";
                    memoryAdd[count] = lblDisplay.Text;
                    tempEqualM = (Convert.ToDouble(memoryAdd[0])).ToString();
                    count++;
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

            if (percentOperate == false ) secondOperand = lblDisplay.Text;

            string result = engine.calculate(operate, firstOperand, secondOperand);
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            percentOperate = false;
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

       
    }
}













