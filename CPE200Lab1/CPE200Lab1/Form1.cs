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
        string anw1 = null;
        string anw2 = null;
        bool plus = false;
        bool minus = false;
        bool multiply = false;
        bool divide = false;
        bool percent = false;
        int a = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }

            if (plus == true || minus == true || multiply == true || divide == true || percent == true)
            {
                if (a == 0)
                {
                    lblDisplay.Text = "";
                    a++;
                }
                lblDisplay.Text += btn.Text;
                anw2 = lblDisplay.Text;
            }else if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            anw1 = lblDisplay.Text;
            plus = true;
            if (minus == true || multiply == true || divide == true || percent == true)
            {
                minus = false;
                multiply = false;
                divide = false;
                percent = false;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            anw1 = lblDisplay.Text;
            minus = true;
            if (plus == true || multiply == true || divide == true || percent == true)
            {
                plus = false;
                multiply = false;
                divide = false;
                percent = false;
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            anw1 = lblDisplay.Text;
            multiply = true;
            if (plus == true || minus == true || divide == true || percent == true)
            {
                plus = false;
                minus = false;
                divide = false;
                percent = false;
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            anw1 = lblDisplay.Text;
            divide = true;
            if (plus == true || minus == true || multiply == true || percent == true)
            {
                plus = false;
                minus = false;
                multiply = false;
                percent = false;
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            anw1 = lblDisplay.Text;
            percent = true;
            if (plus == true || minus == true || multiply == true || divide == true)
            {
                plus = false;
                minus = false;
                multiply = false;
                divide = false;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            float anw=0;
            if (plus == true)
            {
                anw = float.Parse(anw1) + float.Parse(anw2);
                lblDisplay.Text = anw.ToString();
            }
            else if (minus == true)
            {
                anw = float.Parse(anw1) - float.Parse(anw2);
                lblDisplay.Text = anw.ToString();
            }
            else if (multiply == true)
            {
                anw = float.Parse(anw1) * float.Parse(anw2);
                lblDisplay.Text = anw.ToString();
            }
            else if (divide == true)
            {
                anw = float.Parse(anw1) / float.Parse(anw2);
                lblDisplay.Text = anw.ToString();
            }
            else if (percent == true)
            {
                if (anw2 == "" || anw2 == null) {
                    anw = float.Parse(anw1) / 100;
                    lblDisplay.Text = anw.ToString();
                }
                else if(anw2 != "" || anw2 != null)
                {
                    anw = (float.Parse(anw1) / 100) * float.Parse(anw2);
                    lblDisplay.Text = anw.ToString();
                }
                
            }
                
            plus = false;
            minus = false;
            multiply = false;
            divide = false;
            percent = false;
            a = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text.Length > 1)
            {
               lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
            }else if(lblDisplay.Text.Length == 1)
            {
                lblDisplay.Text = "0";
            }            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            anw1 = "";
            anw2 = "";
            plus = false;
            minus = false;
            multiply = false;
            divide = false;
            percent = false;
            lblDisplay.Text = "0";
            a = 0;
        }
           


    }
}
