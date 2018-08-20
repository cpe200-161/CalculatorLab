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
        private string number1 = null ;
        private string number2 = null ;
        string result = null ;
        bool check = false;
        int x = 0; //check +-*/
        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (check)
            {
                lblDisplay.Text = "";
                check = false;
            }
            if(lblDisplay.Text == "0")
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
            number1 = lblDisplay.Text;
            check = true;
            x = 1;
        }
        
        private void btnMinus_Click(object sender, EventArgs e)
        {
            number1 = lblDisplay.Text;
            check = true;
            x = 2;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            number1 = lblDisplay.Text;
            check = true;
            x = 3;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            number1 = lblDisplay.Text;
            check = true;
            x = 4;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            number1 = null;
            number2 = null;
            lblDisplay.Text = "0";
            x = 0;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            number2 = lblDisplay.Text;
            if (x == 1)
            {
                result = (float.Parse(number1) + float.Parse(number2)).ToString();
            }
            if (x == 2)
            {
                result = (float.Parse(number1) - float.Parse(number2)).ToString();
            }
            if (x == 3)
            {
                result = (float.Parse(number1) * float.Parse(number2)).ToString();
            }
            if (x == 4)
            {
                result = (float.Parse(number1) / float.Parse(number2)).ToString();
            }
            lblDisplay.Text = result;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text + ".";
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if(x == 0 || x == 3 || x == 4)
            {
                lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100).ToString();
            }
            else
            {
                lblDisplay.Text = ((float.Parse(number1) * float.Parse(lblDisplay.Text)) / 100).ToString();
            }
        }
    }
}
