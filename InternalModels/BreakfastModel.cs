namespace BasicAPI.InternalModels
{
    public class BreakfastModel
    {
        public int Id { get; }
        public string Name { get; }

        public BreakfastModel(int _id, string _name)
        {
            this.Name = _name;
            this.Id = _id;
        }
    }
}
