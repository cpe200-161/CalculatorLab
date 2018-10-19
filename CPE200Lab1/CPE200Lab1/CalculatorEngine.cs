using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : TheCalculatoreEngine
    {
        private double firstOperand;
        private double secondOperand;

        public void setFirstOperand(string num)
        {
            firstOperand = Convert.ToDouble(num);
        }

        public void setsSeconOperand(string num)
        {

            secondOperand = Convert.ToDouble(num);
        }

        public string calculate(string oper)
        {
            return "E";
        }
    }
}
