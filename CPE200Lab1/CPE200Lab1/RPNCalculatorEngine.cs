using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine:TheCalculatorEngine
    {
		private Stack<string> myStack;
		public string calculate(string oper)
		{
			string[] RPNparts = oper.Split(' ');
			myStack = new Stack<string>();
			foreach (string token in RPNparts)
			{
				if (isNumber(token))
				{
					myStack.Push(token);
				}
				else if (isOperator(token))
				{
					if (myStack.Count < 2)
					{
						return "E";
					}
					switch (token)
					{
						case "+":
						case "-":
						case "X":
						case "÷":
							string secondOperand = myStack.Pop();
							myStack.Push(calculate(token, myStack.Pop(), secondOperand));
							break;
						case "%":
							secondOperand = myStack.Pop();
							myStack.Push(calculate(token, myStack.Peek(), secondOperand));
							break;
						case "√":
							myStack.Push(calculate(token, myStack.Pop()));
							break;
						case "1/x":
							myStack.Push(calculate(token, myStack.Pop()));
							break;
					}
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
