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
        string answer, s;
        int n1, n2, order;

        public Form1()
        {
            InitializeComponent();

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            s = s + "1";
            lblDisplay.Text = s;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            s = s + "2";
            lblDisplay.Text = s;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            s = s + "3";
            lblDisplay.Text = s;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            s = s + "4";
            lblDisplay.Text = s;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            s = s + "5";
            lblDisplay.Text = s;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            s = s + "6";
            lblDisplay.Text = s;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            s = s + "7";
            lblDisplay.Text = s;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            s = s + "8";
            lblDisplay.Text = s;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            s = s + "9";
            lblDisplay.Text = s;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            s = s + "0";
            lblDisplay.Text = s;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {

        }

        private void btnDot_Click(object sender, EventArgs e)
        {

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if(order == 1)
            {
                answer = (n1 + n2).ToString();
                lblDisplay.Text = answer.ToString();
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (n1 != 0)
            {
                n1 += int.Parse(s);
                s = "";
                order = 1;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {

        }

        

        private void btnX_click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8)
            {
                s = s +  ;
                lblDisplay.Text = s;
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}
