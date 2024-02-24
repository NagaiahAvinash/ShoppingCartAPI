namespace ShoppingCart.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
