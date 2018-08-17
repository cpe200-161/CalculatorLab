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

        public void conditionBtn(String num)
        {
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + num;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            conditionBtn("1");
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            conditionBtn("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            conditionBtn("3");

        }


        private void btn4_Click(object sender, EventArgs e)
        {
            conditionBtn("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            conditionBtn("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            conditionBtn("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            conditionBtn("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            conditionBtn("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            conditionBtn("9");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            conditionBtn("x");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            conditionBtn("0");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            conditionBtn("/");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            conditionBtn("+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            conditionBtn("-");
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            conditionBtn("=");
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            conditionBtn(".");
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            conditionBtn("+-");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            conditionBtn("c");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            conditionBtn("<");
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            conditionBtn("%");
        }
    }
}
