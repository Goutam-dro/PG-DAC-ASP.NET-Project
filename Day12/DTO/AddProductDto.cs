using System.ComponentModel.DataAnnotations.Schema;

namespace Day12.DTO
{
    public class AddProductDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductDesc { get; set; }

        [NotMapped]
        public IFormFile ProductImage { get; set; }

        public string Cost { get; set; }

    }
}
