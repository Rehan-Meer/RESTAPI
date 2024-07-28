namespace BasicAPI.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public List<TaskDto> Tasks { get; set; } = new List<TaskDto>();
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}