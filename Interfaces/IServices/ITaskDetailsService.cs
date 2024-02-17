using TaskMgmt.Models;

namespace TaskMgmt.Interfaces.IServices
{
    public interface ITaskDetailsService
    {
        List<TaskDetails> GetTaskDetailsList();

        TaskDetails GetTaskDetails(int taskId);

        bool CreateNewTask(TaskDetails taskDetails);

        bool UpdateTaskDetails(TaskDetails taskDetails);

        bool DeleteTask(int taskId);
    }
}
