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
        private int val = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void display()
        {
            lblDisplay.Text = val.ToString();
        }
        private void numClick(int n)
        {
            val = val * 10 + n;
            lblDisplay.Text = val.ToString;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            numClick(4);

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            numClick(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            numClick(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            numClick(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            numClick(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            numClick(9);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            numClick(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            numClick(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            numClick(3);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            numClick(0);
        }
    }
 }

