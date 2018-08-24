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
        private float num = 0;
        private float v = 0;
        string op = "";
        bool op_pressed = false;
        bool u = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || (op_pressed))
            {
                lblDisplay.Text = "";
                op_pressed = false;
            }
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }

        }

        private void btnOp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            op = btn.Text;
            v = float.Parse(lblDisplay.Text);
            op_pressed = true;
            u = true;
        }


        private void btnCalculate_Click(object sender, EventArgs e)
             {
            num = float.Parse(lblDisplay.Text);
                 switch (op)
                 {
                     case "+":

                         lblDisplay.Text = (v + num).ToString();
                         break;

                     case "-":
                         lblDisplay.Text = (v - num).ToString();
                         break;

                     case "X":
                         lblDisplay.Text = (v * num).ToString();
                         break;

                     case "÷":
                         lblDisplay.Text = (v / num).ToString();
                         break;

                 }
             }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            v = 0;
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
            if(lblDisplay.Text.Length == 1)
            {
                lblDisplay.Text = "0";
            }
            else if (lblDisplay.Text.Length > 1)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            num = float.Parse(lblDisplay.Text);
            if (u == true)
            {
                switch (op)
                {
                    case "+":
                        lblDisplay.Text = ((v * num) / 100).ToString();
                        break;

                    case "-":
                        lblDisplay.Text = ((v * num) / 100).ToString();
                        break;

                    case "X":
                        lblDisplay.Text = ( num / 100).ToString();
                        break;
                    case "÷":
                        lblDisplay.Text = (num / 100).ToString();
                        break;
                }
                
            }else {
                    lblDisplay.Text = (num / 100).ToString();
                    
                }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (float.Parse(lblDisplay.Text)*(-1)).ToString();

        }
    }
}
