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
        float  num1 = 0, num2=0;
        string signcal = "+";
        bool check = false;
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text != "")
            lblDisplay.Text = lblDisplay.Text.Substring(0,lblDisplay.Text.Length - 1);
            if (lblDisplay.Text == "")
                lblDisplay.Text = "0";

        }   

        private void btnConver_Click(object sender, EventArgs e)
        {
             num1 = float.Parse(lblDisplay.Text);
            num1 *= -1;
            lblDisplay.Text = num1.ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            signcal = "+";
            num1 = 0;
            num2 = 0;
            check = false;
        }

        void number(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if ((lblDisplay.Text == "0" || check)&& btn.Text != ".")
            {
                lblDisplay.Text = "";
            }
                if (lblDisplay.Text.Length <9)
            {
                lblDisplay.Text += btn.Text;
            }
            check = false;
        }
        void calcal(object sender, EventArgs e)
        {
               Button btn = (Button)sender;
            if(!check)
            {
                num2 = float.Parse(lblDisplay.Text);

                switch (signcal)
                {
                    case "+":
                        num1 += num2;
                        break;
                    case "-":
                        num1 -= num2;
                        break;
                    case "X":
                        num1 *= num2;
                        break;
                    case "÷":
                        num1 /= num2;
                        break;
                    case "%":
                        num1 = (num1 / 100) * num2;
                        break;
                }
                
            }
            
            if (btn.Text == "=")
            {
                if(!check)
                {
                    lblDisplay.Text = num1.ToString();
                    if(lblDisplay.Text.Length > 9)
                    {
                        lblDisplay.Text = "Error";
                    }
                }
                
            }
            else
            {
                lblDisplay.Text = num1.ToString();
                signcal = btn.Text;
            }
            check = true;

        }
    }
}
