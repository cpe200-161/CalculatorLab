using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine : TheCalculatorEngine
    {
        protected double firstOperrand;
        protected double secondOperand;

        public void setFirstOperand(string num)
        {
            firstOperrand = double.Parse(num);
        }
        public void setSecondOperand(string num)
        {
            secondOperand = double.Parse(num);
        }
        public string calculate(string oper)
        {
            return oper;
        }
    }
}
