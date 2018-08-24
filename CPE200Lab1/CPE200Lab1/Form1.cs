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
        string first_data, second_data, Symbol, percent_num, sum;
        bool flag_dot=true;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if(flag_dot == true)
            {
                lblDisplay.Text += ".";
                flag_dot = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Substring(0,lblDisplay.Text.Length - 1);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {

                lblDisplay.Text = (-1 * float.Parse(lblDisplay.Text)).ToString();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {

            percent_num = (float.Parse(first_data) * float.Parse(lblDisplay.Text) / 100).ToString();
            lblDisplay.Text = percent_num;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            second_data = lblDisplay.Text;
            if (first_data != null && second_data != null)
            {
                lblDisplay.Text = "";
                if (Symbol == "+")
                {
                    sum = (float.Parse(first_data) + float.Parse(second_data)).ToString();

                }
                else if (Symbol == "-")
                {
                    sum = (float.Parse(first_data) - float.Parse(second_data)).ToString();
                }
                else if (Symbol == "X")
                {
                    sum = (float.Parse(first_data) * float.Parse(second_data)).ToString();
                }
                else if (Symbol == "÷")
                {
                    sum = (float.Parse(first_data) / float.Parse(second_data)).ToString();
                }
                lblDisplay.Text = sum;
            }

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Symbol = btn.Text;
            first_data = lblDisplay.Text;
            lblDisplay.Text = "";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            first_data = "";
            second_data = "";
            sum = "";
            flag_dot = true;
        }
    }
}
