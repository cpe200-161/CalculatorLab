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
        string anS1;
        string anS2;
        float anS;
        bool plusCess = false;
        bool minusCess = false;
        bool multiplyCess = false;
        bool divideCess = false;
        bool percentCess = false;
        int rE = 0;

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

            if (plusCess == false && minusCess == false && multiplyCess == false && divideCess == false && percentCess == false && lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
                anS1 = lblDisplay.Text;
            }
            else if (plusCess == true || minusCess == true || multiplyCess == true || divideCess == true || percentCess == true && lblDisplay.Text.Length < 8)
            {
                if (rE == 0)
                {
                    lblDisplay.Text = "";
                    rE++;
                }
                lblDisplay.Text += btn.Text;
                anS2 = lblDisplay.Text;
            }
        }

        private void btnProcess()
        {
            lblDisplay.Text = anS1;

            if (plusCess == true)
            {
                anS = float.Parse(anS1) + float.Parse(anS2);
                anS1 = anS.ToString();
                lblDisplay.Text = anS1;
                minusCess = false;
                multiplyCess = false;
                divideCess = false;
            }

            if (minusCess == true)
            {
                anS = float.Parse(anS1) - float.Parse(anS2);
                anS1 = anS.ToString();
                lblDisplay.Text = anS1;
                multiplyCess = false;
                divideCess = false;
                plusCess = false;
            }

            if (multiplyCess == true)
            {
                anS = float.Parse(anS1) * float.Parse(anS2);
                anS1 = anS.ToString();
                lblDisplay.Text = anS1;
                minusCess = false;
                divideCess = false;
                plusCess = false;
            }

            if (divideCess == true)
            {
                anS = float.Parse(anS1) / float.Parse(anS2);
                anS1 = anS.ToString();
                lblDisplay.Text = anS1;
                minusCess = false;
                multiplyCess = false;
                plusCess = false;
            }
            rE = 0;
            anS = 0;
            anS2 = "0";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            plusCess = true;

            if (percentCess == false || minusCess == true || multiplyCess == true || divideCess == true)
            {
                minusCess = false;
                multiplyCess = false;
                divideCess = false;
            }
            if (anS2 != null && anS2 != "" && rE != 0)
            {
                btnProcess();
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            minusCess = true;
            if (percentCess == false || divideCess == true || multiplyCess == true || plusCess == true)
            {
                multiplyCess = false;
                divideCess = false;
                plusCess = false;
            }
            if (anS2 != null && anS2 != "" && rE != 0)
            {
                btnProcess();
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            multiplyCess = true;
            if (percentCess == false || minusCess == true || divideCess == true || plusCess == true)
            {
                minusCess = false;
                divideCess = false;
                plusCess = false;
            }
            if (anS2 != null && anS2 != "" && rE != 0)
            {
                btnProcess();
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            divideCess = true;
            if (percentCess == false || minusCess == true || multiplyCess == true || plusCess == true)
            {
                minusCess = false;
                multiplyCess = false;
                plusCess = false;
            }
            if (anS2 != null && anS2 != "" && rE != 0)
            {
                btnProcess();
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            percentCess = true;

            percentProcess();

        }

        private void percentProcess()
        {
            if (anS2 == null || anS2 == "")
            {
                anS = float.Parse(anS1) / 100;
                anS1 = anS.ToString();
                lblDisplay.Text = anS1;
                anS = 0;
                minusCess = false;
                multiplyCess = false;
                percentCess = false;
                plusCess = false;
                divideCess = false;
            }

            if (anS2 != null && anS2 != "")
            {
                anS = (float.Parse(anS2) / 100) * float.Parse(anS1);
                anS2 = anS.ToString();
                anS = 0;
                btnProcess();
                percentCess = false;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            btnProcess();
            rE = 0;
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
            anS1 = "";
            anS2 = "";
            plusCess = false;
            minusCess = false;
            multiplyCess = false;
            divideCess = false;
            percentCess = false;
            lblDisplay.Text = "0";
            rE = 0;
        }
    }
}

