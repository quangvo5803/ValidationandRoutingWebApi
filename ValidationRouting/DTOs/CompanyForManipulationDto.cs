﻿using System.ComponentModel.DataAnnotations;

namespace ValidationRouting.DTOs
{
    public class CompanyForManipulationDto
    {
        [Required(ErrorMessage = "Company name is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the name is 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Company address is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the address is 60 characters")]
        public string Address { get; set; }
        public string Country { get; set; }
    }
}
