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
        private int val = 0, temp = 0, sum = 0, temp2 = 0;
        private bool plusval = false;
        private bool minusval = false;
        private bool multival = false;
        private bool divideval = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void shownum()
        {
            lblDisplay.Text = val.ToString();
        }

        private void btClick(int num)
        {
            val = val * 10 + num;
            shownum();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            btClick(0);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btClick(4);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            btClick(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            btClick(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            btClick(9);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            btClick(6);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btClick(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btClick(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btClick(3);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            btClick(5);
        }

      

        private void btnPlus_Click(object sender, EventArgs e)
        {
            temp = val;
            val = 0;
            plusval = true;

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if(plusval == true)
            {
                sum = temp2 + temp + val;
                temp2 = sum;
                val = 0;
                lblDisplay.Text = sum.ToString();
                
                plusval = false;
                 
            }
         
            //lblDisplay.Text = sum.ToString();
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            sum = 0;
            val = 0;
            temp = 0;
            temp2 = 0;
            shownum();
        }
    }
}
