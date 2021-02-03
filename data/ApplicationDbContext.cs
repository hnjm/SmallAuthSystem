using Microsoft.EntityFrameworkCore;
using SmallAuthSystem.models;

namespace SmallAuthSystem.data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "data\\System.db");
            optionsBuilder.UseSqlite("Filename=" + path);
        }

    }
}