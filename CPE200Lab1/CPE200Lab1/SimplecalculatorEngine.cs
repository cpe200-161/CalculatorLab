using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class SimpleCalculatorEngine : CalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;
        public void setFirstOperand(string num)
        {
            firstOperand = Double.Parse(num);
        }
        public void setSecondOperand(string num)
        {
            secondOperand = Double.Parse(num);
        }
        public String calculate(string oper)
        {
            return calculate(oper);
        }
    }
}
