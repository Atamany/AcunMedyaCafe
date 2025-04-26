using System.ComponentModel.DataAnnotations.Schema;

namespace AcunMedyaCafe.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
