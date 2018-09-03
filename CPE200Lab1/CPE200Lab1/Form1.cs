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
        private double Firstnum=0, ans=0;
        private string num;

        private int OperatorCal = 0, i =0;
       // private char Operator;
        public Form1()
        
        {
            InitializeComponent();
        }

        private void display(string txt,int i=0)
        {
            if (txt.Length>9)
            {
                display("Error");
            }
            else
            {
                switch(i)
                {
                    case 1:
                        lblDisplay.Text = "-" + txt;
                        num = lblDisplay.Text;
                        break;

                    case 2:
                        lblDisplay.Text = txt + ".";
                        num = lblDisplay.Text;
                        break;

                    case 3:
                        lblDisplay.Text = txt + "%";
                        num = lblDisplay.Text;
                        break;

                    default:
                        lblDisplay.Text = txt;
                        break;
                }
            }
        }

        private void numClick(double n)
        {
            if(num=="0")
            {
                num = null;
            }
            num += n.ToString();
            display(num);
        }

        private void check(string num, int i=0)
        {
            if(i==0)
            {
                if(num==null)
                {
                    this.num = "0";
                }
            }
            if(i==1)
            {
                string ans1;
                while ((ans.ToString()).Length>9)
                {
                    ans1 = (ans.ToString()).Substring(0, (ans.ToString()).Length - 1);
                    ans = double.Parse(ans1);
                }
                    
            }
        }

        private void Calculator(char Operator, double Firstnum, double Secondnum)
        {
            switch (Operator)
            {
                case '+':
                    ans = Firstnum + Secondnum;
                    display(ans.ToString());
                    break; 

                case '-':
                    ans = Firstnum - Secondnum;
                    display(ans.ToString());
                    break;

                case '*':
                    ans = Firstnum * Secondnum;
                    display(ans.ToString());
                    break;

                case '/':
                    ans = Firstnum / Secondnum;
                    display(ans.ToString());
                    break;

                case '%':
                    ans = Firstnum / 100;
                    check(ans.ToString(), 1);
                    break;
                
            }
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
            num = null;
            Firstnum = 0;
            ans = 0;
            OperatorCal = 0;
            i = 0;
            display("0");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            /* Firstnum = val;
             val = 0;
             val = Secondnum;

             Secondnum =  Firstnum-val;

             display(Secondnum);*/

            check(num);
            Firstnum = double.Parse(num);
            if (OperatorCal != 2 && OperatorCal != 0)
            {
                if (OperatorCal == 1 )
                {
                    Calculator('+', ans, Firstnum);
                }
                else if (OperatorCal == 3)
                {
                    Calculator('*', ans, Firstnum);
                }
                else if (OperatorCal == 4)
                {
                    Calculator('/', ans, Firstnum);
                }
                Firstnum = ans;
            }
            else
            {
                if (i != 0)
                {
                    Calculator('-', ans, Firstnum);
                }
                else
                {
                    i = 1;
                    Calculator('-', Firstnum, 0);
                }
            }
            OperatorCal = 2;
            num = null;

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            /*Firstnum = val;
            val = 0;
            Secondnum =Firstnum*val;

            display(Secondnum);*/

            check(num);
            Firstnum = double.Parse(num);
            if (OperatorCal != 3 && OperatorCal != 0)
            {
                if (OperatorCal == 1)
                {
                    Calculator('+', ans, Firstnum);
                }
                else if (OperatorCal == 2)
                {
                    Calculator('-', ans, Firstnum);
                }
                else if (OperatorCal == 4)
                {
                    Calculator('/', ans, Firstnum);
                }
                Firstnum = ans;
            }
            else
            {
                if (i != 0)
                {
                    Calculator('*', ans, Firstnum);
                }
                else
                {
                    i = 1;
                    Calculator('*', Firstnum, 0);
                }
            }
            OperatorCal = 1;
            num = null;

        }

        private void btnEqual_Click(object sender, EventArgs e)
        { 
           /* Firstnum = val;
            val = 0;
            Secondnum += Firstnum;

            display(Secondnum);*/
            switch(OperatorCal)
            {
                case 1:
                    Calculator('+', Firstnum, double.Parse(num));
                    break;

                case 2:
                    Calculator('-', Firstnum, double.Parse(num));
                    break;

                case 3:
                    Calculator('*', Firstnum, double.Parse(num));
                    break;

                case 4:
                    Calculator('/', Firstnum, double.Parse(num));
                    break;

                case 5:
                    display(ans.ToString());
                    break;
            }
            num = ans.ToString();
            i = 0;
           
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {

            /*Firstnum = val;
            val = 0;
            Secondnum += Firstnum ;

            display(Secondnum);*/
            check(num);
            Firstnum = double.Parse(num);
            if(OperatorCal !=1 && OperatorCal !=0)
            {
                if (OperatorCal == 2)
                {
                    Calculator('-', ans, Firstnum);
                }
                else if (OperatorCal == 3)
                {
                    Calculator('*', ans, Firstnum);
                }
                else if (OperatorCal == 4) 
                {
                    Calculator('/', ans, Firstnum);
                }
                Firstnum = ans;
            }
            else
            {
                if (i != 0)
                {
                    Calculator('+', ans, Firstnum);
                }
                else
                {
                    i = 1;
                    Calculator('+', Firstnum, 0);
                }
            }
            OperatorCal = 1;
            num = null;

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            check(num);
            Firstnum = double.Parse(num);
            if (OperatorCal != 4 && OperatorCal != 0)
            {
                if (OperatorCal == 1)
                {
                    Calculator('+', ans, Firstnum);
                }
                else if (OperatorCal == 2)
                {
                    Calculator('-', ans, Firstnum);
                }
                else if (OperatorCal == 3)
                {
                    Calculator('*', ans, Firstnum);
                }
                Firstnum = ans;
            }
            else
            {
                if (i != 0)
                {
                    Calculator('/', ans, Firstnum);
                }
                else
                {
                    i = 1;
                    Calculator('/', Firstnum, 0);
                }
            }
            OperatorCal = 1;
            num = null;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            check(num);
            Firstnum = double.Parse(num);
            display(Firstnum.ToString(), 3);
            Calculator('%', Firstnum, 0);
            OperatorCal = 5;
            num = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (num.Length == 1)
            {
                num = "0";
            }
            else
            {
                num = num.Substring(0, num.Length - 1);
            }
            display(num);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            display(num, 2);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            display(num, 1);
        }

        
        
    }
}
