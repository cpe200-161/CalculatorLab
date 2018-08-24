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
       
        float value1 = 0;
        float value2 = 0;
        float frist = 0;
        float value3 = 0;
        float percent;
        string oper = "";
        string oper2;
        bool oper_check = false;
        bool checkoperator=false;
       
        
        bool percentcheck = false ;
        bool equalcheck = false;
        bool checkclick = false;

        bool checkplus = false;
        bool checkminus = false;
        bool checkmulti = false;
        bool checkdivide = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnX_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            if (equalcheck)
            {
                value1 = 0;
                value2 = 0;
                lblDisplay.Text = "0";
                equalcheck = false;
            }

            if ((lblDisplay.Text == "0")||(oper_check))
            {
                oper_check = false;
                lblDisplay.Text = "";
            }
           
            
            if (btn.Text == ".")
            {
                if (!lblDisplay.Text.Contains("."))
                {
                    if (lblDisplay.Text == "")
                    {
                        lblDisplay.Text = "0" + lblDisplay.Text + btn.Text;
                    }
                    else
                    {
                        lblDisplay.Text = lblDisplay.Text + btn.Text;
                    }
                }
                
            }
            else if(lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;

            }
            //else if (lblDisplay.Text.Length >= 8)
            //{
            // lblDisplay.Text = "e";
            // } 

            checkplus = true;
            checkminus = true;
            checkmulti = true;
            checkdivide = true;
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
          
                if (value1 != 0)
                {
                    btnEqual.PerformClick();
                    oper_check = true;
                    oper = "+";
                }
                else
                {
                    value1 = float.Parse(lblDisplay.Text);
                    oper_check = true;
                    oper = "+";
                }

            
            equalcheck = false;
            
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
         
            if (value1 != 0)
            {
                btnEqual.PerformClick();
                oper_check = true;
                oper = "-";
            }
            else
            {
                
                value1 = float.Parse(lblDisplay.Text);
                oper_check = true;
                oper = "-";
            }
            equalcheck = false;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            
            if (value1 != 0)
            {
                btnEqual.PerformClick();
                oper_check = true;
                oper = "*";
            }
            else
            {
               
                value1 = float.Parse(lblDisplay.Text);
                oper_check = true;
                oper = "*";
            }
            equalcheck = false;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
           
            if (value1 != 0)
            {
                btnEqual.PerformClick();
                oper_check = true;
                oper = "/";
            }
            else
            {
                
                value1 = float.Parse(lblDisplay.Text);
                oper_check = true;
                oper = "/";
            }
            equalcheck = false;
        }


        private void btnEqual_Click(object sender, EventArgs e)
        {
            

            switch (oper)
            {
                case "+":
                    if (checkplus)
                    {
                        lblDisplay.Text = (value1 + float.Parse(lblDisplay.Text)).ToString();
                        checkplus = false;
                        checkminus = false;
                        checkmulti = false;
                        checkdivide = false;
                    }
                    break;
                case "-":
                    if (checkminus)
                    {
                        lblDisplay.Text = (value1 - float.Parse(lblDisplay.Text)).ToString();
                        checkplus = false;
                        checkminus = false;
                        checkmulti = false;
                        checkdivide = false;
                    }
                    break;
                case "*":
                    if (checkmulti)
                    {
                        lblDisplay.Text = (value1 * float.Parse(lblDisplay.Text)).ToString();
                        checkplus = false;
                        checkminus = false;
                        checkmulti = false;
                        checkdivide = false;
                    }
                    break;
                case "/":
                    if (checkdivide)
                    {
                        lblDisplay.Text = (value1 / float.Parse(lblDisplay.Text)).ToString();
                        checkplus = false;
                        checkminus = false;
                        checkmulti = false;
                        checkdivide = false;
                    }
                    break;
                case "%":
                    lblDisplay.Text = percent.ToString();

                    break;
                default:
                    break;
            }
           
            checkclick = true;
            equalcheck = true;
            checkoperator = false;
            value1 = float.Parse(lblDisplay.Text);
            
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            value1 = 0;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            value2 = float.Parse(lblDisplay.Text);
          //  percent = (value2 * value1 / 100);
            value3 = (value1 / 100);
            switch (oper) {
                case "+":
                    percent = value1 + (value2 * value1 / 100);
                    break;
                case "-":
                    percent = value1 - (value2 * value1 / 100);
                    break;
                case "*":
                    percent = (value1 * (value2 / 100));
                    break;

                case "/":
                    percent = (value1 * (value2  / 100));
                    break;
            }
           
            oper_check = true;
            oper = "%";
            percentcheck = true;
        }
    }
}
