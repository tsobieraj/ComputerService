﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public interface IItemRepository
    {
        Item GetItem(int Id);
        IEnumerable<Item> GetAllItems();
        IEnumerable<Item> GetItemsByCategory(string category);
        Item Add(Item item);
        Item Update(Item itemChanges);
        Item Delete(int id);
    }
}
