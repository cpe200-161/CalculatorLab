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
				if (isOperator(token))
				{
					try
					{
						if (token == "√" || token == "1/x")
						{
							myStack.Push(unaryCalculate(token, myStack.Pop()));
						}
						else
						{
							string secondOperand = myStack.Pop();
							if (token == "%")
							{
								if (myStack.Count == 0)
								{
									myStack.Push(calculate(token, "1", secondOperand));
								}
								else
								{
									myStack.Push(calculate(token, myStack.Peek(), secondOperand));
								}
							}
							else
								myStack.Push(calculate(token, myStack.Pop(), secondOperand));
						}
					}
					catch (Exception e)
					{
						return "E";
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
