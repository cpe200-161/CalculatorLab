using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine 
    {
        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            Stack number = new Stack();

            List<string> withoutspace = parts.ToList<string>();
            withoutspace.RemoveAll(p => string.IsNullOrEmpty(p));
            parts = withoutspace.ToArray();

            if(isNumber(parts[0]) && isOperator(parts[1]))
            {
                return "E";
            }
            else
            {
            for(int i = 0;i < parts.Length ; i++)
            {
                if (isNumber(parts[i]))
                {
                    number.Push(parts[i]);
                }
                if (isOperator(parts[i]))
                {
                    if(number.Count < 2)
                    {
                        return "E";
                    }else
                    {
                        string second = number.Pop().ToString();
                        string first = number.Pop().ToString();
                        number.Push(calculate(parts[i],first , second));
                    }
                }
            }
            if(number.Count > 1)
                {
                    return "E";
                }
            return number.Pop().ToString();

            }



        }
    }
}
