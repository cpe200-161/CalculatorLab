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
        double num1 = 0, num2 = 0;
        string firstinput = null;
        string nextinput = null;
        int Operator = 0;
        int OpertorPressed = 0;
        int statnum = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void computing()
        {
            switch (Operator)
            {
                case 1:
                    nextinput = lblDisplay.Text;
                    num2 = num1 + double.Parse(lblDisplay.Text);
                    lblDisplay.Text = num2.ToString();
                    break;
                case 2:
                    nextinput = lblDisplay.Text;
                    num2 = num1 - double.Parse(lblDisplay.Text);
                    lblDisplay.Text = num2.ToString();
                    break;
                case 3:
                    nextinput = lblDisplay.Text;
                    num2 = num1 * double.Parse(lblDisplay.Text);
                    lblDisplay.Text = num2.ToString();
                    break;
                case 4:
                    nextinput = lblDisplay.Text;
                    num2 = num1 / double.Parse(lblDisplay.Text);
                    lblDisplay.Text = num2.ToString();
                    break;
                default:
                    break;
            }
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (statnum == 0)
            {
                firstinput = lblDisplay.Text;
                num1 = double.Parse(lblDisplay.Text);
                Operator = 1;
                
                OpertorPressed = 1;
                lblDisplay.Text = num1.ToString();
                statnum++;
            }
            else
            {
                num1 = num1 + double.Parse(lblDisplay.Text);
                Operator = 1;
                OpertorPressed = 1;
                lblDisplay.Text = lblDisplay.Text;
            }
            

            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            Operator = 0;
            statnum = 0;
            firstinput = null;
            nextinput = null;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            computing();

        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!(lblDisplay.Text.Contains(".")))
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text != "0")
            {
                int length = lblDisplay.Text.Length - 1;
                string text= lblDisplay.Text;
                lblDisplay.Text = "";
                for(int i =0;i<length;i++)
                {
                    lblDisplay.Text = lblDisplay.Text + text[i];
                }
                if (lblDisplay.Text == "") lblDisplay.Text = "0";
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                if (OpertorPressed == 0)
                {
                    lblDisplay.Text = lblDisplay.Text + btn.Text;

                }
                else if (OpertorPressed == 1)
                {
                    lblDisplay.Text = btn.Text;
                    OpertorPressed = 0;
                    
                }
            }

        }


    }
}
