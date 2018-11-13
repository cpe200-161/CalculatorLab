using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CPE200Lab1
{
    class SimpleCalculatorEngine : CalculatorEngine
    {
        protected double firstoperand;
        protected double secondoperand;
        public void setfirstOperand(string num)
        {
            firstoperand = Double.Parse(num);
        }
        protected void setsecondOperand(string num)
        {
            secondoperand = Double.Parse(num);
        }
        public String Calculate(string op)
        {
            return calculate(op);
        }
    }
}