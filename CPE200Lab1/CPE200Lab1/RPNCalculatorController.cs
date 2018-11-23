using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorController : Controller
    {

        public void NumberPerform(string num) => ((RPNCalculatorModel)m).PerformNumber(num);

        public void DotPerform() => ((RPNCalculatorModel)m).PerformDot();

        public void SpacePerform() => ((RPNCalculatorModel)m).PerformSpace();

        public void OperPerform(string oper) => ((RPNCalculatorModel)m).PerformOperator(oper);

        public void EqualPerform(string str) => ((RPNCalculatorModel)m).PerformEqual(str);

        public void ClearPerform() => ((RPNCalculatorModel)m).PerformClear();

        public void BackPerform() => ((RPNCalculatorModel)m).PerformBack();
    }
}