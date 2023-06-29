using System.ComponentModel.DataAnnotations;

namespace BasicAPI
{
    public class Breakfast
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public void Update(Breakfast sourceObject)
        {
            this.Name = sourceObject.Name;
            this.Price = sourceObject.Price;
            this.IsActive = sourceObject.IsActive;
        }
    }
}
