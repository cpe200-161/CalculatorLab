using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
		private bool isNumberPart = false;
		private bool isContainDot = false;
		private bool isSpaceAllowed = false;
		public string lblDisplay = "0";

		public String screen ()
		{
			return lblDisplay;
		}

		private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        private bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            } else
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }

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
                case "1/x":
                    if(operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
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
                    break;
            }
            return "E";
        }

		public void amount_click(string num)
		{
			if (lblDisplay is "Error")
			{
				return;
			}
			if (lblDisplay is "0")
			{
				lblDisplay = "";
			}
			if (!isNumberPart)
			{
				isNumberPart = true;
				isContainDot = false;
			}
			lblDisplay += num;
			isSpaceAllowed = true;
		}

		public void clean()
		{
			lblDisplay = "0";
			isContainDot = false;
			isNumberPart = false;
			isSpaceAllowed = false;
		}

		public void space()
		{
			if (lblDisplay is "Error")
			{
				return;
			}
			if (isSpaceAllowed)
			{
				lblDisplay += " ";
				isSpaceAllowed = false;
			}
		}

		public void Dot()
		{
			if (lblDisplay is "Error")
			{
				return;
			}
			if (!isContainDot)
			{
				isContainDot = true;
				lblDisplay += ".";
				isSpaceAllowed = false;
			}
		}

		public void sign()
		{
			if (lblDisplay is "Error")
			{
				return;
			}
			if (isNumberPart)
			{
				return;
			}
			string current = lblDisplay;
			if (current is "0")
			{
				lblDisplay = "-";
			}
			else if (current[current.Length - 1] is '-')
			{
				lblDisplay = current.Substring(0, current.Length - 1);
				if (lblDisplay is "")
				{
					lblDisplay = "0";
				}
			}
			else
			{
				lblDisplay = current + "-";
			}
			isSpaceAllowed = false;
		}

		public void two_operator(string bi)
		{
			if (lblDisplay is "Error")
			{
				return;
			}
			isNumberPart = false;
			isContainDot = false;
			string current = lblDisplay;
			if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2].ToString()))
			{
				lblDisplay += " " + bi + " ";
				isSpaceAllowed = false;
			}
		}

		public void back()
		{
			if (lblDisplay is "Error")
			{
				return;
			}
			// check if the last one is operator
			string current = lblDisplay;
			if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2].ToString()))
			{
				lblDisplay = current.Substring(0, current.Length - 3);
			}
			else
			{
				lblDisplay = current.Substring(0, current.Length - 1);
			}
			if (lblDisplay is "")
			{
				lblDisplay = "0";
			}
		}

		public void balance()
		{
			string result = Process(lblDisplay);
			if (result is "E")
			{
				lblDisplay = "Error";
			}
			else
			{
				lblDisplay = result;
			}
		}


	}
}
