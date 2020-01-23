using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                    new Item
                    {
                        Id = 1,
                        Name = "Test 1",
                        Price = 15,
                        Category = Category.HDD
                    },
                    new Item
                    {
                        Id = 2,
                        Name = "Test 2",
                        Price = 20,
                        Category = Category.CPU
                    }
                );
        }
    }
}
