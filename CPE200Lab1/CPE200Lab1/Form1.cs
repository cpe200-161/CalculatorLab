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
        string SecondOperand = null;
        private string firstOperand = null;
        bool setFirstOperand = false;
        bool isStartSecondOperand = false;
        private int Ocheck = 0;
        string result;
        bool Minus = false;
        bool Dot = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (setFirstOperand == true && isStartSecondOperand == false)
            {
                lblDisplay.Text = "";
                isStartSecondOperand = true;
            }
            if (lblDisplay.Text.Length < 8)
            {
                if (btn.TabIndex == 14)//DOT
                {
                    if (Dot == false)
                    {
                        if (lblDisplay.Text == "")
                        {
                            lblDisplay.Text += "0.";
                        }
                        else
                        {
                            lblDisplay.Text += ".";
                        }
                        Dot = true;
                    }

                }
                else
                {
                    lblDisplay.Text += btn.Text;
                }
            }
        }
        private void btnClick()
        {
            firstOperand = lblDisplay.Text;
            setFirstOperand = true;
        }
        private void btnO_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btnClick();
            if (btn.TabIndex == 11) //plus
            {
                Ocheck = 1;
            }
            else if (btn.TabIndex == 7)//minus
            {
                Ocheck = 2;
            }
            else if (btn.TabIndex == 3)//multiply
            {
                Ocheck = 3;
            }
            else if (btn.TabIndex == 16)//divide
            {
                Ocheck = 4;
            }
            Dot = false;
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (Ocheck == 0 || Ocheck == 3 || Ocheck == 4)
            {
                lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100).ToString();
            }
            else if (Ocheck == 1 || Ocheck == 2 && setFirstOperand)
            {
                lblDisplay.Text = (float.Parse(firstOperand) * float.Parse(lblDisplay.Text) * 0.01).ToString();
            }
        }
        private void Clear()
        {
            firstOperand = "";
            SecondOperand = "";
            lblDisplay.Text = "0";
            setFirstOperand = false;
            isStartSecondOperand = false;
            Dot = false;
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            if (lblDisplay.Text.Length == 0)
            {
                lblDisplay.Text = "0";
                Clear();
            }

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (Minus)
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1);
                Minus = false;
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text.Insert(0, "-");
                Minus = true;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            SecondOperand = lblDisplay.Text;

            if (Ocheck == 1)
            {
                result = (float.Parse(firstOperand) + float.Parse(SecondOperand)).ToString();
            }
            else if (Ocheck == 2)
            {
                result = (float.Parse(firstOperand) - float.Parse(SecondOperand)).ToString();
            }
            else if (Ocheck == 3)
            {
                result = (float.Parse(firstOperand) * float.Parse(SecondOperand)).ToString();
            }
            else if (Ocheck == 4)
            {
                result = (float.Parse(firstOperand) / float.Parse(SecondOperand)).ToString();
            }
            else
            {

            }
            if (float.Parse(result) < 0)
            {
                Minus = true;
            }
            lblDisplay.Text = result;
            Ocheck = 0;
            isStartSecondOperand = false;
        }
    }
}

