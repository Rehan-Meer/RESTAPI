using System.ComponentModel.DataAnnotations;

namespace BasicAPI
{
    public class Breakfast
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
