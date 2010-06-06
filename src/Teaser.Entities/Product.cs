namespace Teaser.Entities
{
    public class Entity
    {
        public int Id { get; set; }
    }

	public class Product : Entity
    {
		public string Name { get; set; }
		public string Model { get; set; }
		public string Sku { get; set; }
		public decimal Price { get; set; }

		public Manufacturer Manufacturer { get; set; }
	}


    public class Manufacturer : Entity
    {
        public string Name { get; set; }
    }

}