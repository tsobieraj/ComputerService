using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ComputerService.Models
{
    public class SQLOrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext context;
        public SQLOrderItemRepository(AppDbContext context)
        {
            this.context = context;
        }

        public AppDbContext Context { get; }

        public OrderItem Add(OrderItem orderItem)
        {
            context.OrderItems.Add(orderItem);
            context.SaveChanges();
            return orderItem;
        }

        public int GetLastId()
        {
            return context.OrderItems.Max(e => e.Id);
        }

    }
}
