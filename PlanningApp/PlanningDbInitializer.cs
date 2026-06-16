using PlanningApp.Models;

namespace PlanningApp
{
    public class PlanningDbInitializer
    {
        public static void Initialize(PlanningDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User { Name = "Alice", Email = "alice@example.com", PasswordHash = "hash1" },
                new User { Name = "Bob", Email = "bob@example.com", PasswordHash = "hash2" }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            var taskLists = new TaskList[]
            {
                new TaskList { Title = "Alice's Tasks", UserId = users[0].Id },
                new TaskList { Title = "Bob's Tasks", UserId = users[1].Id }
            };

            foreach (var taskList in taskLists)
            {
                context.TaskLists.Add(taskList);
            }
            context.SaveChanges();

            var taskItems = new TaskItem[]
            {
                new TaskItem { Title = "Groceries", Description = "Buy groceries", IsCompleted = false, DueDate = DateTime.Now.AddDays(1), TaskListId = taskLists[0].Id },
                new TaskItem { Title = "Report", Description = "Finish project report", IsCompleted = false, DueDate = DateTime.Now.AddDays(2), TaskListId = taskLists[0].Id },
                new TaskItem { Title = "Plumber", Description = "Call plumber", IsCompleted = false, DueDate = DateTime.Now.AddDays(3), TaskListId = taskLists[1].Id }
            };

            foreach (var taskItem in taskItems)
            {
                context.TaskItems.Add(taskItem);
            }
            context.SaveChanges();
        }
    }
}
