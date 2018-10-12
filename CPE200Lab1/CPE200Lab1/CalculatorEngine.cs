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

        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }

        /// <summary>
        /// Choose for operand √,1/x,+,-,X,÷,%
        /// </summary>
        /// <param name="oper"></param>
        /// <returns></returns>
        public string calculate(string oper)
        {
            switch (oper)
            {
                case "√":
                    if (firstOperand < 0)
                    {
                        return "E";
                    }
                    else
                    {
                        return calculate(oper, Convert.ToString(firstOperand));
                    }

                case "1/x":
                    return calculate(oper, Convert.ToString(firstOperand));
                case "+":
                case "-":
                case "X":
                case "÷":
                case "%":
                    return calculate(oper, Convert.ToString(firstOperand), Convert.ToString(secondOperand));
            }
            return "E";
        }
    }
}
