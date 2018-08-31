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
        private double p;
        private double sum;
        private double i;
        private double h=0;

        
   
        public Form1()
        {
            InitializeComponent();
        }
     

        private void btnClear_Click(object sender, EventArgs e)
        {

            h = 0;
            lblDisplay.Text =  "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {

            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text = lblDisplay.Text + "1";

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {

            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text = lblDisplay.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {

            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text = lblDisplay.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {

            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text = lblDisplay.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {

            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text = lblDisplay.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {

            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text = lblDisplay.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {

            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text = lblDisplay.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {

            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text = lblDisplay.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text = lblDisplay.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text + "0";
        } 

        private void btnPlus_Click(object sender, EventArgs e)
        {
            
            sum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            i = 1;
            h = 0;
          
   

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            sum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            i = 2;
            h = 0;

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            sum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            i = 3;
            h = 0;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {

            sum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            i = 4;
            h = 0;

        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if(h==0)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
                h = 1;
            }


            
        }


       

        private void btnEqual_Click(object sender, EventArgs e)
        {
            p = Double.Parse(lblDisplay.Text);
            if (i == 1)
            {
                sum = sum + p;
               
                
            }
            if (i == 2)
            {
                sum = sum - p;
            }
            if (i == 3)
            {
                sum = sum * p;

            }
            if (i == 4)
            {
                sum = sum / p;
            }
        

            lblDisplay.Text = sum.ToString();




        }
        private double m;
        private void btnPercent_Click(object sender, EventArgs e)
        {
            m = Double.Parse(lblDisplay.Text);
            if(sum == 0)
            {
                m = m / 100;
            }
            else
            {
                m = (m / 100) * sum;
                
            }
            if (m % 1 == 0)
            {
                h = 0;

            }
            else h = 1;
            
            lblDisplay.Text = m.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int x = lblDisplay.Text.Length;
            if(lblDisplay.Text == "")
            {
                lblDisplay.Text = "";
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text.Remove(x - 1);
            }
        }
    }
}
