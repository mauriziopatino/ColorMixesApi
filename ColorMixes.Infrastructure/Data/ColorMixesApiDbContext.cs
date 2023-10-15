using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorMixes.Infrastructure.Data
{
    public class ColorMixesApiDbContext : DbContext
    {
        public ColorMixesApiDbContext(DbContextOptions<ColorMixesApiDbContext> options) : base(options)
        {
        }

        protected ColorMixesApiDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("Modern_Spanish_CI_AS");
        }
    }
}
