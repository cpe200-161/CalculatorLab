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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

          
        private void btn0_Click(object sender, EventArgs e)
        {
           
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

        private void btnPlus_Click(object sender, EventArgs e)
        {         

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
             
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            }
        }
    }
}
