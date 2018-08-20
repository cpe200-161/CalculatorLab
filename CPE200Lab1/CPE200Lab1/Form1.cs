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
        string operation = "";
        Double num1 = 0;
        Double num2 = 0;
        bool operator_Active = false;
        bool percent_Active = false;
        bool eq_Active = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void num_Button(object sender, EventArgs e)
        {
            if ((lblDisplay.Text == "0")||(operator_Active)||(eq_Active))
                lblDisplay.Text = "";
            if (lblDisplay.Text.Length <= 8)
            {
                eq_Active = false;
                operator_Active = false;
                Button num = (Button)sender;
                if(num.Text == ".")
                {
                    if(!lblDisplay.Text.Contains("."))
                        lblDisplay.Text = lblDisplay.Text + num.Text;
                }
                else
                    lblDisplay.Text = lblDisplay.Text + num.Text;
            }
        }

        private void operation_Button(object sender, EventArgs e)
        {
            if (num1 != 0)
            {
                num2 = Double.Parse(lblDisplay.Text);
                btnEqual.PerformClick();
                operation = "";
                Button operat = (Button)sender;
                operation = operat.Text;
                num1 = Double.Parse(lblDisplay.Text);
                operator_Active = true;
                show_Num.Text = num1.ToString() + " " + operation;
            }
            else
            {
                Button operat = (Button)sender;
                operation = operat.Text;
                num1 = Double.Parse(lblDisplay.Text);
                lblDisplay.Text = "0";
                operator_Active = true;
                show_Num.Text = num1.ToString() + " " + operation;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (percent_Active == true)
            {
                lblDisplay.Text = (num1*(0.01*Double.Parse(lblDisplay.Text))).ToString();
                percent_Active = false;
            }
            num2 = Double.Parse(lblDisplay.Text);
            switch (operation)
            {
                case "+":
                    lblDisplay.Text = (num1 + num2).ToString();
                    break;
                case "-":
                    lblDisplay.Text = (num1 - num2).ToString();
                    break;
                case "X":
                    lblDisplay.Text = (num1 * num2).ToString();
                    break;
                case "÷":
                    lblDisplay.Text = (num1 / num2).ToString();
                    break;
                default:
                    break;
            }
            show_Num.Text = "";
            operator_Active = false;
            eq_Active = true;
            operation = "";
            num1 = 0;
            num2 = 0;
            percent_Show.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            percent_Show.Text = "";
            lblDisplay.Text = "0";
            percent_Active = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            percent_Show.Text = "";
            percent_Active = false;
            show_Num.Text = "";
            lblDisplay.Text = "0";
            operator_Active = false;
            eq_Active = false;
            operation = "";
            num1 = 0;
            num2 = 0;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = ((-1)*Double.Parse(lblDisplay.Text)).ToString();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (num1 != 0)
            {
                if (percent_Active == false)
                {
                    percent_Active = true;
                    percent_Show.Text = "Percent active";
                }               
            }
        }
    }
}
