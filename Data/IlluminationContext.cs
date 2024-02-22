using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Illumination.Models;

namespace Illumination.Data
{
    public class IlluminationContext : DbContext
    {
        public IlluminationContext (DbContextOptions<IlluminationContext> options)
            : base(options)
        {
        }

        public DbSet<Illumination.Models.Lamp> Lamp { get; set; } = default!;
    }
}
