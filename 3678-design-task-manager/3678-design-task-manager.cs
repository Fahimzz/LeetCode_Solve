public class TaskManager
{
    private Dictionary<int, int> taskToPriority = new();


    private Dictionary<int, int> taskToUser = new();
    private PriorityQueue<(int taskId, int priority), (int negPriority, int negTaskId)>
        taskToPriorityQueue = new();

    public TaskManager(IList<IList<int>> tasks)
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            int userId   = tasks[i][0];
            int taskId   = tasks[i][1];
            int priority = tasks[i][2];

            taskToPriority[taskId] = priority;
            taskToUser[taskId] = userId;

            taskToPriorityQueue.Enqueue((taskId, priority), (-priority, -taskId));
        }
    }

    public void Add(int userId, int taskId, int priority)
    {
        taskToPriority[taskId] = priority;
        taskToUser[taskId] = userId;
        taskToPriorityQueue.Enqueue((taskId, priority), (-priority, -taskId));
    }

    public void Edit(int taskId, int newPriority)
    {
        taskToPriority[taskId] = newPriority;

        taskToPriorityQueue.Enqueue((taskId, newPriority), (-newPriority, -taskId));
    }


    public void Rmv(int taskId)
    {
        taskToPriority.Remove(taskId);
        taskToUser.Remove(taskId);
    }

    public int ExecTop()
    {
        while (taskToPriorityQueue.Count > 0)
        {
            var (taskId, priority) = taskToPriorityQueue.Dequeue();

            if (!taskToPriority.ContainsKey(taskId))
                continue;

            int correctPriority = taskToPriority[taskId];
            if (priority != correctPriority)
                continue;

            int userId = taskToUser[taskId];
            Rmv(taskId);
            return userId;
        }

        return -1;
    }
}

