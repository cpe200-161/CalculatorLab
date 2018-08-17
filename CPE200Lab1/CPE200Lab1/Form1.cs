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
        private double firstnum = 0;
        private double secnum = 0;
        private double result = 0;
        private string sum = null;

        public Form1()
        {
            InitializeComponent();
        }

       
        private void btnx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
           if(lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstnum = double.Parse(lblDisplay.Text);
            lblDisplay.Text = "0";

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            secnum = double.Parse(lblDisplay.Text);
            result = firstnum + secnum;
           
            lblDisplay.Text = sum;
        }
    }
}
