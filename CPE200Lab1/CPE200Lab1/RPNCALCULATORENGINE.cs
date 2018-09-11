using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCALCULATORENGINE : CalculatorEngine
    {
      

        public override string Process(string str)
        {
            string[] parts = str.Split(' ');
            Stack<string> operands = new Stack<string>();
            
            if (!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
            {
                return "E";
            }
            else
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }

        }
    }

}
