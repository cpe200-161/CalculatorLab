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
        float resultValue = 0;
        float reverse = 0;
        float percent = 0;
        int count = 0;
        string operationPerformed = "";
        bool Performed1 = false;
        bool Performed2 = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (count == 2)
            {
                result.Text = string.Empty;
                count = 1;
            }
            if (result.Text == "0")
            {
                result.Text = "";
            }
            if (result.Text.Length <8)
            {
                result.Text = result.Text + btn.Text;
            }
            Performed2 = true;
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (operationPerformed)
            {
                    case "+":
                        if (count == 1)
                        {
                            resultValue = resultValue + float.Parse(result.Text);
                            result.Text = resultValue.ToString();
                        }
                        break;
                    case "-":
                        if (count == 1)
                        {
                            resultValue = resultValue - float.Parse(result.Text);
                            result.Text = resultValue.ToString();
                        }
                        break;
                    case "X":
                        if (count == 1)
                        {
                            resultValue = resultValue * float.Parse(result.Text);
                            result.Text = resultValue.ToString();
                        }
                        break;
                    case "/":
                        if (count == 1)
                        {
                            resultValue = resultValue / float.Parse(result.Text);
                            result.Text = resultValue.ToString();
                        }
                        break;
         
            }
                    resultValue = float.Parse(result.Text);
                    if (resultValue % 2 != 0)
                    {
                        Performed1 = true;
                    }
                    operationPerformed = btn.Text;
                    count = 2;
                    Performed2 = false;
                    Performed1 = false;
        }


        private void btnSign_Click(object sender, EventArgs e)
        {
            reverse = -float.Parse(result.Text);
            result.Text = reverse.ToString();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (Performed1 == false && count == 2)
            {
                result.Text = "0" + ".";
                Performed1 = true;
            }
            else if (Performed1 == false)
            {
                result.Text = result.Text + ".";
                Performed1 = true;
            }
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            resultValue = 0;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            percent = float.Parse(result.Text);
            switch (operationPerformed)
            {
                case "+":
                    resultValue = resultValue + (resultValue*(percent / 100));
                    break;
                case "-":
                    resultValue = resultValue - (resultValue * (percent / 100));
                    break;
                case "X":
                    resultValue = (resultValue * (percent / 100));
                    break;
                case "/":
                    resultValue = (resultValue / (percent / 100));
                    break;
            }
            result.Text = resultValue.ToString();
            resultValue = float.Parse(result.Text);
            operationPerformed = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Performed2 == true)
            {
                if (result.Text.Length > 1)
                {
                    result.Text = result.Text.Remove(result.Text.Length - 1);
                }
                else
                {
                    result.Text = "0";
                }
            }
        }
    }
}
