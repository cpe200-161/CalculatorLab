using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine :TheCalculatoeEngine
    {
        private double firstOperand;
        private double secondOperand;
        public void setFirstOperand(string num)
        {
            firstOperand = Convert.ToDouble(num);
        }

        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }

        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            } else
            {
                setFirstOperand(parts[0]);
                setSecondOperand(parts[2]);
                return calculate(parts[1], Convert.ToString(firstOperand), Convert.ToString(secondOperand), 4);
            }

        }


    }
}
