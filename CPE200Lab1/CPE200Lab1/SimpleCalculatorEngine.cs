using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class SimpleCalculatorEngine:CalculatorEngine
    {
        protected double FirstOperand, SecondOperand, UnaryOperand;

        public void SetFirstOperand(string num)
        {
            FirstOperand = Convert.ToDouble(num);

        }

        public void SetSecondOperand(string num)
        {
            SecondOperand=Convert.ToDouble(num);
        }

        public void SetUnaryOperand(string num)
        {
            UnaryOperand = Convert.ToDouble(num);
        }

        public string UnaryCalculate(string operate)
        {
            return unaryCalculate(operate, UnaryOperand.ToString());
        }

        public string Calculate(string operate)
        {
            return calculate(operate, FirstOperand.ToString(), SecondOperand.ToString());
        }
    }
}
