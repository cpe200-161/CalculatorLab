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
        String opr = "";
        private bool pressed = false;

        public Form1()
        {
            InitializeComponent();
        }

		private void btnX_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			if ((lblDisplay.Text == "0") || (pressed))
			{
				lblDisplay.Text = "";
                pressed = false;
            }
			if (lblDisplay.Text.Length <= 8)
			{
				lblDisplay.Text = lblDisplay.Text + btn.Text;
			}
		}

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!lblDisplay.Text.Contains("."))
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnOpr_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            opr = btn.Text;
            value = Double.Parse(lblDisplay.Text);
            pressed = true;

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (opr)
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
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            value = 0;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (value * (Double.Parse(lblDisplay.Text) / 100)).ToString();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
                lblDisplay.Text = (Double.Parse(lblDisplay.Text) * (-1)).ToString();
        }
    }
}
