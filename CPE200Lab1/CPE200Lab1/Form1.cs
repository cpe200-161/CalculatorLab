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
        string NUM1;
        string NUM2;
        string result;
        int Operators = 0;
        bool SecondStart =false;
        bool firstStart = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            NUM1 = "";
            NUM2 = "";
            firstStart = false;
            SecondStart = false;
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (firstStart && SecondStart == false)
            {
                lblDisplay.Text = "";
                SecondStart = true;
            }
            
            if(lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text += btn.Text ;
            }
        }

        private void B_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            NUM1 = lblDisplay.Text;
            firstStart = true;
            if (btn.Text == "+")
                Operators = 1;
            else if (btn.Text == "-")
                Operators = 2;
            else if (btn.Text == "X")
                Operators = 3;
            else if (btn.Text == "÷")
                Operators = 4;

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            NUM2 = lblDisplay.Text;
            if (Operators == 1)
                result = (float.Parse(NUM1) + float.Parse(NUM2)).ToString();
            else if(Operators == 2)
                result = (float.Parse(NUM1) - float.Parse(NUM2)).ToString();
            else if (Operators == 3)
                result = (float.Parse(NUM1) * float.Parse(NUM2)).ToString();
            else if (Operators == 4)
                result = (float.Parse(NUM1) / float.Parse(NUM2)).ToString();
            else { }
            lblDisplay.Text = result;
            SecondStart = false;
            Operators = 0;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if(SecondStart && Operators == 0)
                lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100).ToString();
            else if ( Operators == 0 || Operators == 3 || Operators == 4)
                lblDisplay.Text = (float.Parse(lblDisplay.Text)/100).ToString();
            else if((Operators == 1 || Operators == 2) && firstStart)
                lblDisplay.Text = (float.Parse(lblDisplay.Text) *float.Parse(NUM1)*0.01).ToString();

        }
    }
          
}
