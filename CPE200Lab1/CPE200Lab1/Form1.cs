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
        double value = 0, value_2 = 0;
        string operation = "";
        bool opereation_pressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if ((lblDisplay.Text == "0") || (opereation_pressed))
            {
                lblDisplay.Text = "";
                opereation_pressed = false;
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
            opereation_pressed = true;
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
            opereation_pressed = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+": lblDisplay.Text = (value + double.Parse(lblDisplay.Text)).ToString(); break;
                case "-": lblDisplay.Text = (value - double.Parse(lblDisplay.Text)).ToString(); break;
                case "X": lblDisplay.Text = (value * double.Parse(lblDisplay.Text)).ToString(); break;
                case "÷": lblDisplay.Text = (value / double.Parse(lblDisplay.Text)).ToString(); break;
                default: break;
            }
            opereation_pressed = true;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            value = (Double.Parse(lblDisplay.Text) * -1);
            lblDisplay.Text = value.ToString();
            opereation_pressed = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            value = 0;
        }
    }
}
