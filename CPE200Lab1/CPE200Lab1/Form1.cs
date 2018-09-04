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

        float num = 0;
        float p_num = 0;
        bool isfloat = false;
        int counter = 0;
        bool use = false;
        char command = ' ';

        private void display()
        {
            lblDisplay.Text = num.ToString();
        }

        private float pointd(int n)
        {
            float d = 1;
            for (int i = 0; i < n; i++)
            {
                d *= 0.1f;
            }
            return d;
        }

        private void numClick(int n)
        {
            if (!isfloat) num = num * 10 + n;
            else
            {
                counter++;
                num += n * pointd(counter);
            }
            use = false;
            display();
        }

        private void simbolClick(char simbol)
        {
            if (!use) p_num = Cal(num, p_num, command);
            num = 0;
            command = simbol;
            use = true;
            lblDisplay.Text = p_num.ToString();
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
            num = 0;
            p_num = 0;
            command = ' ';
            counter = 0;
            use = false;
            display();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            simbolClick('+');
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            simbolClick('-');
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            simbolClick('*');
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            simbolClick('/');
        }

        private float Cal(float num, float p_num, char command)
        {
            float aws = 0;
            if (command == ' ') aws = num;
            else if (command == '+') aws = p_num + num;
            else if (command == '-') aws = p_num - num;
            else if (command == '*') aws = p_num * num;
            else if (command == '/') aws = p_num / num;
            return aws;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(!isfloat) num = (num - num % 10) / 10;
            else
            {
                counter--;
                num -= num % pointd(counter);
                if (counter == 0) isfloat = false;
            }
            lblDisplay.Text = num.ToString();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            num = p_num * num / 100f;
            display();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            p_num = Cal(num, p_num, command);
            num = 0;
            use = false;
            lblDisplay.Text = p_num.ToString();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            num *= -1;
            display();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            isfloat = true;
        }
    }
}
