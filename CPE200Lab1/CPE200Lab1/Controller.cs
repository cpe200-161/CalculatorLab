using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class Controller
    {
        CalculatorEngine Engine1;
        RPNCalculatorEngine Engine2;
        public Controller()
        {
            Engine1 = new CalculatorEngine();
            Engine2 = new RPNCalculatorEngine();
        }

        public string RPNcalculate(string str)
        {
            return Engine2.calculate(str);
        }
        public string Calculate(string str)
        {
            return Engine1.calculate(str);
        }
    }
}