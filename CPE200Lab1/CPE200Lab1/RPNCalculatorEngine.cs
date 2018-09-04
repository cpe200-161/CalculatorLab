using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine 
    {
        public string Process(string str)
        {
            Stack<string> Stacknumber = new Stack<string>();
            string[] parts = str.Split(' ');

            foreach (string number in parts)
            {
                if (isOperator(number))
                {
                    string first, second;
                    first = Stacknumber.Pop();
                    second = Stacknumber.Pop();
                    Stacknumber.Push(calculate(number, second, first));
                }
                else 
                {
                    Stacknumber.Push(number);
                }
            }
            
            
                return Stacknumber.Pop();
            
            
            
                return "E";
               

            
            
               
            
            
        }
    }
}
