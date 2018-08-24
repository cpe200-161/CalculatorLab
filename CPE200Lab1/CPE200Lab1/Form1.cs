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
        float result = 0;
        String operate = "";
        bool opt_form = false; 
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if ((lblDisplay.Text == "0")||(opt_form))
            {
                lblDisplay.Text = "";
            }
         
            opt_form = false;
            if (lblDisplay.Text.Length < 8)
            {
                if (num.Text == ".")
                {
                    if (!lblDisplay.Text.Contains("."))
                    {
                        lblDisplay.Text = lblDisplay.Text + num.Text;
                    }
                }
                else
                {
                    lblDisplay.Text = lblDisplay.Text + num.Text;
                }
                
            }
        }

        private void opt_click(object sender, EventArgs e)
        {
            Button operations = (Button)sender;
            if (result != 0)
            {
                if (opt_form == false)
                {
                    btnEqual.PerformClick();
                }
                operate = operations.Text;
                result = float.Parse(lblDisplay.Text);
                opt_form = true;
            }
            else
            {
                operate = operations.Text;
                result = float.Parse(lblDisplay.Text);
                opt_form = true;
            }
        }
        
        private void opt_equal_click(object sender, EventArgs e)
        {   
            switch(operate)
            {
                case "+":
                    lblDisplay.Text = (result + float.Parse(lblDisplay.Text)).ToString();
                        break;
                case "-":
                    lblDisplay.Text = (result - float.Parse(lblDisplay.Text)).ToString();
                    break;
                case "X":
                    lblDisplay.Text = (result * float.Parse(lblDisplay.Text)).ToString();
                    break;
                case "÷":
                    lblDisplay.Text = (result / float.Parse(lblDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = 0;
            operate = "";
        }

        private void c_click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void invert_click(object sender, EventArgs e)
        {
            lblDisplay.Text = ((-1) * float.Parse(lblDisplay.Text)).ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (result * (float.Parse(lblDisplay.Text) / 100)).ToString();
        }
    }
}
