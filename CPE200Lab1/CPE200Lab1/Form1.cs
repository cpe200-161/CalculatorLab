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
        string firstOperand = null;
        string secondOperand = null;
        string extraOperand = null;
        bool reset = false;
        int operation;
        float percenNumber;
        string result1;
        string result2;
        string result3;
        string result4;
        bool isPercenThere;

        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }
        
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || (firstOperand != null && reset == true))
            {
                lblDisplay.Text = "";
            }

            reset = false;

            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            reset = true;
            operation = 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            reset = true;
            operation = 2;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            reset = true;
            operation = 3;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            reset = true;
            operation = 4;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            reset = false;
            if (isPercenThere == false)
            {
                secondOperand = lblDisplay.Text;
            }
            else
            {
                secondOperand = percenNumber.ToString();
            }

            if (operation == 1)
            {
                result1 = (float.Parse(firstOperand) + float.Parse(secondOperand)).ToString();
                lblDisplay.Text = result1;
            }
            else if (operation == 2)
            {
                result2 = (float.Parse(firstOperand) - float.Parse(secondOperand)).ToString();
                lblDisplay.Text = result2;
            }
            else if (operation == 3)
            {
                result3 = (float.Parse(firstOperand) * float.Parse(secondOperand)).ToString();
                lblDisplay.Text = result3;
            }
            else if (operation == 4)
            {
                result4 = (float.Parse(firstOperand) / float.Parse(secondOperand)).ToString();
                lblDisplay.Text = result4;
            }
 
            firstOperand = null;
            isPercenThere = false;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if(firstOperand != null)
            {
                secondOperand = lblDisplay.Text;
                percenNumber = (float.Parse(firstOperand) * float.Parse(secondOperand) / 100);
                isPercenThere = true;
            }
            reset = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            firstOperand = null;
            secondOperand = null;
            lblDisplay.Text = "0";
            reset = true;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            extraOperand = lblDisplay.Text;
            lblDisplay.Text = (float.Parse(extraOperand) * (-1)).ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            extraOperand = lblDisplay.Text;
            extraOperand = extraOperand.Remove(extraOperand.Length - 1, 1);
            lblDisplay.Text = extraOperand;
            if (lblDisplay.Text.Length == 0)
            {
                lblDisplay.Text = "0";
                reset = true;
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text + ".";
        }
    }
}
