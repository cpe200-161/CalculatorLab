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
        public Form1()
        {
            InitializeComponent();
        }
        float firstNumber = 0;
        float secondNumber = 0;
        float result, temp = 0;
        bool setFirst = false;
        bool Plus = false, Minus = false, Multi = false, Div = false, Dot = true;
        
        
        



        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            if (lblDisplay.Text == "0")
            {

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

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "")
                lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            secondNumber = float.Parse(lblDisplay.Text);
            float perCent = secondNumber / 100;

            if (lblDisplay.Text != "")
            {
                lblDisplay.Text = (firstNumber * perCent).ToString();
            }



        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(lblDisplay.Text) * -1).ToString();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            
            if (temp == 0)
            {
                temp = float.Parse(lblDisplay.Text);
            }

            if (lblDisplay.Text != "" && Plus == true)
            {
                secondNumber = float.Parse(lblDisplay.Text);
                result = firstNumber + secondNumber;
                lblDisplay.Text = result.ToString();

            }
            if (lblDisplay.Text != "" && Minus == true)
            {

                secondNumber = float.Parse(lblDisplay.Text);
                if (setFirst == false)
                {
                    result = firstNumber - secondNumber;
                    setFirst = true;
                }
                else
                {
                    result = secondNumber - firstNumber;
                }
                lblDisplay.Text = result.ToString();


            }
            if (lblDisplay.Text != "" && Multi == true)
            {
                secondNumber = float.Parse(lblDisplay.Text);
                result = firstNumber * secondNumber;
                lblDisplay.Text = result.ToString();

            }
            if (lblDisplay.Text != "" && Div == true)
            {
                secondNumber = float.Parse(lblDisplay.Text);
                if (setFirst == false)
                {
                    result = firstNumber / secondNumber;
                    setFirst = true;
                }
                else
                {
                    result = secondNumber / firstNumber;
                }

                lblDisplay.Text = result.ToString();


            }
            firstNumber = temp;

        }

        private void btnOperator_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            temp = 0;


            if (btn.Text == "+")
            {
                if (lblDisplay.Text != ""  )
                {
                    firstNumber = float.Parse(lblDisplay.Text);
                    lblDisplay.Text = "";
                    Plus = true;
                    Dot = true;
                    setFirst = false;
                }
                
            }
            else
            {
                Plus = false;
            }

            if (btn.Text == "-")
            {
                if (lblDisplay.Text != "")
                {
                    firstNumber = float.Parse(lblDisplay.Text);
                    lblDisplay.Text = "";
                    Minus = true;
                    Dot = true;
                    setFirst = false;
                }
                
            }
            else
            {
                Minus = false;
            }

            if (btn.Text == "X" && lblDisplay.Text != "")
            {
                if (lblDisplay.Text != "")
                {
                    firstNumber = float.Parse(lblDisplay.Text);
                    lblDisplay.Text = "";
                    Multi = true;
                    Dot = true;
                    setFirst = false;
                }

            }
            else
            {
                Multi = false;
            }

            if (btn.Text == "÷" && lblDisplay.Text != "")
            {
                if (lblDisplay.Text != "")
                {
                    firstNumber = float.Parse(lblDisplay.Text);
                    lblDisplay.Text = "";
                    Div = true;
                    Dot = true;
                    setFirst = false;
                }

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
            clearAll();
        }
        private void clearAll()
        {

            firstNumber = 0;
            secondNumber = 0;
            result = 0;
            Plus = false;
            Minus = false;
            Multi = false;
            Div = false;
            Dot = true;
            temp = 0;
        }
    }
}
