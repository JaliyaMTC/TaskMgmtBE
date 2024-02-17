using System.ComponentModel.DataAnnotations;

namespace TaskMgmt.Models
{
    public class TaskDetails
    {
        [Key]
        public int TaskId { get; set; }

        public DateTime? DueDate { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }

        public bool? IsCompleted { get; set; }

    }
}
