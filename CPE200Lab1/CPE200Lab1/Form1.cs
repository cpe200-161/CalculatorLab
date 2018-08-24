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
        float num1 = 999999999 , num2 = 999999999, sum = 0 , check = 0 , mark = 0 ,point = 0;
        bool checkpoint = false;
        bool checksum = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnX_Click(object sender, EventArgs e)
        {            
            Button btn = (Button)sender;
            if (check == 0)
            {
                if (btn.Text == ".")
                {
                    if (point == 0)
                    {
                        lblDisplay.Text = lblDisplay.Text + btn.Text;
                        point = 1;
                    }
                }
                else
                {
                    if (lblDisplay.Text == "0")
                    {
                        lblDisplay.Text = "";
                    }
                    if (lblDisplay.Text.Length < 8)
                    {
                        lblDisplay.Text = lblDisplay.Text + btn.Text;

                    }
                }
            }
            else
            {
                if(btn.Text ==".")
                {
                    lblDisplay.Text = "0" + btn.Text;
                }
                else
                {
                    lblDisplay.Text = btn.Text;
                }
                check = 0;
            }
            checkpoint = false;
            checksum = false;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            num1 = 999999999;
            num2 = 999999999;
            check = 0;
            mark = 0;
            point = 0;
            checkpoint = false;
        }
        private void btnY_Click(object sender, EventArgs e)
        {
            if (checkpoint == false)
            {
                checkpoint = true;
                Button btn = (Button)sender;
                if (num1 == 999999999)
                {
                    num1 = float.Parse(lblDisplay.Text);
                }
                else
                {
                    if (btn.Text == "%" && mark != 3 && mark != 4)
                    {
                        num2 = (num1 / 100) * float.Parse(lblDisplay.Text);
                    }
                    else if (btn.Text == "%" && mark == 3 || mark == 4)
                    {
                        num2 = float.Parse(lblDisplay.Text) / 100;
                    }
                    else
                    {
                        num2 = float.Parse(lblDisplay.Text);
                    }
                }
                if (num1 != 999999999 && num2 != 999999999 && btn.Text != "%")
                {
                    if (mark == 1)
                    {
                        num1 = num1 + num2;
                    }
                    else if (mark == 2)
                    {
                        num1 = num1 - num2;
                    }
                    else if (mark == 3)
                    {
                        num1 = num1 * num2;
                    }
                    else if (mark == 4)
                    {
                        num1 = num1 / num2;
                    }
                }
                if (btn.Text == "+")
                {
                    mark = 1;
                    lblDisplay.Text = Convert.ToString(num1);
                    check = 1;
                    point = 0;
                }
                else if (btn.Text == "-")
                {
                    mark = 2;
                    lblDisplay.Text = Convert.ToString(num1);
                    check = 1;
                    point = 0;
                }
                else if (btn.Text == "X")
                {
                    mark = 3;
                    lblDisplay.Text = Convert.ToString(num1);
                    check = 1;
                    point = 0;
                }
                else if (btn.Text == "÷")
                {
                    mark = 4;
                    lblDisplay.Text = Convert.ToString(num1);
                    check = 1;
                    point = 0;
                }
                else if (btn.Text == "%")
                {
                    lblDisplay.Text = Convert.ToString(num2);
                    check = 1;
                    point = 0;
                }
            }
        }
        private void btnZ_Click(object sender, EventArgs e)
        {
            if (checksum == false)
            {
                if (mark == 1)
                {
                    lblDisplay.Text = Convert.ToString(num1 + float.Parse(lblDisplay.Text));
                    sum = num1;
                    num1 = float.Parse(lblDisplay.Text);
                }
                if (mark == 2)
                {
                    lblDisplay.Text = Convert.ToString(num1 - float.Parse(lblDisplay.Text));
                    sum = num1;
                    num1 = float.Parse(lblDisplay.Text);
                }
                if (mark == 3)
                {
                    lblDisplay.Text = Convert.ToString(num1 * float.Parse(lblDisplay.Text));
                    sum = num1;
                    num1 = float.Parse(lblDisplay.Text);
                }
                if (mark == 4)
                {
                    lblDisplay.Text = Convert.ToString(num1 / float.Parse(lblDisplay.Text));
                    sum = num1;
                    num1 = float.Parse(lblDisplay.Text);
                }
                checksum = true;
            }
            else
            {
                if (mark == 1)
                {
                    lblDisplay.Text = Convert.ToString(sum + float.Parse(lblDisplay.Text));
                    num1 = float.Parse(lblDisplay.Text);
                }
                if (mark == 2)
                {
                    lblDisplay.Text = Convert.ToString(sum - float.Parse(lblDisplay.Text));
                    num1 = float.Parse(lblDisplay.Text);
                }
                if (mark == 3)
                {
                    lblDisplay.Text = Convert.ToString(sum * float.Parse(lblDisplay.Text));
                    num1 = float.Parse(lblDisplay.Text);
                }
                if (mark == 4)
                {
                    lblDisplay.Text = Convert.ToString(sum / float.Parse(lblDisplay.Text));
                    num1 = float.Parse(lblDisplay.Text);
                }
            }
        }
    }
}
