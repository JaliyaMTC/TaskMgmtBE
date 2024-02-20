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
        private readonly CommentsRepository commentsRepository;
        public TaskDetailsService(TaskMgmtContext taskMgmtContext) {
            this.taskMgmtContext = taskMgmtContext;
            taskDetailsRepository = new TaskDetailsRepository(taskMgmtContext);
            commentsRepository = new CommentsRepository(taskMgmtContext);
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

            var result = true;
            using var transaction = taskMgmtContext.Database.BeginTransaction();

            try
            {
                var comments = commentsRepository.GetAllComments(taskId);

                if ((null != comments) && (comments.Count() > 0))
                {
                    foreach (var comment in comments)
                    {
                        if (result)
                        {
                            result = commentsRepository.DeleteComment(comment.CommentId);
                            if (!result) break;
                        }
                    }
                }
                if (result)
                {
                    result = taskDetailsRepository.DeleteTask(taskId);
                }
                if (result)
                {
                    transaction.Commit();
                    return true;
                }
                else
                {
                    transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            return false;
        }
    }
}
