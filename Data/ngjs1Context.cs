using Microsoft.EntityFrameworkCore;
using ngjs1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ngjs1.Data
{
    public class ngjs1Context : DbContext
    {
        public ngjs1Context(DbContextOptions<ngjs1Context> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artist { get; set; }
        public DbSet<LastViewed> LastVieweds { get; set; }
    }
}
