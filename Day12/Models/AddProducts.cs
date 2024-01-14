using System.ComponentModel.DataAnnotations;

namespace Day12.Models
{
    public class AddProducts
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Product Name")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Only letters are allowed in the Product Name field.")]
        public string Product_Name { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        [RegularExpression(@"^[1-9]\d{4,}(\.\d+)?$", ErrorMessage = "Product Price must have at least 1 non-zero digit and a total of 5 digits.")]
        public string Product_Price{ get; set; }

        [Required]
        [Display(Name = "Product Specifiation")]
        public string Product_Specifiation { get; set; }
        
        [Required]
        [Display(Name = "Product Summary")]
        public string Product_Summary { get; set; }

    }
}
