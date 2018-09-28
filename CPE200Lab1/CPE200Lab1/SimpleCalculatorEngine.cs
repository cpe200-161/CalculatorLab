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
            firstOperand = double.Parse(num);
        }

        public void setSecondOperand(string num)
        {
            secondOperand = double.Parse(num);
        }

        public string process(string oper)
        {
            if(oper is "√" || oper is "1/x")
            {
               return calculate(oper, firstOperand.ToString());
            }
            else
            {
                return calculate(oper, firstOperand.ToString(), secondOperand.ToString());
            }

        }
}
}