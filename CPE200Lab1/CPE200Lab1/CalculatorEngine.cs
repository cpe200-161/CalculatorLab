using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine : SimpleCalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;

        public void setFirstOperand(string num)
        {
            firstOperand = double.Parse(num);
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
