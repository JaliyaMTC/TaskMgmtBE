using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMgmt.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string Comment { get; set; }

        [ForeignKey("TaskId")]
        public TaskDetails? TaskDetails { get; set; }
    }
}
