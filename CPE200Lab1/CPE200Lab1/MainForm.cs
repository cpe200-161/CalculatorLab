using CPE200Lab1.CPE200Lab1;
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
        //private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string oper;
        //private double memory;
        string newOper;
        string secondOperand;
        private SimpleCalculatorEngine myEngine;

        /*private void resetAll()
        {
            lblDisplay.Text = "0";
            secondOperand = null;
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
        }*/

        public MainForm()
        {
            InitializeComponent();
            //memory = 0;
            myEngine = new SimpleCalculatorEngine();
            lblDisplay.Text = "0";
            secondOperand = null;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
        }

        private void number_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                lblDisplay.Text = "0";
                secondOperand = null;
                hasDot = false;
                isAfterOperater = false;
                isAfterEqual = false;
                firstOperand = null;
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            string digit = ((Button)sender).Text;
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            if (firstOperand != null && isAfterEqual == false)
            {
                myEngine.setFirstOperand(lblDisplay.Text);

            }
            oper = ((Button)sender).Text;
            if (oper != "%")
            {
                newOper = ((Button)sender).Text;
            }
            switch (oper)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    myEngine.setFirstOperand(lblDisplay.Text);
                    isAfterOperater = true;
                    break;
                case "%":
                    break;
            }
            if (isAfterEqual)
            {
                myEngine.setFirstOperand(lblDisplay.Text);
                isAfterEqual = false;
            }
            else
            {
                string result = myEngine.calculate(oper, firstOperand, secondOperand);
                if (result is "E" || result.Length > 8)
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    lblDisplay.Text = result;
                }
            }
            // isAllowBack = false;
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            myEngine.setSecondOperand(lblDisplay.Text);
            string result = myEngine.calculate(newOper);
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
                lblDisplay.Text = "0";
                secondOperand = null;
                hasDot = false;
                isAfterOperater = false;
                isAfterEqual = false;
                firstOperand = null;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            secondOperand = null;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
        }

        /*
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
        private void btnMP_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            memory += Convert.ToDouble(lblDisplay.Text);
            isAfterOperater = true;
        }
        private void btnMC_Click(object sender, EventArgs e)
        {
            memory = 0;
        }
        private void btnMM_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            memory -= Convert.ToDouble(lblDisplay.Text);
            isAfterOperater = true;
        }
        private void btnMR_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "error")
            {
                return;
            }
            lblDisplay.Text = memory.ToString();
        }
        */
    }
}