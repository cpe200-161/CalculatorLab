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
        bool setFirstOperand;

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
            if (lblDisplay.Text == "0" || (firstOperand != null && secondOperand != null)
            {
                lblDisplay.Text = "";
            }

            if(lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result;
            secondOperand = lblDisplay.Text;
            result = (float.Parse(firstOperand) + float.Parse(secondOperand)).ToString;
            lblDisplay.Text = result;
        }
    }
}
