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
        float percent;
        bool dotCheck = false;
        bool reCheck = true;
        bool numClickchk = false;
        int operandcheck=0;
        //int equalcount=0;
        string display;
        string prev_operand = "";
        string cur_operand = "";

        

        public Form1()
        {
            InitializeComponent();
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;

            if (cur_operand == "=")
            {
                ClearSc();
            }

            numClickchk = true;

            if (reCheck)
                {
                    lblDisplay.Text = "";
                    reCheck = false;
            }
            //if (cur_operand == "=")
            //{
            //    lblDisplay.Text = "";
            //}
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                mem1 = float.Parse(lblDisplay.Text + btn.Text);
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSc();
        }

        private void ClearSc()
        {
            lblDisplay.Text = "0";
            operandcheck = 0;
            reCheck = true;
            dotCheck = false;
            numClickchk = false;
            first = 0;
            second = 0;
            result = 0;
            mem1 = 0;
            //equalcount = 0;
            prev_operand = "";
            cur_operand = "";
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!dotCheck)
            {
                if (lblDisplay.Text.Length <= 8)
                {
                    mem1 = float.Parse(lblDisplay.Text + btn.Text);
                    lblDisplay.Text = lblDisplay.Text + btn.Text;
                }
                dotCheck = true;
            }
        }
        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length <= 8)
            {
                if (lblDisplay.Text.First() == '-')
                {
                    lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
                }
                else
                {
                    lblDisplay.Text = "-" + lblDisplay.Text;
                }                
            }
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (prev_operand == "+" || prev_operand == "-")
            {
                percent = first * (float.Parse(lblDisplay.Text) / 100);
                lblDisplay.Text = percent.ToString();
            }
            else if (prev_operand == "X" || prev_operand == "÷")
            {
                percent = (float.Parse(lblDisplay.Text) / 100);
                lblDisplay.Text = percent.ToString();
            }

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Button btnn = (Button)sender;
            Calculate(btnn.Text);
            dotCheck = false;

        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            Button btnn = (Button)sender;
            Calculate(btnn.Text);
            dotCheck = false;
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            Button btnn = (Button)sender;
            Calculate(btnn.Text);
            dotCheck = false;
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            Button btnn = (Button)sender;
            if (lblDisplay.Text.Last() == '.')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
            }
            else
            {
                Calculate(btnn.Text);
            }
            
            dotCheck = false;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Button btnn = (Button)sender;
            if (lblDisplay.Text.Length > 0)
            {
                if (lblDisplay.Text.Length == 1)
                {
                    lblDisplay.Text = "0";
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
                }
            }           
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            Button btnn = (Button)sender;
            if (lblDisplay.Text.Last() == '.' && prev_operand == "")
            {
                lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length-1);
            }
            else
            {
                ShowResult(prev_operand);
                cur_operand = btnn.Text;
            }

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
                    numClickchk = false;
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

            if (prevOperand == "=")
            {
                ClearSc();
            }
            else
            {
                second = float.Parse(lblDisplay.Text);



                if (cur_operand == "=")
                {

                    if (prevOperand == "+")
                    {
                        result = first + mem1;
                        display = result.ToString();
                        lblDisplay.Text = display;
                        reCheck = true;
                        first = result;
                        // numClickchk = false;
                    }
                    else if (prevOperand == "-")
                    {
                        result = first - mem1;
                        display = result.ToString();
                        lblDisplay.Text = display;
                        reCheck = true;
                        first = result;
                        // numClickchk = false;
                    }
                    else if (prevOperand == "X")
                    {
                        result = first * mem1;
                        display = result.ToString();
                        //display = display.PadLeft(9, ' ').Substring(0, 9);
                        //StringBuilder
                        lblDisplay.Text = display;
                        reCheck = true;
                        first = result;
                        //  numClickchk = false;
                    }
                    else if (prevOperand == "÷")
                    {
                        if (mem1 == 0)
                        {
                            lblDisplay.Text = "Error";
                            prev_operand = "=";

                        }
                        else
                        {
                            result = first / mem1;
                            display = result.ToString();
                            lblDisplay.Text = display;
                            reCheck = true;
                            first = result;
                            //   numClickchk = false;
                        }
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
                    else if (prevOperand == "X")
                    {
                        result = first * second;
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
                    else if (prevOperand == "÷")
                    {
                        if (mem1 == 0)
                        {
                            lblDisplay.Text = "Error";
                            prev_operand = "=";
                        }
                        else
                        {
                            result = first / second;
                            display = result.ToString();
                            lblDisplay.Text = display;
                            reCheck = true;
                        }

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
}
