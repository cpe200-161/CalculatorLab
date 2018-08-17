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
        string a = null;
        string b = null;
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
            if(stage == 1)
            {
                lblDisplay.Text = "";
                stage = 2;
            }
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                a = lblDisplay.Text;
                operation = 1;
                stage = 1;
            }
            if (stage == 2)
            {
                b = lblDisplay.Text;
                a = Convert.ToString(Convert.ToSingle(a) + Convert.ToSingle(b));
                lblDisplay.Text = a;
                stage = 1;
            }
        }
        
        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                a = lblDisplay.Text;
                operation = 2;
                stage = 1;
            }
            if (stage == 2)
            {
                b = lblDisplay.Text;
                a = Convert.ToString(Convert.ToSingle(a) - Convert.ToSingle(b));
                lblDisplay.Text = a;
                stage = 1;
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                a = lblDisplay.Text;
                operation = 3;
                stage = 1;
            }
            if (stage == 2)
            {
                b = lblDisplay.Text;
                a = Convert.ToString(Convert.ToSingle(a) * Convert.ToSingle(b));
                lblDisplay.Text = a;
                stage = 1;
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (stage == 0)
            {
                a = lblDisplay.Text;
                operation = 4;
                stage = 1;
            }
            if (stage == 2)
            {
                b = lblDisplay.Text;
                a = Convert.ToString(Convert.ToSingle(a) / Convert.ToSingle(b));
                lblDisplay.Text = a;
                stage = 1;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (operation == 1)
            {
                b = lblDisplay.Text;
                a = Convert.ToString(Convert.ToSingle(a) + Convert.ToSingle(b));
                lblDisplay.Text = a;
                stage = 1;
            }

            if (operation == 2)
            {
                b = lblDisplay.Text;
                a = Convert.ToString(Convert.ToSingle(a) - Convert.ToSingle(b));
                lblDisplay.Text = a;
                stage = 1;
            }

            if (operation == 3)
            {
                b = lblDisplay.Text;
                a = Convert.ToString(Convert.ToSingle(a) * Convert.ToSingle(b));
                lblDisplay.Text = a;
                stage = 1;
            }

            if (operation == 4)
            {
                b = lblDisplay.Text;
                a = Convert.ToString(Convert.ToSingle(a) / Convert.ToSingle(b));
                lblDisplay.Text = a;
                stage = 1;
            }
        }
    }
}
