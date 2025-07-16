using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.Models.DTOs
{
    public class StudentDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
