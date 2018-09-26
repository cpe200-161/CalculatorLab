using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class SimpleCalculatorEngine : CalculatorEngine
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
        public string calculate(string oper)
        {
            return calculate(oper, Convert.ToString(firstOperand), Convert.ToString(secondOperand));
        }
    }
}