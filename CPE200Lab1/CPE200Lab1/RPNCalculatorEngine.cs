using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        //public  object result;

        public override string Process(string str)
        {
            // your code here
            if(str == null || str == "")
            {
                return "E";
            }
            else
            {

            string[] parts = str.Split(' ');

            Stack<string> operands = new Stack<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    operands.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    if (operands.Count < 2)
                    {
                        return "E";
                    }
                    string op2 = operands.Pop();
                    string op1 = operands.Pop();
                    string result = calculate(parts[i], op1, op2, 4);
                    if (result is "E")
                    {
                        return result;
                      }
                    operands.Push(result);
                }
                else
                    {
                        string NumberOrOperator = parts[i];
                        for(int j = 0;j<NumberOrOperator.Length;j++)
                        {
                            if(isOperator(NumberOrOperator[j].ToString()) && NumberOrOperator[j] != '-')
                            {
                                return "E";
                            }
                        }
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack? 
            if (operands.Count != 1)
            {
                return "E";
            }
            else if (operands.Count == 1)
            {
                    string number = operands.Pop();
                    string NumberReturn = number;

                    for (int i = 0; i<number.Length;i++)
                    {
                        if (isOperator(number[i].ToString()) && number[0] != '-')
                            return "E";
                    }

                    string[] Checktxt = number.Split('.');
                    string Decimals;
                    int Decimalsint;
                    if(Checktxt.Length>1 && isNumber(Checktxt[1]) && Checktxt[1].Length > 4)
                    {
                        Decimals = Checktxt[1].Substring(0, 5);
                        if (Int32.Parse(Decimals[4].ToString())>5)
                        {
                            Decimalsint = Int32.Parse(Checktxt[1].Substring(0, 4));
                            Decimalsint++;
                            Decimals = Decimalsint.ToString();
                        }
                        else
                        {

                        }
                    }
                return operands.Pop();
            }
            catch
            {
                return "E";
            }

            return Convert.ToDouble(result).ToString("0.####");
        }



        /* public override string Display()
         {
             return "doi tomorrow";
         }*/

        /* public override void handleSpace()
         {
             base.handleSpace();
             isNumberPart = false;
         }
             //end old code
             return "E";
         }*/
    }
    
}
