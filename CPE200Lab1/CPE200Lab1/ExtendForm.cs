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
        private CalculatorEngine engine;

        public ExtendForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
        }

        private string Display()
        {
            lblDisplay.Text = engine.Display();
            return lblDisplay.Text;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            engine.handleNumber(((Button)sender).Text);
            Display();
        }
        
        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            engine.handleBinaryOperator(((Button)sender).Text);
            Display();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            engine.handleBack();
            Display();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            engine.handleClear();
            Display();
        }
        
        private void btnEqual_Click(object sender, EventArgs e)
        {
            engine.handleEqual();
            Display();
        }
        
        private void btnSign_Click(object sender, EventArgs e)
        {
            engine.handleSign();
            Display();
        }
        
        private void btnDot_Click(object sender, EventArgs e)
        {
            engine.handleDot();
            Display();
        }
        
        private void btnSpace_Click(object sender, EventArgs e)
        {
            engine.handleSpace();
            Display();
        }
    }
}
