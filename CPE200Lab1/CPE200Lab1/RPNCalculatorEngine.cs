using System;
using System.Collections;
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

            string firstOp, secondOp;
            string[] strArr = str.Split(' ');
            int checkNum = 0;
            int checkOp = 0;
            Stack rpnStack = new Stack();

            if (strArr.Length < 3)
            {
                return "E";
            }
            else if (isNumber(strArr[0]) && strArr[1] == "√")
            {

                return unaryCalculate("√", strArr[0]);
            }
            else if (isNumber(strArr[0]) && strArr[1] == "1/x")
            {

                return unaryCalculate("1/x", strArr[0]);
            }
            else if (isOperator(strArr[1]) || isOperator(strArr[0]) || strArr[1]=="%")

            {
                return "E";
            }
            else
            {
                int i;
                for (i = 0; i < strArr.Length; i++)
                {
                    if (isNumber(strArr[i]))
                    {
                        checkNum++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int x = i; i < strArr.Length; i++)
                {
                    if (isOperator(strArr[i]))
                    { 
                        checkOp++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (checkOp == checkNum|| checkNum< checkOp)
                {
                    return "E";
                }
                else
                {
                    foreach (string s in strArr)
                    {

                        if (isNumber(s))
                        {
                            rpnStack.Push(s);
                        }
                        else 
                        {
                            if(s=="%")
                            {
                                if (rpnStack.Count > 1)
                                {
                                    secondOp = rpnStack.Pop().ToString();
                                firstOp = rpnStack.Pop().ToString();
                                if (firstOp == null || secondOp == null)
                                {
                                    return "E";
                                }
                                secondOp = ((Convert.ToDouble(firstOp) *Convert.ToDouble(secondOp)) / 100).ToString();
                                rpnStack.Push(firstOp);
                                rpnStack.Push(secondOp);
                                }
                                else
                                {
                                    return "E";
                                }
                            }
                            if (isOperator(s) && s != "%")
                            {
                                if (rpnStack.Count > 1)
                                {
                                    secondOp = rpnStack.Pop().ToString();
                                    firstOp = rpnStack.Pop().ToString();
                                    if (firstOp == null || secondOp == null)
                                    {
                                        return "E";
                                    }
                                    rpnStack.Push(calculate(s, firstOp, secondOp));
                                }
                                else
                                {
                                    return "E";
                                }
                            }
                        }
                    }
                }
            }
            if (rpnStack.Count == 1)
            {
                return decimal.Parse(rpnStack.Peek().ToString()).ToString("G29");
            }
            else
            {
                return "E";
            }
        }
    }
}
