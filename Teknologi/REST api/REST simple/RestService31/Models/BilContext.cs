﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestService31.Models
{
    public class BilContext : DbContext
    {
        public BilContext(DbContextOptions<BilContext> options)
            : base(options)
        {
        }

        public DbSet<Bil> bilItems { get; set; }
    }
}
