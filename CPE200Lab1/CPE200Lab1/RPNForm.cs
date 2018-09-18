using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
	class RPNForm:ExtendForm
	{
		public RPNForm()
		{

		}
		protected override CalculatorEngine Engine()
		{
			return new RPNCalculatorEngine();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// RPNForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(643, 475);
			this.Name = "RPNForm";
			this.Load += new System.EventHandler(this.RPNForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void RPNForm_Load(object sender, EventArgs e)
		{

		}
	}
}
