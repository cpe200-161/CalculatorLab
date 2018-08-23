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
        string input;
        double num1;
        double num2;
        string operation = null;
        double sum = 0;
        double sum2;
        string show;
        bool check;
        bool check2 = true;
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
            if (operation != null && check == true) lblDisplay.Text = ""; check = false;
            if (lblDisplay.Text.Length < 8 )
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
                
            }
            if (input != null) input = input + btn.Text;
            else input = btn.Text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {

        }

        private void btn4_Click(object sender, EventArgs e)
        {

        }

        private void btn5_Click(object sender, EventArgs e)
        {

        }

        private void btn6_Click(object sender, EventArgs e)
        {

        }

        private void btn7_Click(object sender, EventArgs e)
        {

        }

        private void btn8_Click(object sender, EventArgs e)
        {

        }

        private void btn9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOpe_Click(object sender, EventArgs e)
        {
            num2 = Convert.ToDouble(input);
            Button ope = (Button)sender;
            operation = ope.Text;

            
            if (operation == "+" )
            {
                sum = sum + num2;
            }
            
            if (operation == "-" )
            {

                sum = sum - num2;
            }
            if (operation == "*" )
            {

                sum = sum * num2;
            }
            if (operation == "/")
            {

                sum = sum / num2;
            }
            /*if (num1 == 0) 
            {
                num1 = Convert.ToDouble(input);


                input = null;
            }
            else
            {
            
                
                check2 = false;

            }*/
            show = Convert.ToString(sum);
            lblDisplay.Text = show;

            
            check = true;
            input = null;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
           
        }
    }
}
