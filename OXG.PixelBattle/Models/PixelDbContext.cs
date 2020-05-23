using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OXG.PixelBattle.Models
{
    public class PixelDbContext : DbContext //Контекст БД
    {
        public DbSet<Cell> Cells { get; set; }

        public PixelDbContext(DbContextOptions<PixelDbContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
