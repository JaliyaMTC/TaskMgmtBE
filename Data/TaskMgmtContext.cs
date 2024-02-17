using Microsoft.EntityFrameworkCore;
using TaskMgmt.Models;

namespace TaskMgmt.Data
{
    public class TaskMgmtContext: DbContext
    {
        public TaskMgmtContext(DbContextOptions<TaskMgmtContext> options) : base(options)
        {
        }

        public DbSet<TaskDetails> TaskDetails { get; set; } = null!;

        public DbSet<Comments>? Comments { get; set; } = null!;
    }
}
