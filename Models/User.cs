using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BasicAPI
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public void Update(User sourceObject)
        {
            Name = sourceObject.Name;
            Password = sourceObject.Password;
            IsActive = sourceObject.IsActive;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(User))
                return false;
            else
            {
                User user = (User)obj;
                return (user.Name == this.Name && user.Password == this.Password);
            }
        }
    }
}