using Microsoft.AspNetCore.Mvc;
using TaskMgmt.Models;
using TaskMgmt.Interfaces.IServices;

namespace TaskMgmt.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
      
        private readonly ITaskDetailsService taskDetailsService;
        public TaskController(ITaskDetailsService taskDetailsService)
        {
   
            this.taskDetailsService = taskDetailsService;
        }

        [HttpGet]
        [Route("all")]
        public List<TaskDetails> GetTaskList()
        {
            return taskDetailsService.GetTaskDetailsList();
        }

        [HttpGet]
        [Route("{taskId}")]
        public TaskDetails GetTaskDetails(int taskId)
        {
            return taskDetailsService.GetTaskDetails(taskId);
        }

        [HttpPost]
        [Route("create")]
        public bool CreateNewTask(TaskDetails taskDetails)
        {
            return taskDetailsService.CreateNewTask(taskDetails);
        }

        [HttpPut]
        [Route("update")]
        public bool UpdateTaskDetails(TaskDetails taskDetails)
        {
            return taskDetailsService.UpdateTaskDetails(taskDetails);
        }

        [HttpDelete]
        [Route("delete/{taskId}")]
        public bool DeleteTask(int taskId)
        {
            return taskDetailsService.DeleteTask(taskId);
        }

    }
}