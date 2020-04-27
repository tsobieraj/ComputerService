using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Price field is required")]
        [RegularExpression(@"\d+(.|,)\d(\d?)", ErrorMessage = "Invalid Price format")]
        public decimal Price { get; set; }
        [Required]
        public Category? Category { get; set; }
        public string PhotoPath { get; set; }
    }
}
