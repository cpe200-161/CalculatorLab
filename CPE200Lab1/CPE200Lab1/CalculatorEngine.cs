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
        protected void setFirstOperand(string num)
        {
            firstOperand = Convert.ToDouble(num);
        }
        protected void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }
        protected string calculate(string oper)
        {
            string[] parts = oper.Split(' ');
            if(!isNumber(parts[0]) || !isNumber(parts[2]) || !isOperator(parts[1]))
            {
                return "E";
            }
            else
            {
                return calculate(parts[1], parts[0], parts[2]);
            }
        }
    }
}   
