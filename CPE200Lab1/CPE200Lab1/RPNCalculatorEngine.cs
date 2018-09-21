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
            try
            {
                List<string> withoutspace = parts.ToList<string>();
                withoutspace.RemoveAll(p => string.IsNullOrEmpty(p));
                parts = withoutspace.ToArray();
            }catch(Exception ex)
            {

                return "E";
            }

            for(int i = 0;i < parts.Length ; i++)
            {
                if (isNumber(parts[i]))
                {
                    number.Push(parts[i]);
                }
                if (isOperator(parts[i]))
                {
                    try
                    {
                     string second = number.Pop().ToString();
                     string first = number.Pop().ToString();
                     number.Push(calculate(parts[i],first , second));

                    }catch (Exception ex)
                    {
                        return "E";
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
