namespace ShoppingCart.Models
{
    public class ShoppingCarts
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
