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

        //[Display(Name = "Office Email")]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        //ErrorMessage = "Invalid email format")]
        //[Required]
        //public string Email { get; set; }
    }
}
