using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine:CalculatorEngine
    {
		public string Process(string str)
		{
			string[] RPNparts = str.Split(' ');
			Stack<string> myStack = new Stack<string>();
			foreach (string token in RPNparts)
			{
				if (isNumber(token))
				{
					myStack.Push(token);
				}
				else if(isOperator(token))
				{
					if (myStack.Count < 2)
					{
						return "E";
					}
					string secondOperand = myStack.Pop();
					myStack.Push(calculate(token, myStack.Pop(), secondOperand));
				}
			}
			if (myStack.Count == 1)
			{
				return myStack.Pop();
			}
			return "E";
		}
    }
}
