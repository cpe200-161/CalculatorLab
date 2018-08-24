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
        float x;
        float y;
        int method;
        float sum;
        float per;
        public Form1()
        {
            InitializeComponent();
        }

        public void cal()
        {
            if(method == 1)
            {
                sum = x + y;
            }
            if(method == 2)
            {
                sum = x - y;
            }
            if(method == 3)
            {
                sum = x * y;
            }
            if(method == 4)
            {
                sum = x / y;
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if(lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            lblDisplay.Text = "0";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            method = 1;
            x = float.Parse(lblDisplay.Text);
            if(x > 0)
            {
                lblDisplay.Text = "";
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            method = 2;
            x = float.Parse(lblDisplay.Text);
            if (x > 0)
            {
                lblDisplay.Text = "";
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            method = 3;
            x = float.Parse(lblDisplay.Text);
            if (x > 0)
            {
                lblDisplay.Text = "";
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            method = 4;
            x = float.Parse(lblDisplay.Text);
            if (x > 0)
            {
                lblDisplay.Text = "";
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text + ".";
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            y = float.Parse(lblDisplay.Text);
            switch(method)
            {
                case 1 : per = x + (x * y / 100); break;
                case 2 : per = x - (x * y / 100); break;
                case 3 : per = x * (x * y / 100); break;
                case 4 : per = x / (x * y / 100); break;
                default: per = y / 100; break;
            }
            lblDisplay.Text = Convert.ToString(per);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            y = float.Parse(lblDisplay.Text);
            cal();
            lblDisplay.Text = Convert.ToString(sum);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
        }
    }
}
