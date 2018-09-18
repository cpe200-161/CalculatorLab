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
			Stack<string> temp = new Stack<string>();
			string[] parts = str.Split(' ');
			bool beforeOperate = false;

			foreach(string num in parts)
			{
				if (isNumber(num))
				{
					temp.Push(num);
					
				}
				if (isOperator(num))
				{
					string first, second;
					if (temp.Count < 2) return "E";
					second = temp.Pop();
					first = temp.Pop();
					temp.Push(calculate(num, first, second));
					beforeOperate = true;
				}
				if (is_exOperator(num))
				{
					string first;
					if (temp.Count < 1) return "E";
					first = temp.Pop();
					temp.Push(unaryCalculate(num, first));
					beforeOperate = true;
				}
			}
			if(temp.Count > 1||beforeOperate == false) return "E";
			return temp.Pop();

		}
	}
}
