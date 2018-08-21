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
        string firstOperand = null;
        string secondOperand = null;
        bool reset = false;
        int operation;
        int firstPercentDivide = 1;
        int secondPercentDivide = 1;
        string result1;
        string result2;
        string result3;
        string result4;
        string result5;

        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }
        
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || (firstOperand != null && reset == true))
            {
                lblDisplay.Text = "";
            }

            reset = false;

            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            reset = true;
            operation = 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            reset = true;
            operation = 2;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            reset = true;
            operation = 3;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            firstOperand = lblDisplay.Text;
            reset = true;
            operation = 4;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            secondOperand = lblDisplay.Text;
            reset = false;

            if (operation == 1)
            {
                result1 = ((float.Parse(firstOperand)/firstPercentDivide) + (float.Parse(secondOperand)/secondPercentDivide)).ToString();
                lblDisplay.Text = result1;
            }
            else if (operation == 2)
            {
                result2 = ((float.Parse(firstOperand)/firstPercentDivide) - (float.Parse(secondOperand)/secondPercentDivide)).ToString();
                lblDisplay.Text = result2;
            }
            else if (operation == 3)
            {
                result3 = ((float.Parse(firstOperand)/firstPercentDivide) * (float.Parse(secondOperand)/secondPercentDivide)).ToString();
                lblDisplay.Text = result3;
            }
            else if (operation == 4)
            {
                result4 = ((float.Parse(firstOperand)/firstPercentDivide) / (float.Parse(secondOperand)/secondPercentDivide)).ToString();
                lblDisplay.Text = result4;
            }
            else if (operation == 5)
            {
                result5 = (float.Parse(secondOperand) / firstPercentDivide).ToString();
                lblDisplay.Text = result5;
            }
            firstPercentDivide = 1;
            secondPercentDivide = 1;
            firstOperand = null;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if(firstOperand == null)
            {
                firstPercentDivide = 100;
                operation = 5;
            }
            else
            {
                secondPercentDivide = 100;
            }
            reset = true;
        }
    }
}
