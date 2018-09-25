using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        public bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
				case "%":
				case "√":
				case "1/x":
					return true;
            }
            return false;
        }

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
			if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]))
			{
				return calculate(parts[1], parts[0], parts[2], 4);
			}
			else
			{
				return "E";
			}
		}

		public string safeDevision(string firstOperand, string secondOperand)
		{
			double result;
			double resultNew;
			string[] parts;
			int remainLength;

			if (secondOperand == "0")
			{
				throw new System.DivideByZeroException();
			}
			result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
			parts = result.ToString().Split('.');
			if (parts[0].Length > 8)
			{
				return "E";
			}
			remainLength = 8 - parts[0].Length - 1;
			if (Convert.ToDouble(firstOperand) % Convert.ToDouble(secondOperand) == 0)
			{
				return result.ToString();
			}
			else
				return result.ToString();
		}
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
						if (Convert.ToDouble(operand) % result == 0)
						{
							return result.ToString();
						}
                        return result.ToString("N" + remainLength);
                    }
                case "1/x":
					try
					{
						return safeDevision("1",operand);
					}
					catch (DivideByZeroException e)
					{
						return "E";
					}
                 
            }
            return "E";
        }

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
					try
					{
						return safeDevision(firstOperand, secondOperand);
					}
					catch (DivideByZeroException e)
					{
						return "E";
					}
                case "%":
					return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand) / 100).ToString();
					
            }
            return "E";
        }
    }
}
