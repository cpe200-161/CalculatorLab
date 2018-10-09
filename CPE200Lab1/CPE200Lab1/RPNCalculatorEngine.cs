using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        protected Stack<string> myStack;

        public string calculate(string oper)
        {
            myStack = new Stack<string>();
            string[] part = oper.Split(' ');
            string firstOp;
            string seccondOp;
            
            foreach(string text in part)
            {
                if (isNumber(text))
                {
                    myStack.Push(text);
                }
                else if(isOperator(text) && myStack.Count >= 2)
                {
                    seccondOp = myStack.Pop();
                    firstOp = myStack.Pop();
                    if(text == "%")
                    {
                        myStack.Push(firstOp);
                    }
                    myStack.Push(calculate(text, firstOp, seccondOp));
                }
                else try
                {
                    string num = myStack.Pop();
                    myStack.Push(calculate(text, num));
                }
                catch (Exception)
                {
                    return "E";
                }
            }
            if(myStack.Count == 1)
            {
                try
                {
                   return myStack.Peek();
                }
                catch (Exception)
                {
                    return "E";
                }
            }
            return "E";
        }
    }
}
