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
        float first;
        float second;
        float result;
        float mem1;
        bool reCheck = true;
        bool numClickchk = false;
        int operandcheck=0;
        int equalcount=0;
        string display;
        string prev_operand;
        string cur_operand;

        

        public Form1()
        {
            InitializeComponent();
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;

            mem1 = float.Parse(btn.Text);

            numClickchk = true;
            if (reCheck)
                {
                    lblDisplay.Text = "";
                    reCheck = false;
            }
                
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            operandcheck = 0;
            reCheck = true;
            first = 0;
            second = 0;
            result = 0;
            mem1 = 0;
            equalcount = 0;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Button btnn = (Button)sender;
            Calculate(btnn.Text);

        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            Button btnn = (Button)sender;
            Calculate(btnn.Text);
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            Button btnn = (Button)sender;
            //    Calculate(btnn.Text);             
            ShowResult(prev_operand);
            cur_operand = btnn.Text;
        }

        private void Calculate(string Operand)
        {

            cur_operand = Operand;
            if (numClickchk)
            {
                
                if (operandcheck == 0)
                {
                    prev_operand = Operand;
                    first = float.Parse(lblDisplay.Text);
                    operandcheck = operandcheck + 1;
                    reCheck = true;
                }
                else if (operandcheck == 1)
                {
                    ShowResult(prev_operand);
                    
                }               
            }
            prev_operand = cur_operand; // This line for CHANGE OPERATOR
        }

        private void ShowResult(string prevOperand)
        {

            second = float.Parse(lblDisplay.Text);

            if (cur_operand == "="){

                if (prevOperand == "+")
                {
                    result = first + mem1;
                    display = result.ToString();
                    lblDisplay.Text = display;
                    reCheck = true;
                    first = result; 
                }
                else if (prevOperand == "-")
                {
                    result = first - mem1;
                    display = result.ToString();
                    lblDisplay.Text = display;
                    reCheck = true;
                    first = result;
                }
            }
            else
            {                
                if (prevOperand == "+")
                {
                    result = first + second;
                    display = result.ToString();
                    lblDisplay.Text = display;
                    reCheck = true;
                    if (cur_operand != "=")
                    {
                        first = result;
                        operandcheck = 1;
                    }
                    else
                    {
                        operandcheck = 0;
                    }
                    numClickchk = false;
                }
                else if (prevOperand == "-")
                {
                    result = first - second;
                    display = result.ToString();
                    lblDisplay.Text = display;
                    reCheck = true;
                    if (cur_operand != "=")
                    {
                        first = result;
                        operandcheck = 1;
                    }
                    else
                    {
                        operandcheck = 0;
                    }
                    numClickchk = false;
                }
            }
            

        }




    }
}
