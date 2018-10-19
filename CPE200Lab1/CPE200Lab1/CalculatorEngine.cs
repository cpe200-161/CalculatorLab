using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : BasicCalculatorEngine
    {
        double firstOperand;
        double secondOperand;
       

        public string calculate(string str)
        {
            string[] parts = str.Split(' ');
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            }
            else if (parts.Length == 5)
            {               
                return calculate(parts[3], parts[0], parts[2], 4);
            }
            else
            {      
                
                return calculate(parts[1], parts[0], parts[2], 4);
            }           

        }
        public void setFirstOperand(string num)
        {
            firstOperand = Convert.ToDouble(num);
        }
        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }

    }
   
}
