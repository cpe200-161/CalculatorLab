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
        private string oneNumber = null;
        private string twoNumber = null;
        private string state = null;
        bool Check = false;
        int result = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (Check == true)
            {
                lblDisplay.Text = "";
                Check = false;
            }
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            oneNumber = lblDisplay.Text;
            Check = true;
            result = 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            oneNumber = lblDisplay.Text;
            Check = true;
            result = 2;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            oneNumber = lblDisplay.Text;
            Check = true;
            result = 3;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            oneNumber = lblDisplay.Text;
            Check = true;
            result = 4;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text + ".";
        }
    
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (result == 1 || result == 2)
            {
                lblDisplay.Text = ((float.Parse(oneNumber) * float.Parse(lblDisplay.Text)) / 100).ToString();
            }
            if (result == 3 || result == 4)
            {
                lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100).ToString();
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            twoNumber = lblDisplay.Text;
            if (result == 1)
            {
                state = (float.Parse(oneNumber) + float.Parse(twoNumber)).ToString();
            }
            if (result == 2)
            {
                state = (float.Parse(oneNumber) - float.Parse(twoNumber)).ToString();
            }
            if (result == 3)
            {
                state = (float.Parse(oneNumber) * float.Parse(twoNumber)).ToString();
            }
            if (result == 4)
            {
                state = (float.Parse(oneNumber) / float.Parse(twoNumber)).ToString();
            }

            lblDisplay.Text = state;
        }

    }
}
