using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : TheCalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;

        public void setFirstOperand(string num)
        {

        }
        public void setSecondOperand(string num)
        {

        }
        public string Calculate(string oper)
        {
            string[] parts = oper.Split(' ');
            if (isNumber(parts[0]) || isNumber(parts[1]) || isOperator(parts[2]))
            {
                return "E";
            }
            else
            {
                return calculate(parts[2],parts[0],parts[1]);
            }
        }
    }
}
