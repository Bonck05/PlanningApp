using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningApp.Models
{
    public class TaskList
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Required]
        public string Title { get; set; }

        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
