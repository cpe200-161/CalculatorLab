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
        public Form1()
        {
            InitializeComponent();
        }

        //add Eq
        float eq1, eq2, resultshow, resultstore;
        Boolean Dotflage = true;

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (Convert.ToInt32(lblDisplay.Text)/ 10).ToString();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lblDisplay.Text = (-1 * float.Parse(lblDisplay.Text)).ToString();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            //this %
        }

        private void btnoperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn=="+")
            {

            }else if (btn=="-")
            {

            }else if (btn== "X")
            {

            }else if (btn == "÷")
            {

            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            //this =
        }

        private void bntDot_Click(object sender,EventArgs e)
        {
            Button btn = (Button)sender;
            if (Dotflage)
            {
                lblDisplay.Text += btn.Text;
                Dotflage = false;
            }
        }

        private void btnnum_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            eq1 = eq2 = resultshow = resultstore = 0;
            Dotflage = true;
        }
    }
}
