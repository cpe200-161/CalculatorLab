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
        private double val = 0, valbefore = 0, sum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void display(double valText)
        {
            lblDisplay.Text = valText.ToString();
        }

        private void numClik(int n, double m = 10)
        {
            val = val * m + n;
            display(val);
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
            numClik(0,-1);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            valbefore = val;
            val = 0;
            sum = 1;
            sum *= valbefore;
            display(sum);
        }
        
        private void btnPlus_Click(object sender, EventArgs e)
        {
            valbefore = val;
            val = 0;
            sum += valbefore;
            display(sum);
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
            valbefore = 0;
            sum = 0;
            display(val);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
         
        }
    }
}