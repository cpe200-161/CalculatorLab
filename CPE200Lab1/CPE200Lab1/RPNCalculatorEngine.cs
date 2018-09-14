using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {
        string w1, w2, w3;
        public override string Process(string str)
        {
            Stack<string> cct = new Stack<string>();
            string[] parts = str.Split(' ');

            cct.Push(parts[0]);
            cct.Push(parts[1]);
            cct.Push(parts[2]);

            if (!(isNumber(parts[0]) && isOperator2(parts[1]) && isNumber(parts[2])))
            {
                w3 = cct.Pop();
                w2 = cct.Pop();
                w1 = cct.Pop(); //operators
    
                return calculate(w3, w1, w2, 4);              
            } else
            {
                return "E";

            }

            

        }

        

    }
}
