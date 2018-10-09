using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : TheCaluculatorEngine
    {
        protected Double firstOperand;
        protected Double secondOperand;

        public void setFirstOperand(String num)
        {
            firstOperand = Convert.ToDouble(num);
        }

        public void setsecondOperand(String num)
        {
            secondOperand = Convert.ToDouble(num);
        }

        public string calculate(string oper)
        {
            string[] parts = oper.Split(' ');
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            }
            else
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }

        }
        
    }
}
