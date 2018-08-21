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
        public Form1()
        {
            InitializeComponent();

        }
        private string first = "0",second,sum;
        private bool plus, minus, muli, divide, setfirstop,per;

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            first = lblDisplay.Text;
            if (first == "0")
            {
                lblDisplay.Text = "0";
            }
            else
            {
                first = (float.Parse(first) / 100).ToString();
            }
            lblDisplay.Text = first;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            first = lblDisplay.Text;
            setfirstop = true;
            divide = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            second = lblDisplay.Text;
            if(plus == true)
            {
                sum = (float.Parse(second)+float.Parse(first)).ToString();
                plus = false;
            }
            else if (minus == true)
            {
                sum = (float.Parse(first) - float.Parse(second)).ToString();
                minus = false;
            }
            else if (muli == true)
            {
                sum = (float.Parse(first) * float.Parse(second)).ToString();
                muli = false;
            }
            else if (divide == true)
            {
                sum = (float.Parse(first) / float.Parse(second)).ToString();
                divide = false;
            }
            else if (per == true)
            {
                second = ((float.Parse(second) / 100) * (float.Parse(first))).ToString();
                per = false;
            }
            lblDisplay.Text = sum;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            first = lblDisplay.Text;
            setfirstop = true;
            muli = true;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            first = lblDisplay.Text;
            setfirstop = true;
            minus = true;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            first = lblDisplay.Text;
            setfirstop = true;
            plus = true;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (setfirstop == true)
            {
                lblDisplay.Text = "";
                setfirstop = false;
            }
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = null;
            }
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
                
            }
        }

        
    }
}
