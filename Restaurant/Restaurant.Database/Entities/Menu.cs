namespace Restaurant.Database.Entities
{
    public class Menu
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Ingredients { get; set; }
    }
}
