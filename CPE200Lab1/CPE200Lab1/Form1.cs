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
        string firstoperand = "";
        string secondoperand = "";
        bool setfirstop = false;
        bool set = false;
        bool plus;
        bool minus;
        bool multi;
        bool divide;
        bool per;
        string sum;


        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
   

        }
        private void bthX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (firstoperand != "") set = true;
            if (setfirstop == true)
            {
                lblDisplay.Text = "";
                setfirstop = false;

            }

            if (lblDisplay.Text.Length < 8)
            {

                if (lblDisplay.Text == "0")
                {
                    lblDisplay.Text = "";
                }

                lblDisplay.Text = lblDisplay.Text + btn.Text;


            }
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {


            if (set == true)
            {
                secondoperand = lblDisplay.Text;
                if (per == true)
                {
                    secondoperand = ((float.Parse(secondoperand) / 100) * (float.Parse(firstoperand))).ToString();
                    per = false;
                }
                firstoperand = (float.Parse(firstoperand) + float.Parse(secondoperand)).ToString();
                lblDisplay.Text = firstoperand;
                set = false;

            }
            if (set == false)
            {
                firstoperand = lblDisplay.Text;
                setfirstop = true;
            }

            plus = true;

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (set == true)
            {

                secondoperand = lblDisplay.Text;
                if (per == true)
                {
                    secondoperand = ((float.Parse(secondoperand) / 100) * (float.Parse(firstoperand))).ToString();
                    per = false;
                }
                firstoperand = (float.Parse(firstoperand) - float.Parse(secondoperand)).ToString();
                lblDisplay.Text = firstoperand;
                set = false;

            }
            if (set == false)
            {
                firstoperand = lblDisplay.Text;
                setfirstop = true;
            }
            minus = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {

            if (set == true)
            {

                secondoperand = lblDisplay.Text;
                if (per == true)
                {
                    secondoperand = ((float.Parse(secondoperand) / 100) * (float.Parse(firstoperand))).ToString();
                    per = false;
                }
                firstoperand = (float.Parse(firstoperand) * float.Parse(secondoperand)).ToString();
                lblDisplay.Text = firstoperand;
                set = false;

            }
            if (set == false)
            {
                firstoperand = lblDisplay.Text;
                setfirstop = true;
            }
            multi = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (set == true)
            {

                secondoperand = lblDisplay.Text;
                if (per == true)
                {
                    secondoperand = ((float.Parse(secondoperand) / 100) * (float.Parse(firstoperand))).ToString();
                    per = false;
                }
                firstoperand = (float.Parse(firstoperand) / float.Parse(secondoperand)).ToString();
                lblDisplay.Text = firstoperand;
                set = false;

            }
            if (set == false)
            {
                firstoperand = lblDisplay.Text;
                setfirstop = true;
            }
            divide = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (firstoperand == "") lblDisplay.Text = "0";
            else
            {
                per = true;
            }

        }
        private void btnEqual_Click(object sender, EventArgs e)
        {

            secondoperand = lblDisplay.Text;
            if (per == true)
            {
                secondoperand = ((float.Parse(secondoperand) / 100) * (float.Parse(firstoperand))).ToString();
                per = false;
                set = false;
            }
            if (plus == true)
            {

                sum = (float.Parse(firstoperand) + float.Parse(secondoperand)).ToString();
                plus = false;
                set = false;

            }
            else if (minus == true)
            {
                sum = (float.Parse(firstoperand) - float.Parse(secondoperand)).ToString();
                minus = false;
                set = false;
            }
            else if (multi == true)
            {
                sum = (float.Parse(firstoperand) * float.Parse(secondoperand)).ToString();
                multi = false;
                set = false;
            }
            else if (divide == true)
            {
                sum = (float.Parse(firstoperand) / float.Parse(secondoperand)).ToString();
                divide = false;
                set = false;
            }




            lblDisplay.Text = sum;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 1)
            {
                string display = lblDisplay.Text;
                string sub = display.Substring(0, display.Length - 1);
                lblDisplay.Text = sub;
            }
            else if (lblDisplay.Text.Length == 1)
            {
                firstoperand = "";
                secondoperand = "";
                setfirstop = false;
                set = false;
                lblDisplay.Text = "0";

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            firstoperand = "";
            secondoperand = "";
            setfirstop = false;
            set = false;
            lblDisplay.Text = "0";
        }
    }
}
