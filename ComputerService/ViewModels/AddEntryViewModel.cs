using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.ViewModels
{
    public class AddEntryViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Topic cannot exceed 50 characters")]
        public string Topic { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 400 characters")]
        public string Description { get; set; }
    }
}
