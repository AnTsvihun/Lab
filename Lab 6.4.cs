using System;
using System.Collections.Generic;
using System.Linq;

public class TaskScheduler<TTask, TPriority>
{
    public delegate void TaskExecution(TTask task);

    private readonly SortedDictionary<TPriority, Queue<TTask>> taskQueue = new SortedDictionary<TPriority, Queue<TTask>>();
    private readonly Func<TTask, TPriority> getPriority;
    private readonly Func<TTask> getObjectFromPool;
    private readonly Action<TTask> returnObjectToPool;

    public TaskScheduler(Func<TTask, TPriority> priorityFunction, Func<TTask> objectCreationFunction, Action<TTask> objectReturnAction)
    {
        getPriority = priorityFunction ?? throw new ArgumentNullException(nameof(priorityFunction));
        getObjectFromPool = objectCreationFunction ?? throw new ArgumentNullException(nameof(objectCreationFunction));
        returnObjectToPool = objectReturnAction ?? throw new ArgumentNullException(nameof(objectReturnAction));
    }

    public void AddTask(TTask task)
    {
        TPriority priority = getPriority(task);
        if (!taskQueue.ContainsKey(priority))
        {
            taskQueue[priority] = new Queue<TTask>();
        }
        taskQueue[priority].Enqueue(task);
    }

    public void ExecuteNext(TaskExecution executionDelegate)
    {
        if (taskQueue.Count == 0)
        {
            Console.WriteLine("No tasks to execute.");
            return;
        }

        var highestPriority = taskQueue.Keys.Last();
        var taskToExecute = taskQueue[highestPriority].Dequeue();

        Console.WriteLine($"Executing task with priority {highestPriority}");
        executionDelegate(taskToExecute);

        if (!taskQueue[highestPriority].Any())
        {
            taskQueue.Remove(highestPriority);
        }
    }

    public TTask GetObjectFromPool()
    {
        return getObjectFromPool();
    }

    public void ReturnObjectToPool(TTask task)
    {
        returnObjectToPool(task);
    }
}

class Program
{
    static void Main()
    {
        TaskScheduler<string, int> taskScheduler = new TaskScheduler<string, int>(
            priorityFunction: s => s.Length,
            objectCreationFunction: () => Guid.NewGuid().ToString(),
            objectReturnAction: Console.WriteLine
        );

        taskScheduler.AddTask("Task 1");
        taskScheduler.AddTask("Task 2");

        taskScheduler.ExecuteNext(Console.WriteLine);

        var pooledObject = taskScheduler.GetObjectFromPool();
        Console.WriteLine($"Pooled Object: {pooledObject}");

        taskScheduler.ReturnObjectToPool(pooledObject);
    }
}
