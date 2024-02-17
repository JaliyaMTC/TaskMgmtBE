using TaskMgmt.Models;

namespace TaskMgmt.Interfaces.IRepositories
{
    public interface ICommentsRepository
    {
        List<Comments> GetAllComments(int taskId);

        bool CreateNewComment(Comments comment);

        bool UpdateComment(Comments comment);

        bool DeleteComment(int commentId);
    }
}
