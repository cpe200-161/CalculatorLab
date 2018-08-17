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
        string operation = "";
        Double result = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void num_Button(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "0")
                lblDisplay.Text = "";
            if (lblDisplay.Text.Length <= 8)
            {
                Button num = (Button)sender;
                lblDisplay.Text = lblDisplay.Text + num.Text;
            }
        }

        private void operation_Button(object sender, EventArgs e)
        {
            Button operat = (Button)sender;
            operation = operat.Text;
            result = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    lblDisplay.Text = result + double.Parse(lblDisplay.Text);
                    break;




            }
        }
    }
}
