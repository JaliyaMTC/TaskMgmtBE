using System.ComponentModel.Design;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskMgmt.Data;
using TaskMgmt.Interfaces.IRepositories;
using TaskMgmt.Models;

namespace TaskMgmt.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly TaskMgmtContext taskMgmtContext;

        public CommentsRepository(TaskMgmtContext taskMgmtContext)
        {
            this.taskMgmtContext = taskMgmtContext;
        }

        public List<Comments> GetAllComments(int taskId)
        {

            var result = this.taskMgmtContext.Comments
                .AsNoTracking()
                .Where(f => f.TaskDetails != null && f.TaskDetails.TaskId == taskId).ToList();
            return result;
        }

        public bool CreateNewComment(Comments comment)
        {
            var result = this.taskMgmtContext.Attach(comment);
            result.State = EntityState.Added;
            this.taskMgmtContext.SaveChanges();
            return true;
        } 
        
        public bool UpdateComment(Comments comment)
        {
            var result = this.taskMgmtContext.Entry(comment);
            result.State = EntityState.Modified;
            this.taskMgmtContext.SaveChanges();
            return true;
        }

        public bool DeleteComment(int commentId)
        {
            var result = this.taskMgmtContext.Comments
            .AsNoTracking()
                .Where(f => f.CommentId == commentId).FirstOrDefault();
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

