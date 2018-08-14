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
        string first, second;
        bool setplus=false, setlob=false,setkon=false,sethan=false,setfirst=false,setsecond;

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string sum;
            second = lblDisplay.Text;
            if (setplus == true)
            {
                sum = (float.Parse(first) + float.Parse(second)).ToString();
                lblDisplay.Text = sum ;
            }
            lblDisplay.Text = "";
           
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if( setfirst ==true  ) {
                lblDisplay.Text = "";

            }
            if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text += btn.Text;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            first = lblDisplay.Text;
            setfirst = true;
            setplus = true;
            

        }
        
    }
}
