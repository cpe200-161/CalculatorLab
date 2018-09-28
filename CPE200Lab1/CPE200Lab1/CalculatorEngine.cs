using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : BasicCalculatorEngine
    {
        protected Double firstOperand;
        protected Double secondOperand;

        public void setFirstOperand(string num)
        {
            firstOperand = Convert.ToDouble(num);
        }

        public void setsecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }

        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            try
            {
                if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
                {
                    return "E";
                }
                else
                {
                    setFirstOperand(parts[0]);
                    setsecondOperand(parts[2]);
                    return calculate(parts[1], firstOperand.ToString(),secondOperand.ToString(), 4);
                } 
            }
            catch
            {
                return "E";
            }

        }




    }
}
