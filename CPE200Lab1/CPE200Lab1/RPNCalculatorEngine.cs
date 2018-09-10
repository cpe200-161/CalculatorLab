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
                    if (Stacknumber.Count < 2)
                    {
                        return "E";
                    }
                        first = Stacknumber.Pop();
                        second = Stacknumber.Pop();
                        Stacknumber.Push(calculate(number, second, first));
                    
                }
                else if(isNumber(number)) 
                {
                    Stacknumber.Push(number);
                }
                else if(number == "Root")
                {
                    string first;
                    first = Stacknumber.Pop();
                    
                    Stacknumber.Push(calculate(number, first,"0"));
                }
                else if (number== "1/x")
                {
                    string first;
                    first = Stacknumber.Pop();
                    
                    Stacknumber.Push(calculate(number,first, "0"));
                }
                else if (number == "%")
                {
                    string first, second;
                    first = Stacknumber.Pop();
                    second = Stacknumber.Pop();
                    Stacknumber.Push(calculate(number, second, first));
                }
                
            }
           
            if (Stacknumber.Count > 1)
            {
                return "E";
            }
            
            return Stacknumber.Pop();
        }
    }
}
