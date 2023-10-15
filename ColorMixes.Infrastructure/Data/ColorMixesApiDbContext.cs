using ColorMixes.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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

        public DbSet<Color> Colors { get; set; }
        public DbSet<Combination> Combinations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Azul" },
                new Color { Id = 2, Name = "Rojo" }
            );

            modelBuilder.Entity<Combination>().HasData(
                new Combination { Id = 1, FirstColorId = 1, SecondColorId = 2, Result = "Morado"}
            );
        }
    }
}
