using System;

namespace CPE200Lab1
{
    internal class ExtendFromControler
    {
    private RPNCalculatorEngine engine; 
    public bool isNumberPart = false;
    public bool isContainDot = false;
    public bool isSpaceAllowed = false;

        public ExtendFromControler()
        {
            engine = new RPNCalculatorEngine();
        }

        private bool isOperator(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case 'X':
                case '÷':
                case '%':
                case '√':
                case 'i':
                    return true;
            }
            return false;
        }

        internal string clickNum(string input , string text)
        {   isSpaceAllowed = true;
            string result;
            if (text is "Error")
            {
                return "Error";
            }

            if (text is "0")
            {
                return input;
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            result = text + input;
            

            return result;
        }

        internal string clickEqual(string Text)
        {
            string result = engine.Process(Text);
            if (result is "E")
            {
                return "Error";
            }
            else
            {
                return result;
            }
            
        }

        internal string clickDot(string Text)
        {
            if (Text is "Error")
            {
                return "Error";
            }
            if (!isContainDot)
            {
                isContainDot = true;
                Text += ".";
                isSpaceAllowed = false;
            }
            return Text;
        }

        internal string clickSpace(string Text)
        {
            if (Text is "Error")
            {
                return "Error";
            }

            if (isSpaceAllowed)
            {
                Text += " ";
                isSpaceAllowed = false;
            }
            return Text;
        }

        internal string clickSing(string Text)
        {
            if (Text is "Error")
            {
                return "";
            }
            if (isNumberPart)
            {
                return "";
            }
            string current = Text;
            if (current is "0")
            {
                return "-";
            }
            else if (current[current.Length - 1] is '-')
            {
                Text = current.Substring(0, current.Length - 1);
                if (Text is "")
                {
                    return  "0";
                }
            }
            else
            {
                return  current + "-";
            }
            isSpaceAllowed = false;
            return Text;
        }

        internal string clickBack(string Text)
        {
            if (Text is "Error")
            {
                return "Error";
            }
            // check if the last one is operator
            string current = Text;
            if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
            {
                Text = current.Substring(0, current.Length - 3);
            }
            else
            {
               Text = current.Substring(0, current.Length - 1);
            }
            if (Text is "")
            {
                Text = "0";
            }
            return Text;
        }

        internal string clickClear()
        {
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
            return "0";
        }

        internal string clickBinaryOperator(string input , string Text)
        {
            if (Text is "Error")
            {
                return "Error";
            }
            isNumberPart = false;
            isContainDot = false;

            string current = Text;
            if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2]))
            {
                Text += " " + input + " ";
                isSpaceAllowed = false;
            }
            return Text;
        }
    }
}