using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class Controller
    {
        TheCalculatorEngine Engine1;
        RPNCalculatorEngine Engine2;

        public Controller()
        {
            Engine1 = new TheCalculatorEngine();
            Engine2 = new RPNCalculatorEngine();

        }

        public string Calculate(string str)
        {
            return Engine1.Calculate(str);
        }
        public string RPNCalculate(string str)
        {
            return Engine2.Calculate(str);
        }
    }
}
