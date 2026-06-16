using System.ComponentModel.DataAnnotations;

namespace PlanningApp.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public List<TaskList> TaskLists { get; set; } = new List<TaskList>();
    }
}
