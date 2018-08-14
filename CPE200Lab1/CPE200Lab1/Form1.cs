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
        float temp = 0;
        float num1, num2;
        string display = "0";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text += btnDot.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = " ";
        }

        private void btnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (display == "0")
            {
                lblDisplay.Text = " ";
            }
            lblDisplay.Text += btn.Text;
            display = lblDisplay.Text;

        }
    }
}
