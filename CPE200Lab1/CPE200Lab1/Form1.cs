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
        public string number1="0";
        public string number2="0";
        public bool Plus, Minus, Multi, Div;
        
        
        

        private void btnX_Click(object sender, EventArgs e)
        {
            


                Button btn = (Button)sender;
                if (lblDisplay.Text == "0" ) { lblDisplay.Text = ""; }
                if (lblDisplay.Text.Length < 8)
                {
                    lblDisplay.Text += btn.Text;
                }
            
            

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            
            
            
            
            
            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
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

        private void btnPercent_Click(object sender, EventArgs e)
        {
            
                lblDisplay.Text = "555";

            
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {

            if (lblDisplay.Text != "" && Plus == true)
            {
                {
                    number2 = lblDisplay.Text;
                }

                lblDisplay.Text = (float.Parse(number1) + float.Parse(number2)).ToString();
                

            }
            if (lblDisplay.Text != "" && Minus == true)
            {
                {
                    number2 = lblDisplay.Text;
                }

                lblDisplay.Text = (float.Parse(number1) - float.Parse(number2)).ToString();
                
            }
            if (lblDisplay.Text != "" && Multi == true)
            {
                {
                    number2 = lblDisplay.Text;
                }

                lblDisplay.Text = (float.Parse(number1) * float.Parse(number2)).ToString();
                
            }
            if (lblDisplay.Text != "" && Div == true)
            {
                {
                    number2 = lblDisplay.Text;
                }

                lblDisplay.Text = (float.Parse(number1)/(float.Parse(number2))).ToString();
                
            }





        }

        private void btnOperator_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (btn.Text == "+")
            {
                if (lblDisplay.Text != "")
                {

                    number1 = lblDisplay.Text;
                    lblDisplay.Text = "";

                }
                Plus = true;
            }
            else
            {
                Plus = false;
            }
            if (btn.Text == "-")
            {
                if (lblDisplay.Text != "")
                {

                    number1 = lblDisplay.Text;
                    lblDisplay.Text = "";

                }
                Minus = true;
            }
            else
            {
                Minus = false;
            }
            if (btn.Text == "X")
            {
                if (lblDisplay.Text != "")
                {

                    number1 = lblDisplay.Text;
                    lblDisplay.Text = "";

                }
                Multi = true;
            }
            else
            {
                Multi = false;
            }
            if (btn.Text == "÷")
            {
                if (lblDisplay.Text != "")
                {

                    number1 = lblDisplay.Text;
                    lblDisplay.Text = "";

                }
                Div = true;
            }
            else
            {
                Div = false;
            }






        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            number1 = "0";
            number2 = "0";
        }
    }
}
