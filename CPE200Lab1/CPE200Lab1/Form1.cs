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

        string Input = string.Empty; 
        string Num1 = string.Empty;
        string Num2 = string.Empty;
        char Operation;
        bool Percent = false;
        bool Plus = false;

        double Result = 0.0;

        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            Result = 0;
            Num1 = "";
            Num2 = "";
            Input = string.Empty;
            
           lblDisplay.Text = "0";

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            Input += 1;
            lblDisplay.Text += Input;
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            Input += 2;
            lblDisplay.Text += Input;

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            Input += 3;
            lblDisplay.Text += Input;

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            Input += 4;
            lblDisplay.Text += Input;

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            Input += 5;
            lblDisplay.Text += Input;

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            Input += 6;
            lblDisplay.Text += Input;

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            Input += 7;
            lblDisplay.Text = Input;

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            Input += 8;
            lblDisplay.Text += Input;

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            Input += 9;
            lblDisplay.Text += Input;

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if ((Input != string.Empty))
            {
                lblDisplay.Text = "";
                Input += 0;
                lblDisplay.Text += Input;
            }
            else
            {
                Input = string.Empty;
                lblDisplay.Text = "0";
            }



        }

        private void btnPlus_Click(object sender, EventArgs e)
        {   if(Num1 == string.Empty) { 
            Num1 = Input;}
            Operation = '+';
            Input = string.Empty;
            Percent = true;


        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (Num1 == string.Empty) {
            Num1 = Input;}
                
            
            Operation = '-';
            Input = string.Empty;
            Percent = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (Num1 == string.Empty){
            Num1 = Input;}
                
            
            Operation = '*';
            Input = string.Empty;
            Percent = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (Num1 == string.Empty){
            Num1 = Input;}
                
            
            Operation = '/';
            Input = string.Empty;
            Percent = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Num2 = Input;
            double num1, num2;                  // make new object to change string to double
            double.TryParse(Num1, out num1);    //double.TryPrase(string, out to double object)
            double.TryParse(Num2, out num2);
            if (Percent == true)
            {
                num2 = double.Parse(Num1) * (double.Parse(Num2) * 0.01);
                Percent = false;
            }
            else
            {
                Num2 = Input;
            }
            
            

            if (Operation == '+')
            {
                Result = num1 + num2;

                lblDisplay.Text = Result.ToString();
                Plus = true;
                Percent = true;
            }
            else if (Operation == '-')
            {
                Result = num1 - num2;

                lblDisplay.Text = Result.ToString();

                Percent = true;
            }
            else if (Operation == '*')
            {
                Result = num1 * num2;
                lblDisplay.Text = Result.ToString();

                Percent =  true;
            }
            else if (Operation == '/')
            {
                if (num2 != 0)
                {
                    Result = num1 / num2;
                    num1 = Result;
                    lblDisplay.Text = Result.ToString();
                    Result = 0;
                    Num2 = string.Empty;

                    Percent =  true;

                }
                else
                {
                    lblDisplay.Text = "null";    // not define in Mathmatics
                }



            }
            

            
            Num1 = Result.ToString();
            num1 = Result;
            
            
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (Num1 == string.Empty)
            {
                Num1 = string.Empty;
                lblDisplay.Text = "0";
                Input = string.Empty;
             }       

            else
            { 
                Percent = true;
            }

            
            
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!Input.Contains("."))
            {
              
            Input += ".";
            lblDisplay.Text += ".";
            }
            
        }
    }
}
