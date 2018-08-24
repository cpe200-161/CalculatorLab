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
        double num1 = 0;
        
        double ans;
        bool btnPlus_Parse = false;
        bool check = false;
        string operation = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if ((lblDisplay.Text == "0" )|| (btnPlus_Parse))
            {
                lblDisplay.Text = "";
                btnPlus_Parse = false;
            }
            if (lblDisplay.Text.Length < 8) 
            lblDisplay.Text = lblDisplay.Text + btn.Text;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            num1 = double.Parse(lblDisplay.Text);
            operation = btn.Text;
            btnPlus_Parse = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            
            switch (operation)
            {
                case "+":
                    {
                        ans = num1 + double.Parse(lblDisplay.Text);
                        lblDisplay.Text = ans.ToString();
                    break;
                    }
                case "-":
                    {
                        ans = num1 - double.Parse(lblDisplay.Text);
                        lblDisplay.Text = ans.ToString();
                        break;
                    }
                case "X":
                    {
                        
                        ans = num1 * double.Parse(lblDisplay.Text);
                        lblDisplay.Text = ans.ToString();
                        break;
                    }
                case "÷":
                    {
                        if (double.Parse(lblDisplay.Text) == 0)
                        {
                            lblDisplay.Text = "error";
                        }
                        else
                        {
                            ans = num1 / double.Parse(lblDisplay.Text);
                            lblDisplay.Text = ans.ToString();
                            
                        }
                        break;
                    }
                   
               
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            num1 = 0;
            ans = 0;
            lblDisplay.Text = "0";
            operation = "";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            num1 = double.Parse(lblDisplay.Text);
            operation = btn.Text;
            btnPlus_Parse = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            num1 = double.Parse(lblDisplay.Text);
            operation = btn.Text;
            btnPlus_Parse = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            num1 = double.Parse(lblDisplay.Text);
            operation = btn.Text;
            btnPlus_Parse = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if(operation == "" || operation == "X" || operation == "÷")
            {
                ans = double.Parse(lblDisplay.Text) / 100;
                lblDisplay.Text = ans.ToString();
            }else if( operation == "+" || operation == "-")
            {
                ans = (num1 * double.Parse(lblDisplay.Text)) / 100;
                lblDisplay.Text = ans.ToString();
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(!check)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
                check = true;
            }
            else if(lblDisplay.Text == "0")
            {
                lblDisplay.Text = "0" + btn.Text;
            }
            
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }
    }
}
