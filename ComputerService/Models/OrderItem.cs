using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public Order Order { get; set; }
        [Key]
        public Item Item  { get; set; }

    }
}
