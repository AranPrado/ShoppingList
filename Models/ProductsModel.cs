namespace ShoppingList.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required float Price { get; set; }

        public int? Quantity { get; set; }

        public int? Weight { get; set; } //Peso

        public string? Brand { get; set; } //Marca

    }
}