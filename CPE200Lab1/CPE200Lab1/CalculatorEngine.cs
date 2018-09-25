using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
		/// <summary>
		/// Check string is double number 
		/// </summary>
		/// <param name="str">String for check</param>
		/// <returns>True is number or false if isn't number</returns>
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }
		/// <summary>
		/// Check string is Operator
		/// </summary>
		/// <param name="str">String for check</param>
		/// <returns>True is Operator or false isn't Operator</returns>
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
		/// <summary>
		/// check equation model and return result
		/// </summary>
		/// <param name="str">String for check equation model</param>
		/// <returns>The result of the equation or Error if worng equation model</returns>
		public string Process(string str)
        {
			try
			{
				string[] parts = str.Split(' ');
				if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
				{
					return "E";
				}
				else
				{
					return calculate(parts[1], parts[0], parts[2], 4);
				}
			}
			catch (Exception e)
			{
				return "E";
			}
		}
		/// <summary>
		/// Division and return result
		/// </summary>
		/// <param name="firstOperand">first number for division</param>
		/// <param name="secondOperand">second number for division</param>
		/// <returns>will return Error if division by zero || return result of division two number when do not division by zero</returns>
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
			{
				resultNew = Convert.ToDouble(result.ToString("N" + remainLength));
				return resultNew.ToString();
			}
		}
		/// <summary>
		/// Unary calculate
		/// </summary>
		/// <param name="operate">operater for calculate</param>
		/// <param name="operand">number for calculate</param>
		/// <param name="maxOutputSize"></param>
		/// <returns>result of unary calculate</returns>
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
						double resultNew;
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
						else
						{
							resultNew = Convert.ToDouble(result.ToString("N" + remainLength));
							return resultNew.ToString();
						}
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
		/// <summary>
		/// calculate of two number and return result
		/// </summary>
		/// <param name="operate"> Operator for calculate</param>
		/// <param name="firstOperand">first number for calculate</param>
		/// <param name="secondOperand">second number for calculate</param>
		/// <param name="maxOutputSize">fix max lenght number of result</param>
		/// <returns>result calculate of two double number</returns>
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
