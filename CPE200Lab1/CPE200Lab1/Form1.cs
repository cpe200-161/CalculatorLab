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
    public partial class Form1 : Form
    {
        double firstNum,secondNum,result,percentValue;
        bool percentPressed=false;
        string operation;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
            lblDisplay.Text = "0";
            percentPressed = false;
        }
        private void btnX_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }
        private void btnDot_Click(object sender,EventArgs e)
        {
            if (!(lblDisplay.Text.Contains(".")))
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(lblDisplay.Text);
            lblDisplay.Text = "0";
            operation = "+";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(lblDisplay.Text);
            lblDisplay.Text = "0";
            operation = "-";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(lblDisplay.Text);
            lblDisplay.Text = "0";
            operation = "*";
        }

       

        private void btnPercent_Click(object sender, EventArgs e)
        {
            percentPressed = true;
            percentValue = (Convert.ToDouble(lblDisplay.Text) * firstNum) / 100;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(lblDisplay.Text);
            lblDisplay.Text = "0";
            operation = "/";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            secondNum = Convert.ToDouble(lblDisplay.Text);
            if (operation == "+")
            {
                if (percentPressed == false)
                {
                    result = firstNum + secondNum;
                }
                else
                {
                    result = firstNum + percentValue;
                    percentPressed = false;
                }  
            }
            else if(operation == "-")
            {
                if (percentPressed == false)
                {
                    result = firstNum - secondNum;
                }
                else
                {
                    result = firstNum - percentValue;
                    percentPressed = false;
                }
            }
            else if (operation == "*")
            {
                if (percentPressed == false)
                {
                    result = firstNum * secondNum;
                }
                else
                {
                    result = firstNum * percentValue;
                    percentPressed = false;
                }
            }
            else
            {
                if (percentPressed == false)
                {
                    result = firstNum / secondNum;
                }
                else
                {
                    result = firstNum / percentValue;
                    percentPressed = false;
                }
            }
            lblDisplay.Text = Convert.ToString(result);
        }
    }
}
