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
        double Firstnum,Secondnum;
         
        String Operation;
        private double val,val2;
        public Form1()
        
        {
            InitializeComponent();
        }

        private void display(double show)
        {
            lblDisplay.Text = show.ToString();
        }

        private void numClick(int n)
        {
            val = val * 10 + n;
            display(val);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            //Old
            //val = val * 10 + 1;
            //lblDisplay.Text = val.ToString();
            //New
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

       
        private void btn0_Click(object sender, EventArgs e)
        {
            numClick(0);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            val=0;
            Firstnum = 0;
            Secondnum = 0;
            display(val);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Firstnum = val;
             val = 0;
            val = Secondnum;

            Secondnum =  Firstnum-val;

            display(Secondnum);

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            Firstnum = val;
            val = 0;
            Secondnum =Firstnum*val;

            display(Secondnum);

        }

        private void btnEqual_Click(object sender, EventArgs e)
        { 
            Firstnum = val;
            val = 0;
            Secondnum += Firstnum;

            display(Secondnum);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Firstnum = val;
            val = 0;
            Secondnum += Firstnum ;

            display(Secondnum);

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            val = val * (-1);
            display(val);
        }

        
    }
}
