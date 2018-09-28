using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            Stack<string> st = new Stack<string>();
            string[] part = str.Split(' ');
            String sum, n1, n2;

            for (int i = 0; i < part.Length; i++)
            {
                if (isNumber(part[i]))
                {
                    st.Push(part[i]);
                }

                if (isOperator(part[i]))
                {
                    if (st.Count >= 2)
                    {
                        n2 = st.Pop();
                        n1 = st.Pop();
                        sum = calculate(part[i], n1, n2);
                        st.Push(sum);

                    }
                    else
                    {
                        if (part[i] == "√")
                        {
                            n1 = st.Pop();
                            sum = unaryCalculate(part[i], n1);
                            st.Push(sum);
                        }
                        else if (part[i] == "1/x")
                        {
                            n1 = st.Pop();
                            sum = unaryCalculate(part[i], n1);
                            st.Push(sum);
                        }
                        else
                        {
                            return "E";
                        }

                    }

                }


            }
            if (st.Count == 1)
            {
                return st.Peek();
            }
            else
            {
                return "E";
            }
        }
    }
}
