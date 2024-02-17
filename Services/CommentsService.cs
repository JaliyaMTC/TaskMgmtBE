using System.Threading.Tasks;
using System.Xml.Linq;
using TaskMgmt.Data;
using TaskMgmt.Interfaces.IServices;
using TaskMgmt.Models;
using TaskMgmt.Repositories;

namespace TaskMgmt.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly TaskMgmtContext taskMgmtContext;
        private readonly CommentsRepository commentsRepository;
        private readonly TaskDetailsRepository taskDetailsRepository;

        public CommentsService(TaskMgmtContext taskMgmtContext)
        {
            this.taskMgmtContext = taskMgmtContext;
            commentsRepository = new CommentsRepository(taskMgmtContext);
            taskDetailsRepository = new TaskDetailsRepository(taskMgmtContext);
        }

        public List<Comments> GetAllComments(int taskId)
        {
            return commentsRepository.GetAllComments(taskId);
        }

        public bool CreateNewComment(CommentDto comment)
        {
            TaskDetails taskDetails = taskDetailsRepository.GetTaskDetails(comment.TaskId);
            if (taskDetails == null)
            {
                return false;
            }
            Comments comments = new Comments()
            {
                CommentId = comment.CommentId,
                Comment = comment.Comment,
                TaskDetails = taskDetails
            };
            return commentsRepository.CreateNewComment(comments);
        } 
        
        public bool UpdateComment(CommentDto comment)
        {
            TaskDetails taskDetails = taskDetailsRepository.GetTaskDetails(comment.TaskId);
            if (taskDetails == null)
            {
                return false;
            }
            Comments comments = new Comments()
            {
                CommentId = comment.CommentId,
                Comment = comment.Comment,
                TaskDetails = taskDetails
            };
            return commentsRepository.UpdateComment(comments);
        }

        public bool DeleteComment(int commentId)
        {
            return commentsRepository.DeleteComment(commentId);
        }
    }
}
