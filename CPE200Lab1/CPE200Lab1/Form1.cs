using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        float x,y,ans=0;
        int oper=0;

        private void btnN_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || lblDisplay.Text == string.Format("{0:0}", x) || lblDisplay.Text == string.Format("{0:0}", ans))
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8 )
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            x = float.Parse(lblDisplay.Text);
            lblDisplay.Text = string.Format("{0:0}", x);
            oper = 1;

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            x = float.Parse(lblDisplay.Text);
            lblDisplay.Text = string.Format("{0:0}", x);
            oper = 4;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            x = float.Parse(lblDisplay.Text);
            lblDisplay.Text = string.Format("{0:0}", x);
            oper = 2;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            x = float.Parse(lblDisplay.Text);
            lblDisplay.Text = string.Format("{0:0}", x);
            oper = 3;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            y = float.Parse(lblDisplay.Text);
            y = x * (y / 100);
            lblDisplay.Text = string.Format("{0:0}", y);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            y = float.Parse(lblDisplay.Text);
            ans = 0;
            lblDisplay.Text = string.Format("{0:0}", y);
            
            if (oper == 1) ans = x + y;
            else if (oper == 2) ans = x - y;
            else if (oper == 3) ans = x * y;
            else if (oper == 4) ans = x / y;
            

            lblDisplay.Text = string.Format("{0:0}",ans);
        }
    }
}
