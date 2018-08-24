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
        float  x2, x1;
        int plus = 0;
        int minus = 0;
        int mul = 0;
        int div = 0;
        int dot = 0;

        bool check = false,clear=false;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(clear==true|| lblDisplay.Text == "0"||check==true||dot==1)
            {
                lblDisplay.Text = ""; 
                clear = false;
                check = false;
            }
            if (dot == 1)
            {
                lblDisplay.Text = "0.";
                dot = 0;
            }
            if (lblDisplay.Text.Length <= 7)
                lblDisplay.Text = lblDisplay.Text + btn.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            x1 = 0;
            x2 = 0;
            div = 0;
            plus = 0;
            minus = 0;
            mul = 0;
            dot = 0;
            check = false;
            clear = false;

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (check == true) { plus = 0; minus = 0;mul = 0;div = 0; }
            if (clear == false || check == true)
            {
                if (plus == 1 || div == 1 || mul == 1)
                {
                    x2 = float.Parse(lblDisplay.Text);
                    if (plus == 1) x1 = x1 + x2;
                    else if (div == 1) x1 = x1 / x2;
                    else if (mul == 1) x1 = x1 * x2;
                    lblDisplay.Text = Convert.ToString(x1);
                    x1 = float.Parse(lblDisplay.Text);
                    clear = true;
                    plus = 0;
                    div = 0;
                    mul = 0;
                    minus = 1;
                }
                else if (minus == 0)
                {
                    x1 = float.Parse(lblDisplay.Text);
                    minus = 1;
                    clear = true;
                }
                else if (minus == 1)
                {

                    x2 = float.Parse(lblDisplay.Text);
                    x1 = x1 - x2;
                    lblDisplay.Text = Convert.ToString(x1);
                    x1 = float.Parse(lblDisplay.Text);
                    clear = true;
                }
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (check == true) { plus = 0; minus = 0; mul = 0; div = 0; }
            if (minus == 1 || div == 1 || mul == 1)
            {
                x2 = float.Parse(lblDisplay.Text);
                if (minus == 1) x1 = x1 - x2;
                else if (div == 1) x1 = x1 / x2;
                else if (mul == 1) x1 = x1 * x2;
                lblDisplay.Text = Convert.ToString(x1);
                x1 = float.Parse(lblDisplay.Text);
                clear = true;
                minus = 0;
                div = 0;
                mul = 0;
                plus = 1;
            }
            else if(clear == false || check == true)
            {
                if (plus == 0)
                {
                    x1 = float.Parse(lblDisplay.Text);
                    plus = 1;
                    clear = true;
                }
                else if(plus==1)
                {
                    
                    x2 = float.Parse(lblDisplay.Text);
                    x1 = x1 + x2;
                    lblDisplay.Text = Convert.ToString(x1);
                    x1 = float.Parse(lblDisplay.Text);
                    clear = true;
                }
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (check == true) { plus = 0; minus = 0; mul = 0; div = 0; }
            if (plus == 1 || div == 1 || minus == 1)
            {
                x2 = float.Parse(lblDisplay.Text);
                if (minus == 1) x1 = x1 - x2;
                else if (div == 1) x1 = x1 / x2;
                else if (plus == 1) x1 = x1 + x2;
                lblDisplay.Text = Convert.ToString(x1);
                x1 = float.Parse(lblDisplay.Text);
                clear = true;
                plus = 0;
                div = 0;
                minus = 0;
                mul = 1;
            }
            else if(clear == false || check == true)
            {
                if (mul == 0)
                {
                    x1 = float.Parse(lblDisplay.Text);
                    mul = 1;
                    clear = true;
                }
                else if (mul == 1)
                {

                    x2 = float.Parse(lblDisplay.Text);
                    x1 = x1 * x2;
                    lblDisplay.Text = Convert.ToString(x1);
                    x1 = float.Parse(lblDisplay.Text);
                    clear = true;
                }
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (check == true) { plus = 0; minus = 0; mul = 0; div = 0; }
            if (plus == 1 || minus == 1 || mul == 1)
            {
                x2 = float.Parse(lblDisplay.Text);
                if (minus == 1) x1 = x1 - x2;
                else if (plus == 1) x1 = x1 + x2;
                else if (mul == 1) x1 = x1 * x2;
                lblDisplay.Text = Convert.ToString(x1);
                x1 = float.Parse(lblDisplay.Text);
                clear = true;
                plus = 0;
                minus = 0;
                mul = 0;
                div = 1;
            }
            else if(clear == false || check == true)
            {
                if (div == 0)
                {
                    x1 = float.Parse(lblDisplay.Text);
                    div = 1;
                    clear = true;
                }
                else if (div == 1)
                {

                    x2 = float.Parse(lblDisplay.Text);
                    x1 = x1 / x2;
                    lblDisplay.Text = Convert.ToString(x1);
                    x1 = float.Parse(lblDisplay.Text);
                    clear = true;
                }
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (minus == 1 || plus == 1)
            {
                x2 = float.Parse(lblDisplay.Text);
                x2 = x1 * x2 / 100;
                lblDisplay.Text = Convert.ToString(x2);
            }
            else if (div == 1 || mul == 1)
            {
                x2 = float.Parse(lblDisplay.Text);
                x2 =  x2 / 100;
                lblDisplay.Text = Convert.ToString(x2);
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {   
            if (dot == 0)
            {   
                if(lblDisplay.Text != "0")lblDisplay.Text = lblDisplay.Text + ".";
                lblDisplay.Text = "0.";
                dot = 1;
            }
        }
        

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (clear==false||check==true) {
                if (plus == 1)
                { if (check == false)
                        x2 = float.Parse(lblDisplay.Text);
                    x1 = x1 + x2;
                    lblDisplay.Text = Convert.ToString(x1);
                    x1 = float.Parse(lblDisplay.Text);
                    clear = true; check = true;
                }
                else if (minus == 1)
                {
                    if (check == false)
                    x2 = float.Parse(lblDisplay.Text);
                    x1 = x1 - x2;
                    lblDisplay.Text = Convert.ToString(x1);
                    x1 = float.Parse(lblDisplay.Text);
                    clear = true; check = true;
                }
                else if (mul == 1)
                {
                    if (check == false)
                        x2 = float.Parse(lblDisplay.Text);
                    x1 = x1 * x2;
                    lblDisplay.Text = Convert.ToString(x1);
                    x1 = float.Parse(lblDisplay.Text);
                    clear = true; check = true;
                }
                else if (div == 1)
                {
                    if (check == false)
                        x2 = float.Parse(lblDisplay.Text);
                    x1 = x1 / x2;
                    lblDisplay.Text = Convert.ToString(x1);
                    x1 = float.Parse(lblDisplay.Text);
                    clear = true; check = true;
                }

            }
        }
    }
}
