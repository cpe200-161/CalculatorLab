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
        string answer, s;
        float n1, n2, order;
        bool plusbtn = false, minusbtn = false, multiplybtn = false, devidebtn = false, percentbtn = false;

        public Form1()
        {
            InitializeComponent();

        }

        private void btnSign_Click(object sender, EventArgs e)
        {

        }

        private void btnDot_Click(object sender, EventArgs e)
        {

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (plusbtn == true)
            {
                if (n1 != 0)
                {
                    n2 = float.Parse(s);
                    s = "";
                    n1 = n2 + n1;
                    n2 = 0;
                    s = n1.ToString();
                    lblDisplay.Text = s;
                    plusbtn = false;
                }
            }

            if (minusbtn == true)
            {
                if (n1 != 0)
                {
                    n2 = float.Parse(s);
                    s = "";
                    n1 = n1 - n2;
                    n2 = 0;
                    s = n1.ToString();
                    lblDisplay.Text = s;
                    minusbtn = false;
                }
            }

            if (multiplybtn == true)
            {
                if (n1 != 0)
                {
                    n2 = float.Parse(s);
                    s = "";
                    n1 = n1 * n2;
                    n2 = 0;
                    s = n1.ToString();
                    lblDisplay.Text = s;
                    multiplybtn = false;
                }
            }

            if (devidebtn == true)
            {
                if (n1 != 0)
                {
                    n2 = float.Parse(s);
                    s = "";
                    n1 = n1 / n2;
                    n2 = 0;
                    s = n1.ToString();
                    lblDisplay.Text = s;
                    devidebtn = false;
                }
            }

            if (percentbtn == true)
            {
                if (n1 != 0)
                {
                    n2 = float.Parse(s);
                    if(n2 == 0)
                    s = "";
                    n1 = (n1 * n2);
                    n2 = 0;
                    s = n1.ToString();
                    lblDisplay.Text = s;
                    devidebtn = false;
                }
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            n1 = float.Parse(s);
            s = "";
            plusbtn = true;
            
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            n1 = float.Parse(s);
            s = "";
            minusbtn = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            s = "";
            lblDisplay.Text = "0";
            n1 = 0; n2 = 0;
            plusbtn = false; minusbtn = false; multiplybtn = false; devidebtn = false;

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            n1 = float.Parse(s);
            s = "";
            multiplybtn = true;

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            n1 = float.Parse(s);
            s = "";
            devidebtn = true;
        }

        

        private void btnX_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                s = "";
            }

            if(lblDisplay.Text.Length < 8)
            {
                s += btn.Text;
                lblDisplay.Text = s;
            }      
        }


        private void btnPercent_Click(object sender, EventArgs e)
        {
            {
                n1 = float.Parse(s);
                n1 /= 100;
                lblDisplay.Text = n1.ToString();
                s = "";
                percentbtn = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}
