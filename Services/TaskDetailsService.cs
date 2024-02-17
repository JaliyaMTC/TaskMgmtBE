using TaskMgmt.Data;
using TaskMgmt.Interfaces.IServices;
using TaskMgmt.Models;
using TaskMgmt.Repositories;

namespace TaskMgmt.Services
{
    public class TaskDetailsService : ITaskDetailsService
    {
        private readonly TaskMgmtContext taskMgmtContext;
        private readonly TaskDetailsRepository taskDetailsRepository;
       
        public TaskDetailsService(TaskMgmtContext taskMgmtContext) {
            this.taskMgmtContext = taskMgmtContext;
            taskDetailsRepository = new TaskDetailsRepository(taskMgmtContext);
         }

        public List<TaskDetails> GetTaskDetailsList()
        {
            return taskDetailsRepository.GetAllTaskDetails();
        }

        public TaskDetails GetTaskDetails(int taskId)
        {
            return taskDetailsRepository.GetTaskDetails(taskId) == null ? new TaskDetails() : taskDetailsRepository.GetTaskDetails(taskId);
        }

        public bool CreateNewTask(TaskDetails taskDetails)
        {
            return taskDetailsRepository.CreateNewTask(taskDetails);
        }

        public bool UpdateTaskDetails(TaskDetails taskDetails)
        {
            return taskDetailsRepository.UpdateTaskDetails(taskDetails);
        }

        public bool DeleteTask(int taskId)
        {
            return taskDetailsRepository.DeleteTask(taskId);
        }
    }
}
