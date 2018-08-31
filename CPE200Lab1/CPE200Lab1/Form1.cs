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
        private double  val = 0;
        private double je1,je2;
        private string before = "";
        private int P =0;
        private double W = 0;
        public Form1()
        {
            InitializeComponent();
        }
       
 
        private void display(double show){
            lblDisplay.Text = show.ToString();
        }

        private void numclick(int n,double m=10)
        {
            val = val * m + n;
            display(val);
        }
        
        private void btn1_Click(object sender, EventArgs e)
        {
            numclick(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            numclick(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            numclick(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            numclick(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            numclick(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            numclick(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            numclick(7);
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            numclick(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            numclick(9);
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            numclick(0);
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            
           
        }
        private void btnSign_Click(object sender, EventArgs e)
        {
            val = (val * (-1));
            display(val);

        }
       
        
        private void btnDot_Click(object sender, EventArgs e)
            {
            
            }

        private void btnClear_Click(object sender, EventArgs e)
        {
            val = 0 ;
            je1 = 0;
            je2 = 0;
            display(val);

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            P = 3;
          
            je1 = val;
            val = 0;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            P = 4;
            je1 = val;
            val = 0;
        }
        
        private void btnPlus_Click(object sender, EventArgs e)
        {   P = 1;
             je2 =   je1 + val;
             display(je2);
             val = je2;
             je1 = val;//จำ
                       //val = je2 ไม่จำเป็น;
            je2 = 0;
            val = 0;
           
 

        }

        private void btnMinus_Click(object sender, EventArgs e)
         {
            P = 2;
            je1 = val;
            val = 0;
            je2 = je1 - val;
            display(je2);
            val = je2;
                      //val = je2 ไม่จำเป็น;
            je2 = 0;
            val = 0;
            //je2 -= je1;
            // lblDisplay.Text = je2.ToString();

         }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (P)
            {
                case 1:
                    je2 = je1+val;
                    display(je2);
                    val = je2;
                    je2 = 0;
                    break;
                case 2:
                    je2 = je1 - val;
                    display(je2);
                    val = je2;
                    je2 = 0;
                    break;
                case 3:
                    je2 = je1 * val;
                    display(je2);
                    val = je2;
                    je2 = 0;
                    break;
                case 4:
                    je2 = je1 / val;
                    display(je2);
                    val = je2;
                    je2 = 0;
                    break;
            }
           

        }
            
            
        
    }
}
