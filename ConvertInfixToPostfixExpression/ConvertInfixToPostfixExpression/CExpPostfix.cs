using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConvertInfixToPostfixExpression
{
    public class CExpPostfix
    {
        #region Expression spliting

        public static List<string> ExpSplit(string inputExp)
        {
            var outputs = new List<string>();
            ExpSplitElement(inputExp.Replace(" ", string.Empty), outputs);
            return outputs;
        }

        private static void ExpSplitElement(string inputExp, List<string> outputs)
        {
            if (!inputExp.Contains('(') && !inputExp.Contains(')') &&
                !inputExp.Contains('+') && !inputExp.Contains('-') &&
                !inputExp.Contains('*') && !inputExp.Contains('/'))
            {
                outputs.Add(inputExp);
                return;
            }

            for (int i = 0; i < inputExp.Length; i++)
            {
                if (!("()+-*/").Contains(inputExp[i]))
                {
                    continue;
                }

                if (i == 0 && inputExp[i] == '-') //case 4*(-5)
                {
                    continue;
                }

                if (i > 0)
                {
                    outputs.Add(inputExp.Substring(0, i));
                }

                outputs.Add(inputExp[i].ToString(CultureInfo.InvariantCulture));

                if (i < inputExp.Length - 1)
                    ExpSplitElement(inputExp.Substring(i + 1), outputs);

                break;
            }
        }

        #endregion

        private static void CreateNextStep(List<string> expSplited, int idx, List<char> stack, List<string> output)
        {
            if (idx < 0 || idx > expSplited.Count)
            {
                return;
            }

            //Take all last item in stack
            if (idx == expSplited.Count && stack.Count > 0)
            {
                do
                {
                    output.Add(stack[stack.Count - 1].ToString(CultureInfo.InvariantCulture));
                    stack.RemoveAt(stack.Count - 1);
                } while (stack.Count > 0);

                return;
            }

            //Do step
            int lastIdx = expSplited[idx].Length - 1;
            char ch = expSplited[idx][lastIdx];

            if (char.IsDigit(ch))
            {
                output.Add(expSplited[idx]);
            }
            else if (("+-*/").Contains(ch) &&
                (stack.Count == 0 || LevelOf(ch) > LevelOf(stack[stack.Count - 1])))
            {
                stack.Add(expSplited[idx][0]);
            }
            else if (("+-*/").Contains(ch) && LevelOf(ch) <= LevelOf(stack[stack.Count - 1]))
            {
                do
                {
                    output.Add(stack[stack.Count - 1].ToString(CultureInfo.InvariantCulture));
                    stack.RemoveAt(stack.Count - 1);
                } while (stack.Count > 0 && LevelOf(ch) <= LevelOf(stack[stack.Count - 1]));

                stack.Add(expSplited[idx][0]);
            }
            else if (ch == '(')
            {
                stack.Add(ch);
            }
            else if (ch == ')')
            {
                while (stack[stack.Count - 1] != '(')
                {
                    output.Add(stack[stack.Count - 1].ToString(CultureInfo.InvariantCulture));
                    stack.RemoveAt(stack.Count - 1);
                }
                stack.RemoveAt(stack.Count - 1);
            }
        }

        public static void CreateStackOutput(List<string> expSplited, List<string> outStack, List<string> outOutput)
        {
            var stack = new List<char>();
            var output = new List<string>();

            for (int i = 0; i <= expSplited.Count; i++)
            {
                CreateNextStep(expSplited, i, stack, output);

                outStack.Add(ListToString(stack));
                outOutput.Add(ListToString(output));
            }
        }

        public static List<string> CreateExpPostfix(List<string> expSplited)
        {
            var stack = new List<char>();
            var output = new List<string>();

            for (int i = 0; i <= expSplited.Count; i++)
            {
                CreateNextStep(expSplited, i, stack, output);
            }

            return output;
        }

        private static int LevelOf(char ch)
        {
            switch (ch)
            {
                case '-':
                case '+':
                    return 0;
                case '/':
                case '*':
                    return 1;
            }

            return -1;
        }

        public static string ListToString(List<string> list)
        {
            return string.Join(" ", list.ToArray());
        }

        public static string ListToString(List<char> list)
        {
            return string.Join(" ", list.ToArray());
        }
    }
}
