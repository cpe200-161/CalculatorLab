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
        string input;
        float num1;
        float num2;
        string operation = null;
        float sum = 0;
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
              if (lblDisplay.Text.Length < 8 )
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void cal()
        {
            if (operation == "+")
            {
                sum = num1 + num2;
            }
            if (operation == "-")
            {
                sum = num1 - num2;
            }
            if (operation == "X")
            {
                sum = num1 * num2;
            }
            if (operation == "÷")
            {
                sum = num1 / num2;
            }
        }
        private void btnOpe_Click(object sender, EventArgs e)
        {
            Button ope = (Button)sender;
            operation = ope.Text;
            num1 = float.Parse(lblDisplay.Text);
            if (num1 > 0) lblDisplay.Text = "";
            cal();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            sum = 0;
            lblDisplay.Text = "";
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text.IndexOf(".") == -1)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }
            
        }
        
        private void btnEqual_Click(object sender, EventArgs e)
        {
            num2 = float.Parse(lblDisplay.Text);
            cal();
            lblDisplay.Text = sum.ToString();
            }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            num2 = float.Parse(lblDisplay.Text);
            if(operation == "+")
            {
                sum = num1 + (num1 * (num2 / 100));
            }
            if(operation == "-")
            {
                sum = num1 - (num1 * (num2 / 100));
            }
            if(operation == "*")
            {
                sum = num1 * (num2 / 100);
            }
            if(operation == "/")
            {
                sum = num1 / (num2 / 100);
            }
            lblDisplay.Text = Convert.ToString(sum);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
        }
    }
}
