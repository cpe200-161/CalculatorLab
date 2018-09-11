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
							myStack.Push(unaryCalculate(token, myStack.Pop()));
							break;
						case "1/x":
							myStack.Push(unaryCalculate(token, myStack.Pop()));
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
