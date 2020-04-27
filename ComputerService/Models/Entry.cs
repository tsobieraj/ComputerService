using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public class Entry
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Topic cannot exceed 50 characters")]
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(400, ErrorMessage = "Description cannot exceed 400 characters")]
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
    }
}
