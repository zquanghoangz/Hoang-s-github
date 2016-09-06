using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertInfixToPostfixExpression
{
    public class CExpCalculation
    {
        public static string CalculativeExpPostfix(List<string> expPostfix)
        {
            var stack = new List<decimal>();


            foreach (string item in expPostfix)
            {
                int lastIdx = item.Length - 1;
                char ch = item[lastIdx];

                if (char.IsDigit(ch))
                {
                    stack.Add(Convert.ToDecimal(item));
                }
                else if (ch == '+' && stack.Count > 1)
                {
                    stack[stack.Count - 2] += stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
                else if (ch == '-' && stack.Count > 1)
                {
                    stack[stack.Count - 2] -= stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
                else if (ch == '*' && stack.Count > 1)
                {
                    stack[stack.Count - 2] *= stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
                else if (ch == '/' && stack.Count > 1)
                {
                    if (stack[stack.Count - 1] == 0)
                        throw new Exception("Division by Zero");
                    stack[stack.Count - 2] /= stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
            }

            return stack[0].ToString(CultureInfo.InvariantCulture);
        }
    }
}
