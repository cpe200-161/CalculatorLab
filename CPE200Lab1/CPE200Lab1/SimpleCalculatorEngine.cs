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
        protected double unaryOperand;
        public void setFirstOperand(string num)
        {
            try
            {
                firstOperand = Convert.ToDouble(num);
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                firstOperand = Convert.ToDouble(null);
            }
          
        }
        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }
        public void setunaryOperand(string num)
        {
            unaryOperand = Convert.ToDouble(num);
        }

        //public bool isEmptyfirstOperand()
        //{
        //    return ((firstOperand == null) ? true : false);
        //}
        public string calculate(string operate)
        {
            return calculate(operate, firstOperand.ToString(), secondOperand.ToString());
        }

        public string unaryCalculate(string operate)
        {
            return unaryCalculate(operate, unaryOperand.ToString());
        }
    }
}
