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
        float a = 0;
        float b = 0;
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
            if (lblDisplay.Text.Length < 2)
            {
                lblDisplay.Text = lblDisplay.Text + ".";
                check3 = true;
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
                    break;
                case "-":
                    a = a - b;
                    break;
                case "X":
                    a = a * b;
                    break;
                case "÷":
                    a = a / b;
                    break;
            }
            result = Convert.ToString(a);
            lblDisplay.Text = result;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            b = float.Parse(lblDisplay.Text);
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
                a = float.Parse(lblDisplay.Text);
            }
            else
            {
                b = float.Parse(lblDisplay.Text);
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
                a = float.Parse(lblDisplay.Text);
                lblDisplay.Text = "0";
                a = 0;
            }
            else
            {
                if (check3)
                {
                    b = float.Parse(lblDisplay.Text);
                    System.Console.WriteLine("b in check3 is " + b);
                    switch (operate)
                    {
                        case "+":
                            a = a + (b / 100) * a;
                            break;
                        case "-":
                            a = a - (b / 100) * a;
                            break;
                        case "X":
                            a = a * (b/100);
                            break;
                        case "÷":
                            a = a / (b/100);
                            break;
                    }
                    result = Convert.ToString(a);
                    lblDisplay.Text = result;
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
