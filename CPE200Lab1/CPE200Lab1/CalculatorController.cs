using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorController : Controller
    {
        public void BtnNumberPerform(string num)
        {
            ((CalculatorModel)m).PerformBtnNumber(num);
        }

        public void OperatorPerform(string oper)
        {
            ((CalculatorModel)m).PerformOperate(oper);
        }

        public void EqualPerform()
        {
            ((CalculatorModel)m).PerformEqual();
        }

        public void ClearPerform()
        {
            ((CalculatorModel)m).PerformClear();
        }

        public void DotPerform()
        {
            ((CalculatorModel)m).PeformDot();
        }

        public void SignPerform()
        {
            ((CalculatorModel)m).PerFormSign();
        }

        public void UnaryPerform(string unary)
        {
            ((CalculatorModel)m).PerformUnary(unary);
        }

        public void PercentPerform()
        {
            ((CalculatorModel)m).PerformPercent();
        }

        public void BackPerform()
        {
            ((CalculatorModel)m).PerformBack();
        }

        public void ModifyMemory(string oper)
        {
            ((CalculatorModel)m).PerformModifyMemory(oper);
        }

        public void RecallMemoryPeform()
        {
            ((CalculatorModel)m).PerformMemoryRecall();
        }

        public void ClearMemoryPerform()
        {
            ((CalculatorModel)m).PerformMemoryClear();
        }
    }
}