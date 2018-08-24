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
        int stage = 0;
        int operation = 0;
        int dotTime = 0;
        string num1 = null;
        string num2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        void calculating()
        {
            if (operation == 1)
            {
                num1 = Convert.ToString(Convert.ToSingle(num1) + Convert.ToSingle(num2));
            }
            if (operation == 2)
            {
                num1 = Convert.ToString(Convert.ToSingle(num1) - Convert.ToSingle(num2));
            }
            if (operation == 3)
            {
                num1 = Convert.ToString(Convert.ToSingle(num1) * Convert.ToSingle(num2));
            }
            if (operation == 4)
            {
                num1 = Convert.ToString(Convert.ToSingle(num1) / Convert.ToSingle(num2));
            }
            lblDisplay.Text = num1;
            stage = 1;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            while (true)
            {
                Button btn = (Button)sender;
                if (stage == 3)
                {
                    lblDisplay.Text = "0";
                    stage = 0;
                }
                if (stage == 1)
                {
                    lblDisplay.Text = "0";
                    stage = 2;
                }
                if (lblDisplay.Text == "0")
                {
                    if (dotTime == 0 && btn.Text == ".")
                    {
                        lblDisplay.Text = lblDisplay.Text + btn.Text;
                        dotTime = 1;
                        break;
                    }
                    lblDisplay.Text = "";
                }
                if (dotTime == 0 && btn.Text == ".")
                {
                    if (dotTime == 0)
                    {
                        if (lblDisplay.Text.Length < 8)
                        {
                            lblDisplay.Text = lblDisplay.Text + btn.Text;
                        }
                    }
                    dotTime = 1;
                }
                else
                {
                    if (btn.Text != ".")
                    {
                        if (lblDisplay.Text.Length < 8)
                        {
                            lblDisplay.Text = lblDisplay.Text + btn.Text;
                        }
                    }
                }
                num2 = lblDisplay.Text;
                break;
            }

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                num1 = lblDisplay.Text;
                operation = 1;
                stage = 1;
                dotTime = 0;
            }
            if (stage == 2)
            {
                calculating();
                operation = 1;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                num1 = lblDisplay.Text;
                operation = 2;
                stage = 1;
                dotTime = 0;
            }
            if (stage == 2)
            {
                calculating();
                operation = 2;
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                num1 = lblDisplay.Text;
                operation = 3;
                stage = 1;
                dotTime = 0;
            }
            if (stage == 2)
            {
                calculating();
                operation = 3;
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                num1 = lblDisplay.Text;
                operation = 4;
                stage = 1;
                dotTime = 0;
            }
            if (stage == 2)
            {
                calculating();
                operation = 4;
            }
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                lblDisplay.Text = Convert.ToString((float.Parse(lblDisplay.Text) / 100));
            }
            if (stage == 2)
            {
                if (operation == 1 || operation == 2)
                {
                    num2 = Convert.ToString(Convert.ToSingle(num1) * Convert.ToSingle(num2) / 100);
                }
                if (operation == 3 || operation == 4)
                {
                    num2 = Convert.ToString(Convert.ToSingle(num2) / 100);
                }
                lblDisplay.Text = num2;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            calculating();
            stage = 3;
            operation = 0;
            dotTime = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            num1 = null;
            num2 = null;
            lblDisplay.Text = "0";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length == 1)
            {
                lblDisplay.Text = "0";
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
            }
        }
    }
}
