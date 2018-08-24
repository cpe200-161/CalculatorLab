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
        int count = 0,change = 0;
        float first = 0, second = 0, sum = 0 , keepsum = 0,equal = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (change == 1)
            {
                lblDisplay.Text = "";
                change = 0;
                if (count == 2)
                {
                    count = 1;
                }
            }
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (btn.Text == ".")
            {
                if (!lblDisplay.Text.Contains(".")) lblDisplay.Text = lblDisplay.Text + ".";
            }
            else if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {           
            lblDisplay.Text = "";
            first = 0;
            keepsum = 0;
            count = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 0)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);            
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
                string secondtext = lblDisplay.Text;
                second = float.Parse(secondtext);
                if (count == 0) sum = second / 100;
                else sum = first + (first * second) / 100;
                lblDisplay.Text = sum.ToString();                      
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                string firsttext = lblDisplay.Text;
                first = float.Parse(firsttext);
                first *= -1;
                lblDisplay.Text = first.ToString();
                
            }
            if (count == 1)
            {
                string secondtext = lblDisplay.Text;
                second = float.Parse(secondtext);
                second *= -1;
                lblDisplay.Text = second.ToString();

            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if(count == 1)
            {
                if (equal == 1)
                {   
                    string secondtext = lblDisplay.Text;
                    second = float.Parse(secondtext);
                    if (keepsum != 0)
                    {
                        sum = keepsum + second;
                        keepsum = sum;
                        lblDisplay.Text = sum.ToString();
                    }
                    else
                    {
                        sum = first + second;
                        keepsum = sum;
                        lblDisplay.Text = sum.ToString();
                    }
                    count = 2;
                }
                if (equal == 2)
                {
                    string secondtext = lblDisplay.Text;
                    second = float.Parse(secondtext);
                    if (keepsum != 0)
                    {
                        sum = keepsum - second;
                        keepsum = sum;
                        lblDisplay.Text = sum.ToString();
                    }
                    else
                    {
                        sum = first - second;
                        keepsum = sum;
                        lblDisplay.Text = sum.ToString();
                    }
                    count = 2;
                }
                if (equal == 3)
                {
                    string secondtext = lblDisplay.Text;
                    second = float.Parse(secondtext);
                    if (keepsum != 0)
                    {
                        sum = keepsum * second;
                        keepsum = sum;
                        lblDisplay.Text = sum.ToString();
                    }
                    else
                    {
                        sum = first * second;
                        keepsum = sum;
                        lblDisplay.Text = sum.ToString();
                    }
                    count = 2;
                }
                if (equal == 4)
                {
                    string secondtext = lblDisplay.Text;
                    second = float.Parse(secondtext);
                    if (keepsum != 0)
                    {
                        sum = keepsum / second;
                        keepsum = sum;
                        lblDisplay.Text = sum.ToString();
                    }
                    else
                    {
                        sum = first / second;
                        keepsum = sum;
                        lblDisplay.Text = sum.ToString();
                    }
                    count = 2;
                }
            }
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {                  
            if (count == 1)
            {
                string secondtext = lblDisplay.Text;
                second = float.Parse(secondtext);
                if (keepsum != 0)
                {
                    sum = keepsum + second;
                    keepsum = sum;
                    lblDisplay.Text = sum.ToString();
                }
                else
                {
                    sum = first + second;
                    keepsum = sum;
                    lblDisplay.Text = sum.ToString();
                }                             
                count = 2;
            }

            if (count == 0)
            {
                string firsttext = lblDisplay.Text;
                first = float.Parse(firsttext);               
                count = 1;
            }
            change = 1;
            equal = 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (count == 1)
            {
                string secondtext = lblDisplay.Text;
                second = float.Parse(secondtext);
                if (keepsum != 0)
                {
                    sum = keepsum - second;
                    keepsum = sum;
                    lblDisplay.Text = sum.ToString();
                }
                else
                {
                    sum = first - second;
                    keepsum = sum;
                    lblDisplay.Text = sum.ToString();
                }
                count = 2;               
            }

            if (count == 0)
            {
                string firsttext = lblDisplay.Text;
                first = float.Parse(firsttext);
                count = 1;
            }
            change = 1;
            equal = 2;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (count == 1)
            {
                string secondtext = lblDisplay.Text;
                second = float.Parse(secondtext);
                if (keepsum != 0)
                {
                    sum = keepsum * second;
                    keepsum = sum;
                    lblDisplay.Text = sum.ToString();
                }
                else
                {
                    sum = first * second;
                    keepsum = sum;
                    lblDisplay.Text = sum.ToString();
                }
                count = 2;
            }

            if (count == 0)
            {
                string firsttext = lblDisplay.Text;
                first = float.Parse(firsttext);
                count = 1;
            }
            change = 1;
            equal = 3;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (count == 1)
            {
                string secondtext = lblDisplay.Text;
                second = float.Parse(secondtext);
                if (keepsum != 0)
                {
                    sum = keepsum / second;
                    keepsum = sum;
                    lblDisplay.Text = sum.ToString();
                }
                else
                {
                    sum = first / second;
                    keepsum = sum;
                    lblDisplay.Text = sum.ToString();
                }
                count = 2;
            }

            if (count == 0)
            {   
                string firsttext = lblDisplay.Text;
                first = float.Parse(firsttext);
                count = 1;
            }
            change = 1;
            equal = 4;
        }
    }
}
