using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicAPI
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        // Navigation property
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [Required]
        public TaskStatus Status { get; set; }

        public void Update(Task sourceObject)
        {
            Description = sourceObject.Description;
            UpdatedDate = DateTime.Now;
            Status = sourceObject.Status;
        }
    }
}
