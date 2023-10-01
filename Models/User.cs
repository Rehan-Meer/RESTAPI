using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BasicAPI
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Password { get; set; } 
        public bool IsActive { get; set; }
    }
}