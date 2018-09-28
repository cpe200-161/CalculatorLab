using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine : BasicCalculatorEngine
    {
       protected string firstOperand;
       protected string secondOperand;

        public void setFristOperand(string num)
        {

        }
        public void setSecondtOperand(string num)
        {

        }

        public string caculate(string str)
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
