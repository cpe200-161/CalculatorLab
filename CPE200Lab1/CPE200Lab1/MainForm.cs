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
    public partial class MainForm : Form
    {
        private CalculatorEngine engine = new CalculatorEngine();

        public void reset()
        {
            engine.resetAll();
            lblDisplay.Text = engine.get_display();
        }

        public MainForm()
        {
            InitializeComponent();

            reset();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            engine.numberclick(((Button)sender).Text);
            lblDisplay.Text = engine.get_display();
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            engine.get_operate(((Button)sender).Text, lblDisplay.Text);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            engine.Equalclick();
            lblDisplay.Text = engine.get_display();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            engine.dotclick();
            lblDisplay.Text = engine.get_display();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            engine.signclick();
            lblDisplay.Text = engine.get_display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            engine.backclick();
            lblDisplay.Text = engine.get_display();
        }
    }
}
