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
        double a = 0;
        double b = 0;
        string result = null;
        bool check = false;
        bool check2 = false;
        bool check3 = false;
        string operate;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || check)
            {
                lblDisplay.Text = "";
                check = false;
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
                check3 = true;
            }  
        }
        
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }
        }

        private void Cal()
        {
            System.Console.WriteLine("Now is in cal()");
            System.Console.WriteLine("operate is ??" + operate);
            switch (operate)
            {
                case "+":
                    a = a + b;
                    result = Convert.ToString(a);
                    lblDisplay.Text = result;
                    break;
                case "-":
                    a = a - b;
                    result = Convert.ToString(a);
                    lblDisplay.Text = result;
                    break;
                case "X":
                    a = a * b;
                    result = Convert.ToString(a);
                    lblDisplay.Text = result;
                    break;
                case "÷":
                    a = a / b;
                    result = Convert.ToString(a);
                    lblDisplay.Text = result;
                    break;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            b = Convert.ToDouble(lblDisplay.Text);
            if (check3)
            {
                Cal();
            }
            check3 = false;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            operate = btn.Text;
            if (!check2)
            {
                a = Convert.ToDouble(lblDisplay.Text);
            }
            else
            {
                b = Convert.ToDouble(lblDisplay.Text);
                if (check3)
                {
                    Cal();
                }
            }
            check = true;
            check2 = true;
            check3 = false;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (!check2)
            {
                a = Convert.ToDouble(lblDisplay.Text);
                lblDisplay.Text = "0";
                a = 0;
            }
            else
            {
                if (check3)
                {
                    b = Convert.ToDouble(lblDisplay.Text);
                    System.Console.WriteLine("b in check3 is " + b);
                    switch (operate)
                    {
                        case "+":
                            b = (b / 100) * a;
                            a = a + b;
                            result = Convert.ToString(a);
                            lblDisplay.Text = result;
                            break;
                        case "-":
                            b = (b / 100) * a;
                            a = a - b;
                            result = Convert.ToString(a);
                            lblDisplay.Text = result;
                            break;
                        case "X":
                            a = a * b/100;
                            result = Convert.ToString(a);
                            System.Console.WriteLine("b in X " + a);
                            lblDisplay.Text = result;
                            break;
                        case "÷":
                            a = a / b/100;
                            result = Convert.ToString(a);
                            lblDisplay.Text = result;
                            break;
                    }
                }      
            }
            check = true;
            check2 = true;
            check3 = false; 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            a = 0;
            b = 0;
            result = null;
            operate = "";
            check = false;
            check2 = false;
        }
    }
}
