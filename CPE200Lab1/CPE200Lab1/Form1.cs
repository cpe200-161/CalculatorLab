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
        Double value = 0;
        string oparetion = "";
        bool oparetion_pressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if ((lblDisplay.Text == "0") || (oparetion_pressed))
            {
                lblDisplay.Text = "";
            }
            oparetion_pressed = false;

            if (lblDisplay.Text.Length <= 7)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            value = 0;
            lblDisplay.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            oparetion = btn.Text;
            value = Double.Parse(lblDisplay.Text);
            oparetion_pressed = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (oparetion)
            {
                case "+":
                    lblDisplay.Text = (value + Double.Parse(lblDisplay.Text)).ToString();
                    break;
                case "-":
                    lblDisplay.Text = (value - Double.Parse(lblDisplay.Text)).ToString();
                    break;
                case "X":
                    lblDisplay.Text = (value * Double.Parse(lblDisplay.Text)).ToString();
                    break;
                case "÷":
                    lblDisplay.Text = (value / Double.Parse(lblDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            oparetion_pressed = false;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (value * (Double.Parse(lblDisplay.Text) / 100)).ToString();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.StartsWith("-"))
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1);
            }
            else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text.Length > 0)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
            }
        }

        private void btnDot_click(object sender, EventArgs e)
        {
            if (!lblDisplay.Text.Contains("."))
            {
                lblDisplay.Text = lblDisplay.Text + ".";

            }
        }
    }
}
