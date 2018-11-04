using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine : BasicCalculatorEngine
    {
    protected double firstOperand;
        protected double secondOperand;
        public void setFirstOperand(string num)
        {

        }
    public void setSecondOperand(string num)
        {

        }
    public string calculate(string oper)
        {
            try
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
            catch (IndexOutOfRangeException)
            {
                return "E";

            }



        }

    }
}

