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
        protected double secondoperand;

        public void setFirstOperand(string str)
        {
            firstOperand = Convert.ToDouble(str);
        }
        public void setSecondOperand(string str)
        {
            secondoperand = Convert.ToDouble(str);
        }
        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            }
            else
            {
                setFirstOperand(parts[0]);
                setSecondOperand(parts[2]);
                return calculate(parts[1], parts[0], parts[2], 4);
            }
        }
    }
}
