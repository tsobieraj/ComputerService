using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public class SQLEntryRepository : IEntryRepository
    {
        private readonly AppDbContext context;
        public SQLEntryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public AppDbContext Context { get; }

        public Entry Add(Entry entry)
        {
            context.Entries.Add(entry);
            context.SaveChanges();
            return entry;
        }

        public IEnumerable<Entry> GetAllEntries()
        {
            return context.Entries;
        }
    }
}
