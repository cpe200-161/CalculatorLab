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
        float Num_first = 0;
        float Num_second = 0;
        float result = 0;
        int DOT = 0;
        int SOL = 0;
        int CLICK_ON = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public void Calculate()
        {
            lblDisplay.Text = string.Format("{0:G}", Num_second);
            switch (SOL)
            {
                case 0:
                    lblDisplay.Text = string.Format("{0:G}", Num_second);
                    break;
                case 1:
                    Num_second = Num_first + Num_second;
                    lblDisplay.Text = string.Format("{0:G}", Num_second);
                    break;
                case 2:
                    Num_second = Num_first - Num_second;
                    lblDisplay.Text = string.Format("{0:G}", Num_second);
                    break;
                case 3:
                    Num_second = Num_first * Num_second;
                    lblDisplay.Text = string.Format("{0:G}", Num_second);
                    break;
                case 4:
                    Num_second = Num_first / Num_second;
                    lblDisplay.Text = string.Format("{0:G}", Num_second);
                    break;
                case 5:
                    lblDisplay.Text = string.Format("{0:G}", Num_second);
                    break;
                
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length < 8)
            {
                if(CLICK_ON == 1)
                {
                    lblDisplay.Text = "";
                    CLICK_ON = 0;
                }
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CLICK_ON = 0;
            Num_first = 0;
            Num_second = 0;
            SOL = 0;
            DOT = 0;
            lblDisplay.Text = "0";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if(CLICK_ON == 1)
            {
                SOL = 1;
            }
            else
            {
                Num_first = Num_second;
                Num_second = float.Parse(lblDisplay.Text);
                Calculate();
                SOL = 1;
            }
            CLICK_ON = 1;
            DOT = 0;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (CLICK_ON == 1)
            {
                SOL = 2;
            }
            else
            {
                Num_first = Num_second;
                Num_second = float.Parse(lblDisplay.Text);
                Calculate();
                SOL = 2;
            }
            CLICK_ON = 1;
            DOT = 0;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (CLICK_ON == 1)
            {
                SOL = 3;
            }
            else
            {
                Num_first = Num_second;
                Num_second = float.Parse(lblDisplay.Text);
                Calculate();
                SOL = 3;
            }
            CLICK_ON = 1;
            DOT = 0;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (CLICK_ON == 1)
            {
                SOL = 4;
            }
            else
            {
                Num_first = Num_second;
                Num_second = float.Parse(lblDisplay.Text);
                Calculate();
                SOL = 4;
            }
            CLICK_ON = 1;
            DOT = 0;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (CLICK_ON == 1)
            {
                SOL = 5;
            }
            else
            {
                Num_first = Num_second;
                Num_second = float.Parse(lblDisplay.Text);
                Num_second = Num_first * (Num_second / 100);
                Calculate();
                SOL = 5;
            }
            CLICK_ON = 1;
            DOT = 0;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Num_first = Num_second;
            Num_second = float.Parse(lblDisplay.Text);
            Calculate();
            SOL = 0;
            Num_first = 0;
            Num_second = 0;
            DOT = 0;
            CLICK_ON = 0;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = string.Format("{0:G}", float.Parse(lblDisplay.Text) * (-1));
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (DOT == 0)
            {
                if (lblDisplay.Text.Length < 8)
                {
                    if (CLICK_ON == 1)
                    {
                        lblDisplay.Text = "0";
                        CLICK_ON = 0;
                    }
                    lblDisplay.Text = lblDisplay.Text + ".";
                }
            }
            DOT = 1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
            if(lblDisplay.Text == "")
            {
                lblDisplay.Text = "0";
            }
        }
    }
}
