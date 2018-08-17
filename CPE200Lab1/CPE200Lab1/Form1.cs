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

        public void ConditionBtn(object sender, EventArgs e)
        {
            float num1, num2, result;
            String[] operation;
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                
               

                lblDisplay.Text = lblDisplay.Text + btn.Text;

                if(btn.Text == "=")
                {
                    operation = lblDisplay.Text.Split('+');
                    num1 = float.Parse(operation[0]);

                    var charsToRemove = new string[] { "+", "-", "*", "/", "'" };
                    foreach (var c in charsToRemove)
                    {
                        operation[1] = operation[1].Replace(c, string.Empty);
                    }

                    num2 = float.Parse(operation[1]);

                    result = num1 + num2;
                    lblDisplay.Text = result.ToString("");
                }

            }
           
        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }
    }
}
