using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine:CalculatorEngine
    {
		public new string Process(string str)
		{
			string[] RPNparts = str.Split(' ');
			int ArrLenght = RPNparts.Length;
			if(!isNumber(RPNparts[RPNparts.Length-1]) && RPNparts.Length >= 3)
			{
				for(int i = 0; i<ArrLenght; i++)
				{
					if (isOperator(RPNparts[i + 2]) && isNumber(RPNparts[i]) && isNumber(RPNparts[i + 1]))
					{
						if (ArrLenght == 3)
						{
							return calculate(RPNparts[i + 2], RPNparts[i], RPNparts[i + 1], 4);
						}
						else
						{
							RPNparts[i] = calculate(RPNparts[i + 2], RPNparts[i], RPNparts[i + 1], 4);
							for (int j = i + 1; j < ArrLenght - 2; j++)
							{
								RPNparts[j] = RPNparts[j + 2];
							}
							ArrLenght -= 2;
							i = -1;
						}
					}
				}
			}
			return "E";
		}
    }
}
