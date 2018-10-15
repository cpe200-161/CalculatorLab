using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine:TheCalculatorEngine
	{
		private double firstOperand;
		private double secondOperand;
		public void setFirstOperand(string num)
		{
			firstOperand = Convert.ToDouble(num);
		}
		public void setSecondOperand(string num)
		{
			secondOperand = Convert.ToDouble(num);
		}
		public string calculate(string oper)
		{
			switch (oper)
			{
				case "+":
				case "-":
				case "X":
				case "÷":
				case "%":
					calculate(oper, firstOperand.ToString(), secondOperand.ToString());
					break;
				case "√":
				case "x":
					calculate(oper, firstOperand.ToString());
					break;
			}
			return "E";
		}
        public string Process(string oper)
        {
            string[] parts = oper.Split(' ');
			if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
				return "E";
            }
			else
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }
		}
    }
}
