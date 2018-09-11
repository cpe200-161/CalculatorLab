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
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            Stack<string> number = new Stack<string>();
            string[] part = str.Split(' ');
            string firstOp;
            string seccondOp;
            
            foreach(string text in part)
            {
                if (isNumber(text))
                {
                    number.Push(text);
                }
                else if(isOperator(text) && number.Count >= 2)
                {
                    seccondOp = number.Pop();
                    firstOp = number.Pop();
                    if(text == "%")
                    {
                        number.Push(firstOp);
                    }
                    number.Push(calculate(text, firstOp, seccondOp));
                }
                else if(isOperator2(text) && number.Count >= 1)
                {
                    string num = number.Pop();
                    number.Push(unaryCalculate(text, num));
                }
                else
                {
                    return "E";
                }
            }
            if(number.Count == 1)
            {
                return number.Peek();
            }
            return "E";
        }
    }
}
