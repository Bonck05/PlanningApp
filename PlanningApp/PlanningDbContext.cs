using Microsoft.EntityFrameworkCore;
using PlanningApp.Models;

namespace PlanningApp
{
    public class PlanningDbContext : DbContext
    {
        public PlanningDbContext(DbContextOptions<PlanningDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.TaskLists)
                .WithOne(tl => tl.User)
                .HasForeignKey(tl => tl.UserId);

            modelBuilder.Entity<TaskList>()
                .HasMany(tl => tl.Tasks)
                .WithOne(ti => ti.TaskList)
                .HasForeignKey(ti => ti.TaskListId);
        }
    }
}
