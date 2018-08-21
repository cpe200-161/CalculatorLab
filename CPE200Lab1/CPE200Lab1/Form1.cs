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
        string firstoperand = null;
        string secondoperand = null;
        float result;
        bool plus = false, minus = false, multiple = false, divide = false,pressed=false;
        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
           
        }


        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
         
           if (lblDisplay.Text == "0")
           {
               lblDisplay.Text = "";
           }             
          
          
                    lblDisplay.Text += btn.Text;

           
            
       
           
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
                plus = false; minus = false; multiple = true; divide = false;pressed = true;
                firstoperand = lblDisplay.Text;
                lblDisplay.Text = "";
                
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            plus = false; minus = false; multiple = false; divide = true; pressed = true;
            firstoperand = lblDisplay.Text;
            lblDisplay.Text = "";
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear(); 
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            float tmp = 0;
            tmp = float.Parse(lblDisplay.Text)*(-1);
            lblDisplay.Text = tmp.ToString();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            secondoperand = lblDisplay.Text;
            if (plus) result = float.Parse(firstoperand) + (float.Parse(firstoperand)*(float.Parse(secondoperand)/100));
            else if (minus) result = float.Parse(firstoperand) - (float.Parse(firstoperand) * (float.Parse(secondoperand) / 100));
            else if (multiple) result = float.Parse(firstoperand) * (float.Parse(firstoperand) * (float.Parse(secondoperand) / 100));
            else if (divide) result = float.Parse(firstoperand) / (float.Parse(firstoperand) * (float.Parse(secondoperand) / 100));
            lblDisplay.Text = result.ToString();
            firstoperand = lblDisplay.Text;
            plus = false; minus = false; multiple = false; divide = false; pressed = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            plus = true; minus = false; multiple = false; divide = false; pressed = true;
            firstoperand = lblDisplay.Text;
            lblDisplay.Text = "";
            
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            plus = false; minus = true; multiple = false; divide = false; pressed = true;
            firstoperand = lblDisplay.Text;
            lblDisplay.Text = "";
            
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            secondoperand = lblDisplay.Text;
            if (plus) result = float.Parse(firstoperand) + float.Parse(secondoperand);
            else if (minus) result = float.Parse(firstoperand) - float.Parse(secondoperand);
            else if (multiple) result = float.Parse(firstoperand) * float.Parse(secondoperand);
            else if (divide) result = float.Parse(firstoperand) / float.Parse(secondoperand);
            lblDisplay.Text = result.ToString();
            firstoperand = lblDisplay.Text;
            plus = false; minus = false; multiple = false; divide = false; pressed = false;

        }
        public void clear()
        {
            firstoperand = "";
            secondoperand = "";
            lblDisplay.Text = "";
            plus = false; minus = false; multiple = false; divide = false;
        }
    }
}
