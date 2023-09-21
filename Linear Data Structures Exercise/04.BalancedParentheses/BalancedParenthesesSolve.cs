namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;
  

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (string.IsNullOrWhiteSpace(parentheses) || parentheses.Length % 2 == 1)
            {
                return false;
            }
            Stack<char> stack = new Stack<char>(parentheses.Length / 2);
            foreach (char item in parentheses)
            {
                char currentValueToSearch = default;
                if (item == ')')
                {
                    currentValueToSearch = '(';
                }
                else if (item == ']')
                {
                    currentValueToSearch = '[';
                }
                else if (item == '}')
                {
                    currentValueToSearch = '{';
                }
                else
                {
                    stack.Push(item);
                    continue;
                }
                if (stack.Pop() != currentValueToSearch)
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }
    }
}
