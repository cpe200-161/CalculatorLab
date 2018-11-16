using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class Controller
    {
        CalculatorEngine Engine1;
        RPNCalculatorEngine Engine2;

        public Controller(string str)
        {
            Engine1 = new CalculatorEngine();
            Engine2 = new RPNCalculatorEngine();
        }

        public string calculate(string str)
        {
            return Engine1.calculate(str);
        }

        public string RPNcalculate(string str)
        {
            return Engine2.calculate(str);
        }

    }
}
