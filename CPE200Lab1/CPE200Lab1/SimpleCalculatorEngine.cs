using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class SimpleCalculatorEngine : CalculatorEngine
    {
        protected string firstOperand;
        protected string secondOperand;

        public void setfirstOperand(string num)
        {

            firstOperand = num;
        }


        public void setsecondOperand(string num)
        {
            secondOperand = num;
        }


        public string calculate(string operate)
        {
            string result;
            result = calculate(operate, firstOperand, secondOperand);
            return result;
        }


    }

}
