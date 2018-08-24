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
        float num1 = 0, num2 = 0;


        int Operator = 0;
        int OpertorPressed = 0;
        int statnum1 = 0;
        int statnum2 = 0;
        int statnum3 = 0;
        int statnum4 = 0;


        public Form1()
        {
            InitializeComponent();
        }
        private void computing()
        {
            switch (Operator)
            {
                case 1:

                    num2 = num1 + float.Parse(lblDisplay.Text);
                    lblDisplay.Text = num2.ToString();
                    statnum1 = 0;
                    Operator = 0;
                    break;
                case 2:

                    num2 = num1 - float.Parse(lblDisplay.Text);
                    lblDisplay.Text = num2.ToString();
                    statnum2 = 0;
                    Operator = 0;
                    break;
                case 3:

                    num2 = num1 * float.Parse(lblDisplay.Text);
                    lblDisplay.Text = num2.ToString();
                    statnum3 = 0;
                    Operator = 0;
                    break;
                case 4:
                    float x = float.Parse(lblDisplay.Text);
                    if (num1 == 0)
                    {
                        if (x == 0) lblDisplay.Text = "Error";

                    }
                    else if (num1 != 0 && x == 0)
                    {
                        lblDisplay.Text = "Can't divide by zero";
                    }
                    else
                    {
                        num2 = num1 / float.Parse(lblDisplay.Text);
                        string num2_str = num2.ToString();
                        statnum4 = 0;
                        Operator = 0;
                        if (num2 % 1 == 0)
                        {
                            lblDisplay.Text = String.Format("{0:0}", num2);
                        }
                        else if (num2_str.Length >= 6)
                        {

                            lblDisplay.Text = String.Format("{0:F6}", num2);
                        }
                        else
                        {
                            lblDisplay.Text = String.Format("{0:G}", num2);
                        }
                    }
                    break;
                
                   

                    

                default:
                    break;
            }
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (statnum1 == 0)
            {

                num1 = float.Parse(lblDisplay.Text);
                lblDisplay.Text = num1.ToString();
                statnum1++;
            }
            else if (statnum1 != 0)
            {
                num1 = num1 + float.Parse(lblDisplay.Text);
                lblDisplay.Text = lblDisplay.Text;
            }
            if (Operator == 4 || Operator == 2 || Operator == 3) lblDisplay.Text = "Can't calculate.";
            Operator = 1;
            OpertorPressed = 1;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            Operator = 0;
            statnum1 = 0;
            statnum2 = 0;
            statnum3 = 0;
            statnum4 = 0;
            num1 = 0;
            num2 = 0;


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
            if (lblDisplay.Text != "0")
            {
                int length = lblDisplay.Text.Length - 1;
                string text = lblDisplay.Text;
                lblDisplay.Text = "";
                for (int i = 0; i < length; i++)
                {
                    lblDisplay.Text = lblDisplay.Text + text[i];
                }
                if (lblDisplay.Text == "") lblDisplay.Text = "0";
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (statnum2 == 0)
            {

                num1 = float.Parse(lblDisplay.Text);
                lblDisplay.Text = num1.ToString();
                statnum2++;
            }
            else if (statnum2 != 0)
            {
                num1 = num1 - float.Parse(lblDisplay.Text);
                lblDisplay.Text = lblDisplay.Text;
            }
            if (Operator == 1 || Operator == 4 || Operator == 3) lblDisplay.Text = "Can't calculate.";
            Operator = 2;
            OpertorPressed = 1;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (statnum3 == 0)
            {

                num1 = float.Parse(lblDisplay.Text);
                lblDisplay.Text = num1.ToString();
                statnum3++;
            }
            else if (statnum3 != 0)
            {
                num1 = num1 * float.Parse(lblDisplay.Text);
                lblDisplay.Text = lblDisplay.Text;
            }
            if (Operator == 1 || Operator == 2 || Operator == 4) lblDisplay.Text = "Can't calculate.";
            Operator = 3;
            OpertorPressed = 1;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (statnum4 == 0)
            {

                num1 = float.Parse(lblDisplay.Text);
                lblDisplay.Text = num1.ToString();
                statnum4++;
            }
            else if (statnum4 != 0)
            {
                num1 = num1 * float.Parse(lblDisplay.Text);
                lblDisplay.Text = lblDisplay.Text;
            }
            if (Operator == 1 || Operator == 2 || Operator == 3) lblDisplay.Text = "Can't calculate.";
            Operator = 4;
            OpertorPressed = 1;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (statnum1 == 0 && statnum2 == 0 && statnum3 == 0 && statnum4 == 0)
            {
                num1 = float.Parse(lblDisplay.Text);
                num1 = num1 / 100f;
                lblDisplay.Text = num1.ToString();
            }
            
            if (statnum1 != 0 || statnum2 != 0 || statnum3 != 0 || statnum4 != 0)
            {
                num2 = float.Parse(lblDisplay.Text);
                lblDisplay.Text = (num1 * (num2) / 100f).ToString();
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length < 8 || OpertorPressed == 1)
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
