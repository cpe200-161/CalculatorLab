using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{

	class CalculatorEngine
	{
		private bool hasDot;
		private bool isAllowBack;
		private bool isAfterOperater;
		private bool isAfterEqual;
		private string firstOperand;
		private string operate;

		private string display = "0" ;

		public string Display()
		{
			return display;
		}

		public void resetAll()
		{
			isAllowBack = true;
			hasDot = false;
			isAfterOperater = false;
			isAfterEqual = false;
			display = "0";
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
					// Not allow devide be zero
					if (secondOperand != "0")
					{
						double result;
						string[] parts;
						int remainLength;

						result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
						// split between integer part and fractional part
						parts = result.ToString().Split('.');
						// if integer part length is already break max output, return error
						if (parts[0].Length > maxOutputSize)
						{
							return "E";
						}
						// calculate remaining space for fractional part.
						remainLength = maxOutputSize - parts[0].Length - 1;
						// trim the fractional part gracefully. =
						return result.ToString("N" + remainLength);
					}
					break;
				case "%":
					//your code here
					return ((Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)) / 100).ToString();

					break;
			}
			return "E";
		}

		public void handleSign()
		{
			if (isAfterEqual)
			{
				resetAll();
			}
			// already contain negative sign
			if (display.Length is 8)
			{
				return;
			}
			if (display[0] is '-')
			{
				display = display.Substring(1, display.Length - 1);
			}
			else
			{
				display = "-" + display;
			}
		}
		string digit;
		public void swit(string dig)
		{
			digit = dig;
		}
		public void Num()
		{
			if (isAfterEqual)
			{
				resetAll();
			}
			if (isAfterOperater)
			{
				display = "0";
			}
			if (display.Length is 8)
			{
				return;
			}
			isAllowBack = true;

			if (display is "0")
			{
				display = "";
			}

			display += digit;

			isAfterOperater = false;
		}
		public void switop(string op)
		{
			operate = op;
		}
		
		public void Operlator()
		{
			if (isAfterOperater)
			{
				return;
			}
			
			switch (operate)
			{
				case "+":
				case "-":
				case "X":
				case "÷":
					firstOperand = display;
					isAfterOperater = true;
					break;
				case "%":
					// your code here
					Convert.ToDouble(firstOperand);
					break;
			}
			isAllowBack = false;
		}
		public void Dot()
		{
			if (isAfterEqual)
			{
				resetAll();
			}
			if (display.Length is 8)
			{
				return;
			}
			if (!hasDot)
			{
				display += ".";
				hasDot = true;
			}
		}
		public void Back()
		{
			if (isAfterEqual)
			{
				return;
			}
			if (!isAllowBack)
			{
				return;
			}
			if (display != "0")
			{
				string current = display;

				char rightMost = current[current.Length - 1];
				if (rightMost is '.')
				{
					hasDot = false;
				}
				display = current.Substring(0, current.Length - 1);

				if (display is "" || display is "-")
				{
					display = "0";
				}
			}
		}
		public void Equal()
		{
			string secondOperand = display;

			string result = calculate(operate, firstOperand, secondOperand);
			if (result is "E" || result.Length > 8)
			{
				display = "Error";
			}
			else
			{
				display = result;
			}
			isAfterEqual = true;
		}

		
		
	}

}
