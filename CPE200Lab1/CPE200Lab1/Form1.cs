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
        string firstOperand;
        string secondOperand;
        bool setFirstOperand = false;
        bool isStartSecondOperand = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result;
            secondOperand = lblDisplay.Text;
            result = (float.Parse(firstOperand) + float.Parse(secondOperand)).ToString();
            lblDisplay.Text = result;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" )
            {
                lblDisplay.Text = "";
            }
            if(setFirstOperand == true && isStartSecondOperand == false)
            {
                lblDisplay.Text = null;
                isStartSecondOperand = true;
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }    
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
           
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            setFirstOperand = true;
        }
    }
}
