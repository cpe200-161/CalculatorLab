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
    public partial class ExtendForm : Form
    {
        private ExtendFromControler controler;

        public ExtendForm()
        {
            InitializeComponent();
            controler = new ExtendFromControler();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = controler.clickNum(((Button)sender).Text , lblDisplay.Text);
        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = controler.clickBinaryOperator(((Button)sender).Text , lblDisplay.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = controler.clickBack(lblDisplay.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = controler.clickClear();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = controler.clickEqual(lblDisplay.Text);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = controler.clickSing(lblDisplay.Text);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = controler.clickDot(lblDisplay.Text);
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = controler.clickSpace(lblDisplay.Text);
        }
    }
}
