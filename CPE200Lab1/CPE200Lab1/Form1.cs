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
        double frist;
        double second;
        int third;
        double sum;
        double count;
        string forth;
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
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            third  = 1;
            forth = "a";
            frist = Convert.ToDouble(lblDisplay.Text);
            if (frist > 0)
            {
                lblDisplay.Text = "";
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            second = Convert.ToDouble(lblDisplay.Text);
            switch (third)
            {
                case 1: sum = frist + second; break;
                case 2: sum = frist - second; break;
                case 3: sum = frist * second; break;
                case 4: sum = frist / second; break;
                default: break;
            }
            lblDisplay.Text = Convert.ToString(sum);

        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            third = 2;
            frist = Convert.ToDouble(lblDisplay.Text);
            if (frist > 0)
            {
                lblDisplay.Text = "";
            }
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            third = 3;
            frist = Convert.ToDouble(lblDisplay.Text);
            if (frist > 0)
            {
                lblDisplay.Text = "";
            }
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            third = 4;
            frist = Convert.ToDouble(lblDisplay.Text);
            if (frist > 0)
            {
                lblDisplay.Text = "";
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            second = Convert.ToDouble(lblDisplay.Text);
            count = second / 100;
            switch (forth)
            {
                case "a": sum = frist + count;
                case "b": sum = frist - count;
                case "c": sum = frist * count;
                case "d": sum = frist / count;
                default break;
            }
            lblDisplay.Text = Convert.ToString(count);
        }
    }
}
