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

        public void setFirstOperand(string value)
        {
            firstOperand = Convert.ToDouble(value);
        }

        public void setSecondOperand(string value)
        {
            secondOperand = Convert.ToDouble(value);
        }

        /// <summary>
        /// Processing the normal style calculation.
        /// </summary>
        /// <param name="oper"> The string of expressions. </param>
        /// <returns> Returns the result of string. </returns>
        public string calculate(string oper)
        {
            string[] parts = oper.Split(' ');
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
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
