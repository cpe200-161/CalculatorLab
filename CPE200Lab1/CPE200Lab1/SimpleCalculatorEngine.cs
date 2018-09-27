using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class SimpleCalculatorEngine:CalculatorEngine
    {
        protected Double firstOperand;
        protected Double secondOperand;
        public string result;

        public void setFirstOperand(string num)
        {
            firstOperand = Double.Parse(num);
        }

        public void setSecondOperand(string num)
        {
            secondOperand = Double.Parse(num);
        }

        public string Process(string oper)
        {
            if (isNumber(firstOperand.ToString()) && (oper is "√" || oper is "1/x") ){
                result =  calculate(oper, firstOperand.ToString());
            }
            else if(isNumber(firstOperand.ToString()) && isNumber(secondOperand.ToString()))
            {
                result =  calculate(oper, firstOperand.ToString(), secondOperand.ToString());
            }
            return result;
        }
    }
}
