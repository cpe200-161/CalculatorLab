using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : TheCalculatorEngine
    {
        protected Double firsrOperand;
        protected Double secondOperand;

        public void setFirstOperand(String num)
        {
            firsrOperand = double.Parse(num);
        }

        public void setSecondOperand(String num)
        {
            secondOperand = double.Parse(num);
        }

        public string calculate(string oper)
        {
            return oper;
        }
       


    }
}
