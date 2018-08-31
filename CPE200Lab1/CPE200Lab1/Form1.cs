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
        private bool plussign = false;
        private bool minussign = false;
        private bool timesign = false;
        private bool dividesign = false;
        private bool dotsign = true;
        private float num1=0,result=0;
        
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" && lblDisplay.Text != null)
                {
                    lblDisplay.Text = "0";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + "0";
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8){
                if (lblDisplay.Text == "0" && lblDisplay.Text != null)
                {
                    lblDisplay.Text = "1";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + "1";
                }
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" && lblDisplay.Text != null)
                {
                    lblDisplay.Text = "2";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + "2";
                }
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
           if (lblDisplay.Text.Length < 8){
                if (lblDisplay.Text == "0" && lblDisplay.Text != null)
                {
                    lblDisplay.Text = "3";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + "3";
                }
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" && lblDisplay.Text != null)
                {
                    lblDisplay.Text = "4";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + "4";
                }
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" && lblDisplay.Text != null)
                {
                    lblDisplay.Text = "5";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + "5";
                }
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" && lblDisplay.Text != null)
                {
                    lblDisplay.Text = "6";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + "6";
                }
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" && lblDisplay.Text != null)
                {
                    lblDisplay.Text = "7";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + "7";
                }
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" && lblDisplay.Text != null)
                {
                    lblDisplay.Text = "8";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + "8";
                }
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" && lblDisplay.Text != null)
                {
                    lblDisplay.Text = "9";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + "9";
                }
            }
        }

        private void btnPlus_Click(object sender, EventArgs e) //OK
        {
            {       
                num1 = float.Parse(lblDisplay.Text);
                lblDisplay.Text = "0";
                plussign = true;
               
            }                   
        }

        private void btnMinus_Click(object sender, EventArgs e) //OK
        {
            num1 = float.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            minussign = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e) //OK
        {
            num1 = float.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            timesign = true;
        }

        private void btnDivide_Click(object sender, EventArgs e) //OK
        {
            num1 = float.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";
            dividesign = true;
        }

        private void lblDisplay_Click(object sender, EventArgs e) //NOPE
        {

        }

         private void btnEqual_Click(object sender, EventArgs e)  //DOING
        {
            if (plussign == true)
             {
                result = num1+float.Parse(lblDisplay.Text);
                string temp = Convert.ToString(result);
                lblDisplay.Text = temp;
                plussign = false;
            }

            if (minussign == true)
            {
                result = num1 - float.Parse(lblDisplay.Text);
                string temp = Convert.ToString(result);
                lblDisplay.Text = temp;
                minussign = false;
            }

            if (timesign == true)
            {
                result = num1 * float.Parse(lblDisplay.Text);
                string temp = Convert.ToString(result);
                lblDisplay.Text = temp;
                timesign = false;
            }


            if (dividesign == true)
            {
                result = num1 / float.Parse(lblDisplay.Text);
                string temp = Convert.ToString(result);
                lblDisplay.Text = temp;
                dividesign = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length!=1) {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);

            }else
                lblDisplay.Text = "0";
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            float temp2 = float.Parse(lblDisplay.Text) * -1;
            lblDisplay.Text = temp2.ToString();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            int len = lblDisplay.Text.Length;
           
                if (lblDisplay.Text[len-1] == '.')
                {
                    dotsign = false;               
                }
            else { 
                    dotsign = true;
            }

            if (dotsign = true)
            {
                lblDisplay.Text += '.';
                dotsign = false;
            } 
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            result = 0;
            plussign = false;
            minussign = false;
            timesign = false;
            dividesign = false;
            dotsign = true;
            }
        }
    }

