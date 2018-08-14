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
        string firstoperand = null;
        string secondoperand = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            
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
                lblDisplay.Text += btn.Text;
       
            }
           
        }





        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text = lblDisplay.Text + ".";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstoperand = lblDisplay.Text;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result;
        }
    }
}
