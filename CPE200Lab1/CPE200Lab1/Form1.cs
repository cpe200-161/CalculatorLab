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
        int count = 1;
        private string firstOperand = null;
        private string secondOperand = null;
        private int calculationState = 0;
        float First_Operand = 0;
        float Second_Operand = 0;
        float temp=0;
        float ans = 0;
        int Operator = 0;
        int prioty = 0;
        bool candivide = true;
        bool checkOperator = false;
        bool checkequal = false;
        bool checkdot = false;
        public Form1()
        {
            InitializeComponent();
        } 
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            checkdot = false;
            if (checkequal == true)
            {
                lblDisplay.Text = null;
                checkequal = false;
            }
            
            if(lblDisplay.Text=="0")
            {
                lblDisplay.Text = "";
            }
            if (prioty == 0)
            {
                if (candivide == true)
                {
                    lblDisplay.Text = null;
                    candivide = false;
                }

                if (lblDisplay.Text.Length <= 8)
                {
                    lblDisplay.Text = lblDisplay.Text + btn.Text;
                    First_Operand = float.Parse(lblDisplay.Text);
                    
                }
            }
           
            if (prioty == 1)
            {
               if(checkOperator == true)
                {
                    lblDisplay.Text = null ;
                    checkOperator = false;
                }
                if (lblDisplay.Text.Length <= 8)
                {
                    lblDisplay.Text = lblDisplay.Text + btn.Text;
 
                    Second_Operand = float.Parse(lblDisplay.Text);
                }
              
             
            }
           
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            
            prioty = 1;
            Operator = 1;
            checkOperator = true;
 
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
           
            prioty = 1;
            Operator = 2;
            checkOperator = true;
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
           
            prioty = 1;
            Operator = 3;
            checkOperator = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
 
            prioty = 1;
            Operator = 4;
            checkOperator = true;
        }




        private void btnEqual_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = null;
            if (Operator == 1)
            {
                temp = First_Operand + Second_Operand;
            }
            lblDisplay.Text = temp.ToString();
            if (Operator == 2)
            {
                temp = First_Operand - Second_Operand;
            }
            lblDisplay.Text = temp.ToString();
            if (Operator == 3)
            {
                temp = First_Operand * Second_Operand;
            }
            lblDisplay.Text = temp.ToString();
            if (Operator == 4)
            {
                if (Second_Operand == 0)
                {

                    candivide = true;
                }
                else
                {
                    temp = First_Operand / Second_Operand;

                }
            }
            if (candivide == true)
            {
                lblDisplay.Text = "error";
                First_Operand = 0;
                Second_Operand = 0 ;
            }
            else
            {
                First_Operand = temp;
                lblDisplay.Text = temp.ToString();
            }
            
            Operator = 0;
            prioty =  0;
            checkequal = true;
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            First_Operand = 0;
            Second_Operand = 0;
            Operator = 0;
            prioty = 0;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
           
                Second_Operand  = (Second_Operand * First_Operand) / 100;
            if (Operator == 1)
            {
                temp = First_Operand + Second_Operand;
            }
            else if (Operator == 2)
            {
                temp = First_Operand - Second_Operand;
            }
            
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (checkdot == false)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
                checkdot = true;
            }
            else if(lblDisplay.Text == "0")
            {
                lblDisplay.Text = "0" + btn.Text;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if(prioty == 0)
            {
                First_Operand = First_Operand * -1;
              if(First_Operand > 0)
                {
                    lblDisplay.Text = "-" + lblDisplay.Text;
                    lblDisplay.Text = String.Format("{0:G}", First_Operand);
                }
              else
                {
                    lblDisplay.Text = String.Format("{0:G}",First_Operand);   
                }
 
            }
            else
            {
                Second_Operand = Second_Operand * -1;
                if (Second_Operand > 0)
                {
                    lblDisplay.Text = "-" + lblDisplay.Text;
                    lblDisplay.Text = String.Format("{0:G}", Second_Operand);
                }
                else
                {
                    lblDisplay.Text = String.Format("{0:G}", Second_Operand);
                }
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            if(lblDisplay.Text == "")
            {
                lblDisplay.Text = "0";
            }
            if (prioty == 0)
            {
                First_Operand = float.Parse(lblDisplay.Text);
            }
            else
            {
                Second_Operand = float.Parse(lblDisplay.Text);
            }
        }
    }
}
