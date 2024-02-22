using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shawls_ReadyToWear.Models;

namespace Shawls_ReadyToWear.Data
{
    public class Shawls_ReadyToWearContext : DbContext
    {
        public Shawls_ReadyToWearContext (DbContextOptions<Shawls_ReadyToWearContext> options)
            : base(options)
        {
        }

        public DbSet<Shawls_ReadyToWear.Models.Shawl> Shawl { get; set; } = default!;
    }
}
