using Microsoft.AspNetCore.Mvc;
using TaskMgmt.Interfaces.IServices;
using TaskMgmt.Models;
using TaskMgmt.Services;

namespace TaskMgmt.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpGet]
        [Route("{taskId}")]
        public List < Comments > GetAllComments(int taskId)
        {
            return commentsService.GetAllComments(taskId);
        }

        [HttpPost]
        [Route("create")]
        public bool CreateNewComment(CommentDto comments)
        {
            return commentsService.CreateNewComment(comments);
        }

        [HttpPut]
        [Route("update")]
        public bool UpdateComment(CommentDto comments)
        {
            return commentsService.UpdateComment(comments);
        }


        [HttpDelete]
        [Route("delete/{commentId}")]
        public bool DeleteComment(int commentId)
        {
            return commentsService.DeleteComment(commentId);
        }
    }
}
