public class MinStack {

    private readonly Stack<int> valuesStack = new Stack<int>();
    private readonly Stack<int> minValueStack = new Stack<int>();
    
    public void Push(int val)
    {
        this.valuesStack.Push(val);

        int newMin;
        if (this.minValueStack.Any())
        {
            newMin = Math.Min(this.minValueStack.Peek(), val);
        }
        else
        {
            newMin = val;
        }

        this.minValueStack.Push(newMin);
    }
    
    public void Pop()
    {
        this.valuesStack.Pop();
        this.minValueStack.Pop();
    }
    
    public int Top()
    {
        return this.valuesStack.Peek();
    }
    
    public int GetMin()
    {
        return this.minValueStack.Peek();
    }
}
