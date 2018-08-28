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
        double value = 0, value_2 = 0, fin_value = 0;
        string operation = "";
        bool operation_pressed = false;
        bool dot_pressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if ((lblDisplay.Text == "0") || (operation_pressed))
            {
                lblDisplay.Text = "";
                operation_pressed = false;
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            operation = btn.Text;
            value = Double.Parse(lblDisplay.Text);
            switch (operation)
            {
                case "+": fin_value = value + double.Parse(lblDisplay.Text).ToString(); break;
                case "-": value = value - double.Parse(lblDisplay.Text).ToString(); break;
                case "X": value = value * double.Parse(lblDisplay.Text).ToString(); break;
                case "÷": value = value / double.Parse(lblDisplay.Text).ToString(); break;
                default: break;
            }
            operation_pressed = true;
            dot_pressed = false;
        }

        private void operator_Percent(object sender, EventArgs e)
        {
            if (value != 0)
            {
                value_2 = (Double.Parse(lblDisplay.Text) / 100) * value;
            }
            else if (value == 0)
            {
                value_2 = (Double.Parse(lblDisplay.Text) / 100);
            }
            lblDisplay.Text = value_2.ToString();
            operation_pressed = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = value.ToString();
            operation_pressed = true;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            value = (Double.Parse(lblDisplay.Text) * -1);
            lblDisplay.Text = fin_value.ToString();
            operation_pressed = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
            if(lblDisplay.Text == "")
            {
                lblDisplay.Text = "0";
            }
            operation_pressed = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if(dot_pressed == false)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }
            dot_pressed = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            value = 0;
        }
    }
}
