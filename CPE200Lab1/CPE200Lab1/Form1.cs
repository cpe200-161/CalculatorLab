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
        double FirstNumber = 0;
       
        string symbol;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            double SecondNumber = Convert.ToDouble(lblDisplay.Text);
            double result;
            if (symbol == "+")
            {
                result = (FirstNumber + SecondNumber);
                lblDisplay.Text = Convert.ToString(result);
                Console.WriteLine(result);
            }
            if (symbol == "-")
            {
                result = (FirstNumber - SecondNumber);
                lblDisplay.Text = Convert.ToString(result);
                Console.WriteLine(result);
            }
            if (symbol == "X")
            {
                result = (FirstNumber * SecondNumber);
                lblDisplay.Text = Convert.ToString(result);
                Console.WriteLine(result);
            }
            if (symbol == "/")
            {
                if (SecondNumber == 0)
                {
                    lblDisplay.Text = "Can't do";
                }
                else
                {
                    result = (FirstNumber / SecondNumber);
                    lblDisplay.Text = Convert.ToString(result);
                    Console.WriteLine(result);
                }
            }

           

        }
         private void btnNumber(object sender, EventArgs e)
        {
            if((lblDisplay.Text.Length)<8)
            { 
                    if (lblDisplay.Text == "0" && lblDisplay != null)
                     {
                           lblDisplay.Text = ((Button)sender).Text;
                     }

                    else
                    {
                          lblDisplay.Text = lblDisplay.Text + ((Button)sender).Text;
                    }
            }
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
       
                symbol = ((Button)sender).Text;
                FirstNumber = Convert.ToDouble(lblDisplay.Text);
                lblDisplay.Text = "0";
            
        }

        private void btnPercent_click(object sender, EventArgs e)
        {
       
            if(lblDisplay.Text=="0")
            {
                lblDisplay.Text = Convert.ToString(FirstNumber * FirstNumber / 100);
            }
            else
            {
                double hold = Convert.ToDouble(lblDisplay.Text);
                lblDisplay.Text = Convert.ToString(FirstNumber * hold / 100);
            }
            
            
        }

    }
}
