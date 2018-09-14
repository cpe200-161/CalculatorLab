using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            Stack myStack = new Stack();
            
            //check every string in parts
            foreach(string p in parts)
            {
                if (isOperator(p))
                { 
                    //when doing operator stack must have at least 2 item
                    if (myStack.Count < 2)
                    {
                        return "E";
                    }

                    String num2 = (String)myStack.Pop();
                    String num1 = (String)myStack.Pop();

                    myStack.Push(calculate(p, num1, num2));

                }
                else if (isNumber(p))
                {
                    //if p is a number push it in stack
                    myStack.Push(p);
                }
                else if (isUnary(p))
                {
                    //when doing unaryOperator stack must have at least 1 item
                    if (myStack.Count < 1)
                    {
                        return "E";
                    }

                    String num = (String)myStack.Pop();
                    myStack.Push(unaryCalculate(p, num));
                }
            }

            if(myStack.Count == 1)
            {
                return (String)myStack.Pop();
            }

            return "E";
        }
    }
}
