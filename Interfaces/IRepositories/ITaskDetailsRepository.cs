using TaskMgmt.Models;

namespace TaskMgmt.Interfaces.IRepositories
{
    public interface ITaskDetailsRepository
    {
        List <TaskDetails> GetAllTaskDetails();

        TaskDetails GetTaskDetails(int taskId);

        bool CreateNewTask(TaskDetails taskDetails);
        bool UpdateTaskDetails(TaskDetails taskDetails);
    }
}
