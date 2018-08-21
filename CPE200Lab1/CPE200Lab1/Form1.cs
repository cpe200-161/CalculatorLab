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
        public float firstNumber = 0;
        public float secondNumber = 0;
        public float result;
        public bool Plus = false, Minus = false, Multi = false, Div = false, Equal = false, Dot = true;

        
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
        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "")
                lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            float perCent = float.Parse(lblDisplay.Text)/100;
            if (lblDisplay.Text != "" )
            {
                if(Plus)
                {
                    lblDisplay.Text = (firstNumber + (firstNumber * perCent)).ToString();
                    Plus = false;
                }
                if (Minus)
                {
                    lblDisplay.Text = (firstNumber - (firstNumber * perCent)).ToString();
                    Minus = false;
                }
                if (Multi)
                {
                    lblDisplay.Text = (firstNumber * (firstNumber * perCent)).ToString();
                    Multi = false;
                }
                if (Div)
                {
                    lblDisplay.Text = (firstNumber / (firstNumber * perCent)).ToString();
                    Div = false;
                }
            }
                

            
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
            
            if (lblDisplay.Text != "" && Plus == true )
            {
                secondNumber = float.Parse(lblDisplay.Text);
                result = firstNumber + secondNumber;
                lblDisplay.Text = result.ToString();
                Plus = false;
            }
            

            if (lblDisplay.Text != "" && Minus == true)
            {
                secondNumber = float.Parse(lblDisplay.Text);
                result = firstNumber - secondNumber;
                lblDisplay.Text = result.ToString();
                Minus = false;
            }

            if (lblDisplay.Text != "" && Multi == true)
            {
                secondNumber = float.Parse(lblDisplay.Text);
                result = firstNumber * secondNumber;
                lblDisplay.Text = result.ToString();
                Multi = false;
            }

            if (lblDisplay.Text != "" && Div == true)
            {
                secondNumber = float.Parse(lblDisplay.Text);
                result = firstNumber / secondNumber;
                lblDisplay.Text = result.ToString();
                Div = false;
            }


        }

        private void btnOperator_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            if (btn.Text == "+" && lblDisplay.Text != "")
            {
                firstNumber = float.Parse(lblDisplay.Text);

                lblDisplay.Text = "";
                Plus = true;
                Dot = true;
            }
            else
            {
                Plus = false;
            }

            if (btn.Text == "-" && lblDisplay.Text != "")
            {
                
                firstNumber = float.Parse(lblDisplay.Text);
                lblDisplay.Text = "";
                Minus = true;
                Dot = true;
            }
            else
            {
                Minus = false;
            }

            if (btn.Text == "X" && lblDisplay.Text != "")
            {
                firstNumber = float.Parse(lblDisplay.Text);
                lblDisplay.Text = "";
                Multi = true;
                Dot = true;

            }
            else
            {
                Multi = false;
            }

            if (btn.Text == "÷" && lblDisplay.Text != "")
            {
                firstNumber = float.Parse(lblDisplay.Text);
                lblDisplay.Text = "";
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
            Equal = false;
            Dot = true;
        }
    }
}
