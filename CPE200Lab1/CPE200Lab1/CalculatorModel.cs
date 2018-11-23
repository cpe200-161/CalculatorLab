using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorModel : Model
    {
        protected string lblDisplay;
        protected string firstOperand;
        protected string operate;
        protected string memory;
        protected bool isOperClicked;
        protected bool hasDot;
        protected basicCalculatorEngine engine;

        public CalculatorModel()
        {
            engine = new CalculatorEngine();
            resetAll();
        }

        public bool isError()
        {
            return lblDisplay == "Error";
        }

        public void resetAll()
        {
            firstOperand = null;
            operate = null;
            isOperClicked = false;
            hasDot = false;
            lblDisplay = "0";
        }

        protected bool isSetFirstOperand()
        {
            return firstOperand != null;
        }

        public string GetDisplay()
        {
            return lblDisplay;
        }

        public void PerformBtnNumber(string num)
        {
            if (isError())
            {
                return;
            }
            if (lblDisplay == "0" || isOperClicked)
            {
                lblDisplay = "";
                isOperClicked = false;
                hasDot = false;
            }
            if (lblDisplay.Length < 8)
            {
                lblDisplay += num;
            }
            NotifyAll();
        }

        public void PerformModifyMemory(string oper)
        {
            if (isError())
            {
                return;
            }
            if (memory == null)
            {
                memory = "0";
            }
            memory = engine.calculate(oper, memory, lblDisplay);
            isOperClicked = true;
        }

        public void PerformMemoryRecall()
        {
            if (memory == null)
            {
                return;
            }
            lblDisplay = memory;
            NotifyAll();
        }

        public void PerformMemoryClear()
        {
            memory = null;
        }

        public void PerformOperate(string oper)
        {
            operate = oper;
            if (isOperClicked || isError())
            {
                return;
            }
            if (!isSetFirstOperand())
            {
                firstOperand = lblDisplay;
            }
            else
            {
                PerformEqual();
            }
            isOperClicked = true;
        }

        public void PerformEqual()
        {
            if (operate == null || isError())
            {
                return;
            }
            firstOperand = engine.calculate(operate, firstOperand, lblDisplay);
            if (firstOperand.Length > 8)
            {
                firstOperand = "Error";
            }
            lblDisplay = firstOperand;
            NotifyAll();
        }

        public void PerformClear()
        {
            resetAll();
            NotifyAll();
        }

        public void PeformDot()
        {
            if (hasDot || isError())
            {
                return;
            }
            lblDisplay += ".";
            hasDot = true;
            NotifyAll();
        }

        public void PerFormSign()
        {
            if (isError())
            {
                return;
            }
            lblDisplay = engine.calculate("X", lblDisplay, "-1");
            NotifyAll();
        }

        public void PerformUnary(string unary)
        {
            if (isError())
            {
                return;
            }
            lblDisplay = engine.calculate(unary, lblDisplay);
            NotifyAll();
        }

        public void PerformPercent()
        {
            if (isError())
            {
                return;
            }
            if (isSetFirstOperand())
            {
                lblDisplay = engine.calculate("%", firstOperand, lblDisplay);
            }
            else
            {
                PerformUnary("%");
            }
            NotifyAll();
        }

        public void PerformBack()
        {
            if (isOperClicked || isError())
            {
                return;
            }
            if (lblDisplay != "0")
            {
                if (lblDisplay[lblDisplay.Length - 1] == '.')
                {
                    hasDot = false;
                }
                lblDisplay = lblDisplay.Substring(0, lblDisplay.Length - 1);
                if (lblDisplay == "" || lblDisplay == "-")
                {
                    lblDisplay = "0";
                }
                NotifyAll();
            }
        }


    }
}