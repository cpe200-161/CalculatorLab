using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : TheCalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;
        public void setFirstQperand(String num)
        {
            firstOperand = double.Parse(num);
        }
        public void setSecondQperand(String num)
        {
            secondOperand = double.Parse(num);
        }
        public String calculate(String oper)
        {
            return "E";           
        }

    }
}
