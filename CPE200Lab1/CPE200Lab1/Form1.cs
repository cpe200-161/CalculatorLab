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
        string number_collector = null;
        float value = 0, value_2 = 0;
        bool dotbtn = false, plusbtn = false, minusbtn = false, multiplybtn = false, devidebtn = false, percentbtn = false, operated = false;

        public Form1()
        {
            InitializeComponent();

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text != "0")
            {
                number_collector = (float.Parse(number_collector) * -1).ToString();
                lblDisplay.Text = number_collector.ToString();
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (dotbtn == false)
            {
                number_collector += ".";
                lblDisplay.Text = number_collector;
                dotbtn = true;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (plusbtn == true)
            {
                if (value != 0)
                {
                    value_2 = float.Parse(number_collector);
                    number_collector = "";
                    value = value_2 + value;
                    value_2 = 0;
                    number_collector = value.ToString();
                    lblDisplay.Text = number_collector;
                    operated = true;
                    plusbtn = false;
                }
            }

            if (minusbtn == true)
            {
                if (value != 0)
                {
                    value_2 = float.Parse(number_collector);
                    number_collector = "";
                    value = value - value_2;
                    value_2 = 0;
                    number_collector = value.ToString();
                    lblDisplay.Text = number_collector;
                    operated = true;
                    minusbtn = false;
                }
            }

            if (multiplybtn == true)
            {
                if (value != 0)
                {
                    value_2 = float.Parse(number_collector);
                    number_collector = "";
                    value = value * value_2;
                    value_2 = 0;
                    number_collector = value.ToString();
                    lblDisplay.Text = number_collector;
                    operated = true;
                    multiplybtn = false;
                }
            }

            if (devidebtn == true)
            {
                if (value != 0)
                {
                    value_2 = float.Parse(number_collector);
                    number_collector = "";
                    value = value / value_2;
                    value_2 = 0;
                    number_collector = value.ToString();
                    lblDisplay.Text = number_collector;
                    operated = true;
                    devidebtn = false;
                }
            }

            if (percentbtn == true)
            {
                if (value != 0)
                {
                    value_2 = float.Parse(number_collector);
                    if (value_2 == 0)
                        number_collector = "";
                    value = (value * value_2);
                    number_collector = value.ToString();
                    lblDisplay.Text = number_collector;
                    operated = true;
                    percentbtn = false;
                }
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (value == 0)
            {
                value = float.Parse(number_collector);
                number_collector = "";
                plusbtn = true;
            }
            else
            {
                value += float.Parse(lblDisplay.Text) ;
                lblDisplay.Text = "";
                lblDisplay.Text = value.ToString();
            }
            dotbtn = false;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            value = float.Parse(number_collector);
            number_collector = "";
            dotbtn = false;
            minusbtn = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            number_collector = "";
            lblDisplay.Text = "0";
            value = 0; value_2 = 0;
            plusbtn = false; minusbtn = false; multiplybtn = false; devidebtn = false;

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            value = float.Parse(number_collector);
            number_collector = "";
            dotbtn = false;
            multiplybtn = true;
        }

        private void Btn_S(object sender, EventArgs e)
        {

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            value = float.Parse(number_collector);
            number_collector = "";
            dotbtn = false;
            devidebtn = true;
        }



        private void btnX_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                number_collector = "";
            }

            if (operated == true)
            {
                number_collector = "";
                operated = false;
            }

            if (lblDisplay.Text.Length < 8)
            {
                number_collector += btn.Text;
                lblDisplay.Text = number_collector;
            }
        }


        private void btnPercent_Click(object sender, EventArgs e)
        {
            {
                value = float.Parse(number_collector);
                value = value / 100;
                lblDisplay.Text = value.ToString();
                number_collector = "";
                percentbtn = true;
                dotbtn = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (float.Parse(number_collector) >= 0)
            {
                number_collector = number_collector.Remove(number_collector.Length-1,1);
                lblDisplay.Text = number_collector.ToString();
            }
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}
