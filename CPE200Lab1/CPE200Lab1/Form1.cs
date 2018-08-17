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
        float first;
        float second;
        float result;
        bool recheck = true;
        int pluscheck=0;
        string show;
        

        public Form1()
        {
            InitializeComponent();
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (pluscheck == 1 || pluscheck == 2)
            {
                if (recheck)
                {
                    lblDisplay.Text = "";
                }
                recheck=false;
            }
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            pluscheck = 0;
            first = 0;
            second = 0;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            pluscheck = pluscheck + 1;
            
            if (pluscheck == 1)
            {
                first = float.Parse(lblDisplay.Text);
                lblDisplay.Text = "";
                lblDisplay.Text = first.ToString();
            }
            else if (pluscheck == 2)
            {
                second = float.Parse(lblDisplay.Text);
                result = first + second;
                show = result.ToString();
                lblDisplay.Text = show;
                first = result;
                pluscheck = 1;
                recheck = true;
            }

            
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {


        }
    }
}
