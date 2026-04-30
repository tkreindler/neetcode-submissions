#nullable enable

public class Solution {
    public int LeastInterval(char[] tasks, int n)
    {
        // get frequencies
        var frequencyDictionary = new Dictionary<char, int>(26);
        foreach (char task in tasks)
        {
            ref int countRef = ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrAddDefault(frequencyDictionary, task, out _);
            countRef += 1;
        }

        int numTasks = frequencyDictionary.Count;

        // put them in a max heap so the most frequent bubble up first
        var maxHeap = new PriorityQueue<TaskInfo, int>(frequencyDictionary.Count, Comparer<int>.Create(static (x, y) => y.CompareTo(x)));
        foreach ((char task, int count) in frequencyDictionary)
        {
            var taskInfo = new TaskInfo
            {
                TaskLetter = task,
                Count = count,
            };
            maxHeap.Enqueue(taskInfo, taskInfo.Count);
        }

        // a bench where tasks we just used go to cool off, only usable tasks go in the heap
        var coolingBench = new Queue<(int readyCycle, TaskInfo task)>(n);

        int cycle = 0;
        for (; maxHeap.Count > 0 || coolingBench.Count > 0; cycle++)
        {
            // add anything that's ready from the cooling bench to the heap
            while (coolingBench.Count > 0 &&
                   coolingBench.Peek().readyCycle <= cycle)
            {
                (_, TaskInfo task) = coolingBench.Dequeue();
                maxHeap.Enqueue(task, task.Count);
            }

            {
                // grab the next item from the heap
                if (maxHeap.TryDequeue(out TaskInfo task, out int priority))
                {
                    task.Count -= 1;

                    if (task.Count > 0)
                    {
                        // used this task but I need to use it again, add it to the cooling bench
                        coolingBench.Enqueue((readyCycle: cycle + n + 1, task));
                    }
                }
            }
        }

        return cycle;
    }

    private class TaskInfo
    {
        required public char TaskLetter { get; init; }
        required public int Count { get; set; }
    }
}
