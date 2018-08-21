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
        string ans1;
        string ans2;
        float ans;
        bool plus = false;
        bool minus = false;
        bool multiply = false;
        bool divide = false;
        bool percent = false;
        int a = 0;
        int b = 0;

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

            if (plus == false && minus == false && multiply == false && divide == false && percent == false && lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
                ans1 = lblDisplay.Text;
            }
            else if (plus == true || minus == true || multiply == true || divide == true || percent == true && lblDisplay.Text.Length < 8)
            {
                if (b == 0) {
                    lblDisplay.Text = "";
                    b++;
                }                
                lblDisplay.Text += btn.Text;
                ans2 = lblDisplay.Text;
            }
        }

        private void btnAA_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = ans1;
            if (plus == true)
            {
                ans = float.Parse(ans1) + float.Parse(ans2);
                ans1 = ans.ToString();
                lblDisplay.Text = ans1;
                ans = 0;
                ans2 = "0";
            }
            else if (minus == true)
            {
                ans = float.Parse(ans1) - float.Parse(ans2);
                ans1 = ans.ToString();
                lblDisplay.Text = ans1;
                ans = 0;
                ans2 = "0";
            }
            else if (multiply == true)
            {
                ans = float.Parse(ans1) * float.Parse(ans2);
                ans1 = ans.ToString();
                lblDisplay.Text = ans1;
                ans = 0;
                ans2 = "0";
            }
            else if (divide == true)
            {
                ans = float.Parse(ans1) / float.Parse(ans2);
                ans1 = ans.ToString();
                lblDisplay.Text = ans1;
                ans = 0;
                ans2 = "0";
            }
            else if (percent == true)
            {
                if (ans2 == "" || ans2 == null)
                {
                    ans = float.Parse(ans1) / 100;
                    ans1 = ans.ToString();
                    lblDisplay.Text = ans1;
                    ans = 0;
                    ans2 = "0";
                }
                else if (ans2 != "" || ans2 != null)
                {
                    ans = (float.Parse(ans1) / 100) * float.Parse(ans2);
                    ans1 = ans.ToString();
                    lblDisplay.Text = ans1;
                    ans = 0;
                    ans2 = "0";
                }
            }            
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            if(a >= 1)
            {            
            btnAA_Click(sender, e);
            }

            if (minus == true || multiply == true || divide == true || percent == true)
            {
                minus = false;
                multiply = false;
                divide = false;
                percent = false;
            }
            plus = true;
            a++;
            b = 0;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (a >= 1)
            {
            btnAA_Click(sender, e);
            }

            if (plus == true || multiply == true || divide == true || percent == true)
            {
                plus = false;
                multiply = false;
                divide = false;
                percent = false;
            }
            minus = true;
            a++;
            b = 0;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (a >= 1)
            {
            btnAA_Click(sender, e);
            }

            if (minus == true || plus == true || divide == true || percent == true)
            {
                minus = false;
                plus = false;
                divide = false;
                percent = false;
            }
            multiply = true;
            a++;
            b = 0;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (a >= 1)
            {
            btnAA_Click(sender, e);
            }

            if (minus == true || multiply == true || plus == true || percent == true)
            {
                minus = false;
                multiply = false;
                plus = false;
                percent = false;
            }
            divide = true;
            a++;
            b = 0;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (a >= 1)
            {
            btnAA_Click(sender, e);
            }

            if (plus == true || minus == true || multiply == true || divide == true)
            {
                plus = false;
                minus = false;
                multiply = false;
                divide = false;
            }
            percent = true;
            a++;
            b = 0;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            btnAA_Click(sender, e);
            plus = false;
            minus = false;
            multiply = false;
            divide = false;
            percent = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 1)
            {
                lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
            }
            else if (lblDisplay.Text.Length == 1)
            {
                lblDisplay.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ans1 = "";
            ans2 = "";
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

