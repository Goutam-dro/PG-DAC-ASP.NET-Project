using System.ComponentModel.DataAnnotations;

namespace Day12.Models
{
    public class Feedback1
    {
        public int Id { get; set; }
        
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Only letters are allowed in the  Name field.")]
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit mobile number.")]
        public string Mobile_Number { get; set; }

        [Required]
        [Display(Name = "Feedback")]
        public string Feedback { get; set; }
    }
}
