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

        Double firstnumber = 0;
        Double secondnumber = 0;
        Double percent = 0;
        string operation = "";
        string plus_number = "";
        bool cheakoperator_click = false;
        bool cheakpercent_click = false;
        bool cheakplusminus_click = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if ((lblDisplay.Text == "0") || (cheakoperator_click))
            {
                lblDisplay.Text = "";
            }
            cheakoperator_click = false;
            Button bt = (Button)sender;
            if (lblDisplay.Text.Length < 9)
            {
                lblDisplay.Text = lblDisplay.Text + bt.Text;
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            firstnumber = Double.Parse(lblDisplay.Text);
            operation = bt.Text;
            cheakoperator_click = true;

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            secondnumber = Double.Parse(lblDisplay.Text);
            if (cheakpercent_click) 
            {
                secondnumber = ((secondnumber / 100) * firstnumber);
            }
            switch (operation)
            {
                case "+":
                    lblDisplay.Text = (firstnumber + secondnumber).ToString(); break;
                case "-":
                    lblDisplay.Text = (firstnumber - secondnumber).ToString(); break;
                case "X":
                    lblDisplay.Text = (firstnumber * secondnumber).ToString(); break;
                case "÷":
                    lblDisplay.Text = (firstnumber / secondnumber).ToString(); break;
                default:
                    break;     
            }
            cheakoperator_click = false;
        }

        private void percent_Click(object sender, EventArgs e)
        {
            percent = (secondnumber / 100) * firstnumber;
            cheakpercent_click = true;
        }

        private void btnSign_Click(object sender, EventArgs e)
        { 
            if (lblDisplay.Text != "0")
            {
                if (cheakplusminus_click)
                {
                    plus_number = lblDisplay.Text;
                    lblDisplay.Text = "-" + lblDisplay.Text;
                    cheakplusminus_click = false;
                }
                else
                {
                    lblDisplay.Text = plus_number;
                    cheakplusminus_click = true;
                }

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int length = lblDisplay.Text.Length - 1;
            if (length <= 0)
            {
                lblDisplay.Text = "0";
            }
            else if (lblDisplay.Text != "0")
            {  
                string display = lblDisplay.Text;
                lblDisplay.Text = "";
                for (int i = 0; i < length; i++)
                {
                    lblDisplay.Text += display[i];
                } 
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            firstnumber = 0;
            secondnumber = 0;
            percent = 0;
            operation = "";
            cheakoperator_click = false;
            cheakpercent_click = false;
        }
    }
}

        