using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : BasicCalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;
        public void setFirstOperand(string num)
        {
            firstOperand = Convert.ToDouble(num);
        }

        public void setSecondOperand(String num)
        {
            secondOperand = Convert.ToDouble(num);
        }
        /// <summary>
        /// Process Input Number
        /// </summary>
        /// <param name="str"></param>
        /// <returns> Result from calculate</returns>
        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]))
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }
            else if (isNumber(parts[0]) && parts[1] == "%")
            {
                return calculate("%", "1", parts[0]);
            }
            else if (isNumber(parts[0]) && parts[1] == "√")
            {
                return calculate(parts[1], parts[0]);
            }
            else if (parts.Length >= 4 && parts[3] == "%") // 1+2% 
            {
                string percent = calculate(parts[3], parts[0], parts[2]);
                return calculate(parts[1], parts[0], parts[2], 4);
            }
            else if (isNumber(parts[0]) && parts[1] == "1/x")
            {
                return calculate(parts[1], parts[0]);
            }
            else
            {
                return "E";
            }

        }
    }
}
