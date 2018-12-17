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
            firstOperand = Convert.ToDouble(num);
        }

        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }

        public string calculate(string oper)
        {
            string[] parts = oper.Split(' ');
            if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]))
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }
            else
            {
                return "E";
            }
        }




    }
}
