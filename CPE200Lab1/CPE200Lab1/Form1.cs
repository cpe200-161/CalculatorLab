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
        string firstoperand="0";
        string secondoperand;
        bool setfirstop = false;
        bool plus;
        bool minus;
        bool multi;
        bool divide;
        bool per;
        string sum;
        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstoperand = lblDisplay.Text;
            setfirstop = true;
            plus = true;
            
            
            



        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            firstoperand = lblDisplay.Text;
            setfirstop = true;
            minus = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            firstoperand = lblDisplay.Text;
            
            setfirstop = true;
            multi = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            firstoperand = lblDisplay.Text;
            setfirstop = true;
            divide = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (firstoperand == "0") lblDisplay.Text = "0";
            else
            {
                per = true;
            }

          
      
            
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            secondoperand = lblDisplay.Text;
            if (per == true)
            {
                secondoperand = ((float.Parse(secondoperand) / 100) * (float.Parse(firstoperand))).ToString();
                per = false;
            }
            if (plus == true)
            {

                sum = (float.Parse(firstoperand) + float.Parse(secondoperand)).ToString();
                plus = false;
            }else if(minus == true)
            {
                sum = (float.Parse(firstoperand) - float.Parse(secondoperand)).ToString();
                minus = false;
            }else if(multi == true)
            {
                sum = (float.Parse(firstoperand) * float.Parse(secondoperand)).ToString();
                multi = false;
            }else if(divide == true)
            {
                sum = (float.Parse(firstoperand) / float.Parse(secondoperand)).ToString();
                divide = false;
            }



            
            lblDisplay.Text = sum;
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

       
        private void bthX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (setfirstop == true)
            {
                lblDisplay.Text = "";
                setfirstop = false;
            }

            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0")
                {
                    lblDisplay.Text = "";
                }
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        
    }
}
