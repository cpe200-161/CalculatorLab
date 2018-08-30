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
        private float val = 0;
        

        public void  Number(int n)
        {
            val = val * 10 + n;
            lblDisplay.Text = val.ToString();
        }
    
        private void btn1_Click(object sender, EventArgs e)
        {
           Number(1);
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Number(2);
            
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Number(3);
            
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Number(4);
            
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Number(5);
            
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Number(6);
            
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Number(7);
            
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Number(8);
            
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Number(9);
            
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Number(0);
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            val = val * 0;
            lblDisplay.Text = val.ToString();
        }

        float x;
        int num = 0;
        
        private void btnPlus_Click(object sender, EventArgs e)
        {
            x = val;
            val = 0;
            num = 1;
            
            lblDisplay.Text = val.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            x = val;
            val = 0;
            num = 2;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            x = val;
            val = 0;
            num = 3;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            x = val;
            val = 0;
           
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            x = val;
            val = 0;
            num = 4;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (num == 0) val = x / val;
            else if (num == 1) val = x + val;
            else if (num == 2) val = x - val;
            else if (num == 3) val = x * val;
            else if (num == 4) val = x / 100;
            lblDisplay.Text = val.ToString();
        }

        
        private void btnDot_Click(object sender, EventArgs e)
        {


            lblDisplay.Text = lblDisplay.Text + "." ;
            lblDisplay.Text = val.ToString();

            

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "+")
                lblDisplay.Text = val.ToString();
            else
                lblDisplay.Text =  "-" + lblDisplay.Text ;
        }

       
    }
}
