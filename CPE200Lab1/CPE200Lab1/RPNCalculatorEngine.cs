using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string process(string str)
        {
            //your code here
            Stack<string> number = new Stack<string>();
            string[] parts = str.Split(' ');
            int i = 0;
            if (isNumber(parts[i]) == true)
            {
                number.Push("parts[i]");
            }
            else if(isOperator(parts[i]) == true)
            {
                if(number.Count < 2)
                {
                    return "E";
                }
                else
                {

                }
            }
            
            return "E";
        }
    }
}
