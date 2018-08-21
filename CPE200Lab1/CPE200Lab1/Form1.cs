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
        private string Operand = null;
        private string secondOperand = null;
        private int calculationState = 0;
        const int FIRST_OPERAND = 0;
        const int SECOND_OPERAND = 1;
        const int OPERATOR = 2;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (calculationState == OPERATOR)
            {
                calculationState = SECOND_OPERAND;
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (calculationState == FIRST_OPERAND)
            {
                Operand = lblDisplay.Text;
                calculationState = OPERATOR;
            }
            else if (calculationState == SECOND_OPERAND)
            {
                Calculator();
            }
        }

        private void Calculator()
        {
            secondOperand = lblDisplay.Text;
            string result = (float.Parse(Operand) + float.Parse(secondOperand)).ToString();
            lblDisplay.Text = result;
            calculationState = OPERATOR;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (calculationState == SECOND_OPERAND)
            {
                Calculator();
            }
        }
    }
}
