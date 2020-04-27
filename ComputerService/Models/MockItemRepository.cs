using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public class MockItemRepository : IItemRepository
    {
        private List<Item> _itemlist;

        public MockItemRepository()
        {
            _itemlist = new List<Item>()
            {
                new Item() { Id = 1, Name = "Item 1", Price = 10, Category = Category.CPU },
                new Item() { Id = 2, Name = "Item 2", Price = 20, Category = Category.GPU },
                new Item() { Id = 3, Name = "Item 3", Price = 30, Category = Category.HDD },
            };
        }

        public Item Add(Item item)
        {
            item.Id = _itemlist.Max(e=> e.Id) + 1;
            _itemlist.Add(item);
            return item;
        }

        public Item Delete(int id)
        {
            Item item = _itemlist.FirstOrDefault(e => e.Id == id);
            if (item != null)
            {
                _itemlist.Remove(item);
            }
            return item;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _itemlist;
        }

        public IEnumerable<Item> GetItemsByCategory(string category)
        {
            return _itemlist;
        }

        public Item GetItem(int Id)
        {
            return this._itemlist.FirstOrDefault(e => e.Id == Id);
        }

        public Item Update(Item itemChanges)
        {
            Item item = _itemlist.FirstOrDefault(e => e.Id == itemChanges.Id);
            if (item != null)
            {
                item.Name = itemChanges.Name;
                item.Price = itemChanges.Price;
                item.Category = itemChanges.Category;
            }
            return item;
        }
    }
}
