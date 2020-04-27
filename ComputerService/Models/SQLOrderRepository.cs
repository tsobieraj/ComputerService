using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        public SQLOrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public AppDbContext Context { get; }

        public Order Add(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }
    }
}
