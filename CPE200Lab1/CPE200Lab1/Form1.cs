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
        float num = 0;
        float result = 0;
        bool check = false;
        bool check2 = false;
        string operation = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0" || check)
            {
                lblDisplay.Text = "";
            }
            check = false;

            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }
        }

        private void Calculate()
        {
            switch (operation)
            {
                case "+":
                    result = num + float.Parse(lblDisplay.Text);
                    break;
                case "-":
                    result = num - float.Parse(lblDisplay.Text);
                    break;
                case "X":
                    result = num * float.Parse(lblDisplay.Text);
                    break;
                case "÷":
                    result = num / float.Parse(lblDisplay.Text);
                    break;
            }
            lblDisplay.Text = result.ToString();
            operation = null;
            check2 = false;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (check2 == true)
            {
                Calculate();
            }
            if (check == false)
            {
                operation = btn.Text;
                num = float.Parse(lblDisplay.Text);
                check = true;
                check2 = true;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (check2 == true)
            {
                Calculate();
            }
            if (check == false)
            {
                operation = btn.Text;
                num = float.Parse(lblDisplay.Text);
                check = true;
                check2 = true;
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (check2 == true)
            {
                Calculate();
            }
            if (check == false)
            {
                operation = btn.Text;
                num = float.Parse(lblDisplay.Text);
                check = true;
                check2 = true;
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (check2 == true)
            {
                Calculate();
            }
            if (check == false)
            {
                operation = btn.Text;
                num = float.Parse(lblDisplay.Text);
                check = true;
                check2 = true;
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100 * num).ToString();
                    break;
                case "-":
                    lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100 * num).ToString();
                    break;
                case "X":
                    lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100).ToString();
                    break;
                case "÷":
                    lblDisplay.Text = (float.Parse(lblDisplay.Text) / 100).ToString();
                    break;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Calculate();
            check = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            num = 0;
            result = 0;
            lblDisplay.Text = "0";
            check = false;
            check2 = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int dot_count = 0;
            char[] text = lblDisplay.Text.ToCharArray();

            for (int i = 0; i < lblDisplay.Text.Length; i++)
            {
                if (text[i] == '.')
                    dot_count = i;
            }

            if (dot_count == 0)
                lblDisplay.Text = lblDisplay.Text + btn.Text;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            float temp = float.Parse(lblDisplay.Text);
            temp = -temp;
            lblDisplay.Text = temp.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
