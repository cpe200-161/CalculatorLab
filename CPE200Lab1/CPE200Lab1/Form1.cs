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
        private double val = 0, val1 = 0, val2 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void display()
        {
            lblDisplay.Text = val.ToString();
        }

        private void numClik(int n)
        {
            val = val * 10 + n;
            display();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            numClik(0);      
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            numClik(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            numClik(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            numClik(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            numClik(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            numClik(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            numClik(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            numClik(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            numClik(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            numClik(9);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            val = val * (-1);
            display();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            
        }
        
        private void btnPlus_Click(object sender, EventArgs e)
        {
            val1 = val;
            val = val2;
            val2 += val1;
            lblDisplay.Text = val2.ToString();
            val = 0;

            /*val1 = val;
            val = 0;
            val = val2;
            val2 += val1;
            lblDisplay.Text = val2.ToString();*/

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
          
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {

        }

        private void btnPercent_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            val = 0;
            display();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            display();
        }
    }
}