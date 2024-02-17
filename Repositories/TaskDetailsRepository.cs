using Microsoft.EntityFrameworkCore;
using TaskMgmt.Data;
using TaskMgmt.Interfaces.IRepositories;
using TaskMgmt.Models;

namespace TaskMgmt.Repositories
{
    public class TaskDetailsRepository : ITaskDetailsRepository

    {
        private readonly TaskMgmtContext taskMgmtContext;
        public TaskDetailsRepository(TaskMgmtContext taskMgmtContext) { 
            this.taskMgmtContext = taskMgmtContext;
        }

        public List<TaskDetails> GetAllTaskDetails() {

            List<TaskDetails> result = new List<TaskDetails>();
            result = this.taskMgmtContext.TaskDetails
                .AsNoTracking()
                .ToList();
            return result;
        }
        
        public TaskDetails GetTaskDetails(int taskId) {

            var result = this.taskMgmtContext.TaskDetails
                .AsNoTracking()
                .Where(f => f.TaskId == taskId).FirstOrDefault();
            return result;
        }

        public bool CreateNewTask(TaskDetails taskDetails) {

            var result = this.taskMgmtContext.Attach(taskDetails);
            result.State = EntityState.Added;
            this.taskMgmtContext.SaveChanges();
            return true;
        }
        
        public bool UpdateTaskDetails(TaskDetails taskDetails) {

            var result = this.taskMgmtContext.Entry(taskDetails);
            result.State = EntityState.Modified;
            this.taskMgmtContext.SaveChanges();
            return true;
        }

        public bool DeleteTask(int taskId)
        {

            var result = this.taskMgmtContext.TaskDetails
                .AsNoTracking()
                .Where(f => f.TaskId == taskId).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            this.taskMgmtContext.Remove(result);
            this.taskMgmtContext.SaveChanges();
            return true;
        }
    }
}
