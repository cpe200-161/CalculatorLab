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
        string operation = "";
        string plus_number = "";
        bool cheakoperator_click = false;
        bool minus_number = true;


        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if((lblDisplay.Text == "0")||(cheakoperator_click))
            {
                lblDisplay.Text = "";
            }
            cheakoperator_click = false;
            Button bt = (Button)sender;
            if(lblDisplay.Text.Length < 9)
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
            switch(operation)
            {
                case "+":
                    lblDisplay.Text = (firstnumber + Double.Parse(lblDisplay.Text)).ToString(); break;
                case "-":
                    lblDisplay.Text = (firstnumber - Double.Parse(lblDisplay.Text)).ToString(); break;
                case "X":
                    lblDisplay.Text = (firstnumber * Double.Parse(lblDisplay.Text)).ToString(); break;
                case "÷":
                    lblDisplay.Text = (firstnumber / Double.Parse(lblDisplay.Text)).ToString(); break;
                case "%":
                    lblDisplay.Text = ((firstnumber/100) * (Double.Parse(lblDisplay.Text))).ToString(); break;
                default: break;
            }
            cheakoperator_click = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "0")
            {
                if (minus_number)
                {
                    plus_number = lblDisplay.Text;
                    lblDisplay.Text = "-" + lblDisplay.Text;
                    minus_number = false;
                }
                else
                {
                    lblDisplay.Text = plus_number;
                    minus_number = true;
                }

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "0")
            {
                int length = lblDisplay.Text.Length - 1;
                string display = lblDisplay.Text;
                lblDisplay.Text = "";
                for (int i = 0; i < length; i++)
                {
                    lblDisplay.Text += display[i];
                }
            }
        }
    }
}
