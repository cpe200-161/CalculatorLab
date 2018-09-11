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
        private bool isAfterEqual = false;
        private RPNCalculatorEngine engine;
        private double memory=0;

        public ExtendForm()
        {
            InitializeComponent();
            engine = new RPNCalculatorEngine();
        }

        private bool isOperator(char ch)
        {
            switch(ch) {
                case '+':
                case '-':
                case 'X':
                case '÷':
                    return true;
            }
            return false;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (lblDisplay.Text is "0"||isAfterEqual)
            {
                lblDisplay.Text = "";
                isAfterEqual = false;
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            lblDisplay.Text += ((Button)sender).Text;
            isSpaceAllowed = true;
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
            } else
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
            string result = engine.Process(lblDisplay.Text);
            if (result is "E")
            {
                lblDisplay.Text = "Error";
            } else
            {
                lblDisplay.Text = result;
            }
            isSpaceAllowed = true;
            isAfterEqual=true;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            /*if (isNumberPart)
            {
                return;
            }*/
            string[] parts = lblDisplay.Text.Split(' ');
            string result = engine.calculate("X", parts[parts.Length - 1],"-1");
            lblDisplay.Text = "";
            for (int i = 0; i < parts.Length - 1; i++)
            {
                lblDisplay.Text += parts[i] + " ";
            }
            lblDisplay.Text += result;
            isSpaceAllowed = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if(!isContainDot)
            {
                isContainDot = true;
                lblDisplay.Text += ".";
                isSpaceAllowed = false;
            }
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            if(isSpaceAllowed)
            {
                lblDisplay.Text += " ";
                isSpaceAllowed = false;
                isContainDot = false;
                if(isAfterEqual)
                {
                    isAfterEqual = false;
                }
            }
        }

        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string operate = ((Button)sender).Text;
            string[] parts;
            //if (lblDisplay.Text[lblDisplay.Text.Length - 1] == ' ') lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
            parts = lblDisplay.Text.Split(' ');
            if(!engine.isNumber(parts[parts.Length - 1]))
            {
                return;
            }
            string result = engine.unaryCalculate(operate, parts[parts.Length-1]);
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = "";
                for(int i=0;i<parts.Length-1;i++)
                {
                    lblDisplay.Text += parts[i] + " ";
                }
                lblDisplay.Text +=result;
            }

        }

        private void btnMemory_Click(object sender, EventArgs e)
        {
            string[] parts;
            parts = lblDisplay.Text.Split(' ');
            if (!engine.isNumber(parts[parts.Length - 1]))
            {
                return;
            }
            switch (((Button)sender).Text)
            {
                case "MC":
                    memory = 0;
                    break;
                case "MR":
                    if (lblDisplay.Text == "0") lblDisplay.Text = "";
                    lblDisplay.Text += memory.ToString();
                    break;
                case "M+":
                    memory = Convert.ToDouble(engine.calculate("+",memory.ToString(), parts[parts.Length - 1]));
                    break;
                case "M-":
                    memory = Convert.ToDouble(engine.calculate("-", memory.ToString(), parts[parts.Length - 1]));
                    break;
                case "MS":
                    memory = Convert.ToDouble(parts[parts.Length - 1]);
                    break;

            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string operate = ((Button)sender).Text;
            string[] parts;
            //if (lblDisplay.Text[lblDisplay.Text.Length - 1] == ' ') lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
            parts = lblDisplay.Text.Split(' ');
            if (parts.Length is 1) return;
            if(!engine.isNumber(parts[parts.Length - 2])||!engine.isNumber(parts[parts.Length - 1]))
            {
                return;
            }
            string result = engine.calculate(operate, parts[parts.Length - 2],parts[parts.Length-1]);
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = "";
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    lblDisplay.Text += parts[i] + " ";
                }
                lblDisplay.Text += result;
            }
        }
    }
}
