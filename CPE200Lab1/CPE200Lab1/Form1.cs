using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void btnN_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (lblDisplay.Text.Length <= 8)
            {
                lblDisplay.Text = lblDisplay.Text + btn.Text;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            float x = float.Parse(lblDisplay.Text);
            //typeof(Form1).GetMethod("btnEqual_Click", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new Form1(), null);
            if (lblDisplay.Text != "")
            {
                lblDisplay.Text = string.Format("{0:0}", x);
     
            }
            


        }

        private void btnEqual_Click(object sender, EventArgs e)
        {

            //float x = float.Parse(lblDisplay.Text);
            //x += 1;
           // lblDisplay.Text = string.Format("{0:0}", x);

        }
    }
}
