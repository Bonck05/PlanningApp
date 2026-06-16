using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningApp.Models
{
    public class TaskItem
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int TaskListId { get; set; }

        [ForeignKey(nameof(TaskListId))]
        public TaskList TaskList { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
    }
}
