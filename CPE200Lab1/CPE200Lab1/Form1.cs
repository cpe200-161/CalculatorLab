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

        private void btnDivide_Click(object sender, EventArgs e)
        {
            first = lblDisplay.Text;
            setfirst = true;
            setlob = false;
            setsecond = false;
            setplus = false;
            setkon = false;
            sethan = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            string per,tri;
            tri = lblDisplay.Text;
            per = (float.Parse(first) * float.Parse(tri) / 100).ToString();
            lblDisplay.Text = per;
            setsecond = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            first = lblDisplay.Text;
            setfirst = true;
            setlob = false;
            setsecond = false;
            setplus = false;
            setkon = true;
            sethan = false;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            first = lblDisplay.Text;
            setfirst = true;
            setlob = true;
            setsecond = false;
            setplus = false;
            setkon = false;
            sethan = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string sum;
            if (setsecond == true) {
                setfirst = false;
                second = lblDisplay.Text;

            }
            if (setplus == true)
            {
                sum = (float.Parse(first) + float.Parse(second)).ToString();
                lblDisplay.Text = "";
                lblDisplay.Text = sum ;
            }
            if (setlob == true)
            {
                sum = (float.Parse(first) - float.Parse(second)).ToString();
                lblDisplay.Text = "";
                lblDisplay.Text = sum;
            }
            if (setkon == true)
            {
                sum = (float.Parse(first) * float.Parse(second)).ToString();
                lblDisplay.Text = "";
                lblDisplay.Text = sum;
            }
            if (sethan == true)
            {
                sum = (float.Parse(first) / float.Parse(second)).ToString();
                lblDisplay.Text = "";
                lblDisplay.Text = sum;
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if( setfirst == true && setsecond ==false ) {
                lblDisplay.Text = "";
                setsecond = true;
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
            setsecond = false;
            setlob = false;
            setkon = false;
            sethan = false;


        }
        
    }
}
