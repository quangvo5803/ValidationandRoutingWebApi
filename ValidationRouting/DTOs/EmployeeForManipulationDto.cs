using System.ComponentModel.DataAnnotations;

namespace ValidationRouting.DTOs
{
    public class EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employee name is a required field")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Range(18, int.MaxValue, ErrorMessage = "Age is requird and can't be lower than 18")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Position name is a required field")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Positon is 20 characters.")]
        public string Positon { get; set; }
    }
}
