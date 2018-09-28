using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{

    public class RPNCalculatorEngine : CalculatorEngine
    {

        private string v1, v2;

        public override string Process(string str)
        {
            // your code here
            Stack<string> s = new Stack<string>();
            string[] parts = str.Split(' ');



            foreach (string i in parts)
            {
                if (isNumber(i))
                {
                    s.Push(i);

                }else if (isOperator(i))

                {
                    if (s.Count > 1)
                    {
                        v1 = s.Pop();
                        v2 = s.Pop();
                        s.Push(calculate(i, v2, v1));
                    }
                    else
                        return "E";

                }



            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            result = rpnStack.Pop();
            return result;
        }
    }
    /*
    public class RPNCalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            return "E";
        }
        

        

  
    }
    */
}

            
     
