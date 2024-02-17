using TaskMgmt.Models;

namespace TaskMgmt.Interfaces.IServices
{
    public interface ICommentsService
    {
        List<Comments> GetAllComments(int taskId);

        bool CreateNewComment(CommentDto comment);
        bool UpdateComment(CommentDto comment);

        bool DeleteComment(int commentId);
    }
}
