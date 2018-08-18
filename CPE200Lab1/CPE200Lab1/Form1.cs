﻿using System;
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
        public string result ;
        public bool Plus=false, Minus=false, Multi=false, Div=false,Equal = true,Dot = true;
        public bool setFirstnumber = false, setSecoundnumber = false;
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
                if (lblDisplay.Text == "0" ) {
                
                lblDisplay.Text = "";
                }
                if (lblDisplay.Text.Length < 8)
                {
                    lblDisplay.Text += btn.Text;
                    
                }
                else
                {
                lblDisplay.Text = "overflow";
                clearAll();
                }


        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (Dot == true)
            {
                lblDisplay.Text += ".";
                Dot = false;
            }
         }
        private void lblDisplay_Click(object sender, EventArgs e)
        {
            
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text != "")
            lblDisplay.Text = lblDisplay.Text.Substring(0,lblDisplay.Text.Length-1);
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text != "")
            lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100).ToString();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(lblDisplay.Text) * -1).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
           
            
            if (lblDisplay.Text != "" && Plus == true)
            {
                number2 = lblDisplay.Text;
                result = (float.Parse(number1) + float.Parse(number2)).ToString();
                lblDisplay.Text = result;
                
                Plus = false;
            }
            
            if (lblDisplay.Text != "" && Minus == true)
            {
                number2 = lblDisplay.Text;
                result = (float.Parse(number1) - float.Parse(number2)).ToString();
                lblDisplay.Text = result;
                
                Minus = false;
            }
            
            if (lblDisplay.Text != "" && Multi == true)
            {
                number2 = lblDisplay.Text;
                result = (float.Parse(number1) * float.Parse(number2)).ToString();
                lblDisplay.Text = result;
                
                Multi = false;
            }
            
            if (lblDisplay.Text != "" && Div == true)
            {
                number2 = lblDisplay.Text;
                result = (float.Parse(number1) / float.Parse(number2)).ToString();
                lblDisplay.Text = result;
                Div = false;
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
                Dot = true;
                
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
                Dot = true;
                

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
                Dot = true;
                
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
                Dot = true;
                
            }
            else
            {
                Div = false;
               
            }
            if (lblDisplay.Text.Length > 8)
            {
                lblDisplay.Text = "overflow";
                clearAll();

            }






        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            number1 = "0";
            number2 = "0";
            result = "0";
            Plus = false;
            Minus = false;
            Multi = false;
            Div = false;
            Equal = false;
            Dot = true;
        }
        private void clearAll()
        {
            
            number1 = "0";
            number2 = "0";
            result = "0";
            Plus = false;
            Minus = false;
            Multi = false;
            Div = false;
            Equal = false;
            Dot = true;
        }
    }
}
