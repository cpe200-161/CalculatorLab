using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class SimplecalculatorEngine : calculatorEngine
    {
        protected double firstoperand;
        protected double secondoperand;
        public void setFirstoperand(string num)
        {
            firstoperand = Convert.ToDouble(num);
        }
        public void setSecondoperand(string num)
        {
            secondoperand = Convert.ToDouble(num);
        }
        public string Calculate(string oper)
        {
            return calculate(oper);
        }
    }
}
