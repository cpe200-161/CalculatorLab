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
    public partial class RPNCalculatorView : Form ,View
    {
        RPNCalculatorModel model;
        RPNCalculatorController controller;

        public RPNCalculatorView()
        {
            InitializeComponent();
            model = new RPNCalculatorModel();
            model.AttachObserver(this);
            controller = new RPNCalculatorController();
            controller.AddModel(model);
            Notify(model);
        }

        public void Notify(Model m)
        {
            UpdateDisplay(((RPNCalculatorModel)m).GetDisplay());
        }

        private void UpdateDisplay(string lblDisplay)
        {
            this.lblDisplay.Text = lblDisplay;
        }

        private void btnNumber_Click(object sender, EventArgs e) => controller.NumberPerform(((Button)sender).Text);

        private void btnSpace_Click(object sender, EventArgs e) => controller.SpacePerform();

        private void btnOper_Click(object sender, EventArgs e) => controller.OperPerform(((Button)sender).Text);

        private void btnDot_Click(object sender, EventArgs e) => controller.DotPerform();

        private void btnEqual_Click(object sender, EventArgs e) => controller.EqualPerform(this.lblDisplay.Text);

        private void btnClear_Click(object sender, EventArgs e) => controller.ClearPerform();

        private void btnBack_Click(object sender, EventArgs e) => controller.BackPerform();
    }
}