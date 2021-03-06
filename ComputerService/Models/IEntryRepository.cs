﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerService.Models
{
    public interface IEntryRepository
    {
        IEnumerable<Entry> GetAllEntries();
        Entry Add(Entry entry);
    }
}
