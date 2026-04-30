public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>(2);

        foreach (string token in tokens)
        {
            switch (token)
            {
                case "+":
                {
                    int value2 = stack.Pop();
                    int value1 = stack.Pop();
                    int value = value1 + value2;
                    stack.Push(value);
                }
                    break;

                case "-":
                {
                    int value2 = stack.Pop();
                    int value1 = stack.Pop();
                    int value = value1 - value2;
                    stack.Push(value);
                }
                    break;
                case "*":
                {
                    int value2 = stack.Pop();
                    int value1 = stack.Pop();
                    int value = value1 * value2;
                    stack.Push(value);
                }
                    break;
                    
                case "/":
                {
                    int value2 = stack.Pop();
                    int value1 = stack.Pop();
                    int value = value1 / value2;
                    stack.Push(value);
                }
                    break;

                default:
                {
                    int value = int.Parse(token);
                    stack.Push(value);
                }
                    break;
            }
        }

        return stack.Pop();
    }
}
