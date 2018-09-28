using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : BasicCalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;

        public void setFirstOperand()
        {

        }

        public void setSecondOperand()
        {

        }

        public string calculate(string str)
        {
            try
            {
                string[] parts = str.Split(' ');
                return calculate(parts[1], parts[0], parts[2], 4);
            }
            catch(IndexOutOfRangeException)
            {
                return "E";
            }
        }
        
    }
}
