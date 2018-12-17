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
    public partial class ExtendForm : Form
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        protected RPNCalculatorEngine myEngine;
        string M_memory;

        public ExtendForm()
        {
            InitializeComponent();
            myEngine = new RPNCalculatorEngine();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            string operate = ((Button)sender).Text;
            
            switch (operate)
            {
                case "M+":
                    lblDisplay.Text = myEngine.Process(lblDisplay.Text);
                    M_memory = (Convert.ToDouble(M_memory) + Convert.ToDouble(lblDisplay.Text)).ToString();
                    break;
                case "M-":
                    lblDisplay.Text = myEngine.Process(lblDisplay.Text);
                    M_memory = (Convert.ToDouble(M_memory) - Convert.ToDouble(lblDisplay.Text)).ToString();
                    break;
                case "MR":
                    lblDisplay.Text = M_memory.ToString();
                    break;
                case "MS":
                    M_memory = lblDisplay.Text;
                    break;
                case "MC":
                    M_memory = "";
                    break;

            }
        }

        private bool isOperator(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case 'X':
                case '÷':
                case '%':
                    return true;
            }
            return false;
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (-1 * Convert.ToDouble(lblDisplay.Text)).ToString();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            lblDisplay.Text += ((Button)sender).Text;
            isSpaceAllowed = true;
        }


        private void btnSqrtandOverX_Click(object sender, EventArgs e)
        {
            string[] parts = lblDisplay.Text.Split(' ');
            string result;
            result = myEngine.Process_Sqrt_OverX(parts[parts.Length - 1], ((Button)sender).Text);
            string current = lblDisplay.Text;
            if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
            {
                lblDisplay.Text = current.Substring(0, current.Length - 3);
            }
            else
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
            }
            if (lblDisplay.Text is "")
            {
                lblDisplay.Text = "0";
            }
            //current = lblDisplay.Text;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = result;
            }
            else
            {
                lblDisplay.Text += result;
            }

        }


        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            string current = lblDisplay.Text;
            if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2]))
            {
                lblDisplay.Text += " " + ((Button)sender).Text + " ";
                isSpaceAllowed = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            // check if the last one is operator
            string current = lblDisplay.Text;
            if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
            {
                lblDisplay.Text = current.Substring(0, current.Length - 3);
            }
            else
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
            }
            if (lblDisplay.Text is "")
            {
                lblDisplay.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result = myEngine.Process(lblDisplay.Text);
            if (result is "E")
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isNumberPart)
            {
                return;
            }
            string current = lblDisplay.Text;
            if (current is "0")
            {
                lblDisplay.Text = "-";
            }
            else if (current[current.Length - 1] is '-')
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "")
                {
                    lblDisplay.Text = "0";
                }
            }
            else
            {
                lblDisplay.Text = current + "-";
            }
            isSpaceAllowed = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (!isContainDot)
            {
                isContainDot = true;
                lblDisplay.Text += ".";
                isSpaceAllowed = false;
            }
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isSpaceAllowed)
            {
                lblDisplay.Text += " ";
                isSpaceAllowed = false;
            }
        }

        private void ExtendForm_Load(object sender, EventArgs e)
        {

        }
    }
}