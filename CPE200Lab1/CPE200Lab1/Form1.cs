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
        string firstOperand;
        string secondOperand; 
        bool btn_Clicked = false;
        string operation;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            firstOperand = null;
            secondOperand = null;
            btn_Clicked = false;
            operation = null;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
        
            if (lblDisplay.Text == "0" || btn_Clicked)
            {
                lblDisplay.Text = "";
                btn_Clicked = false;
            }
            if (lblDisplay.Text.Length < 9)
            {
                lblDisplay.Text += ((Button)sender).Text;
            }
            
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            firstOperand = lblDisplay.Text;
            btn_Clicked = true;
            operation = btn.Text;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!btn_Clicked)
                secondOperand = lblDisplay.Text;
            float result = float.Parse(firstOperand);
            switch (operation)
            {
                case "+":
                    result += float.Parse(secondOperand);
                    break;
                case "-":
                    result -= float.Parse(secondOperand);
                    break;
                case "X":
                    result *= float.Parse(secondOperand);
                    break;
                case "÷":
                    result /= float.Parse(secondOperand);
                    break;
            }
            firstOperand = Convert.ToString(result);
            lblDisplay.Text = firstOperand;
            btn_Clicked = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if(operation == "+" || operation == "-")
            {
                lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100 * float.Parse(firstOperand)).ToString();
            }
            else
            {
                lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100).ToString();
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(lblDisplay.Text) * -1).ToString();
        }
    }
}
