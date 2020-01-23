using ComputerService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.ViewModels
{
    public class ItemCreateViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Price field is required")]
        [RegularExpression(@"\d+(.|,)\d(\d?)", ErrorMessage = "Invalid Price format")]
        public decimal Price { get; set; }
        [Required]
        public Category? Category { get; set; }
        public IFormFile Photo { get; set; }
    }
}
