namespace BackendACT.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public Uri Image { get; set; } = default!;

    }
}
