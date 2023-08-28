using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataContextEF : DbContext
    {
        private IConfiguration _config;

        //private string _connectionString;

        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Computer>? Computer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                    options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");
            //modelBuilder.Entity<Computer>().HasNoKey();
            modelBuilder.Entity<Computer>().HasKey(c => c.ComputerId);
            //modelBuilder.Entity<Computer>().ToTable("Computer", "TutorialAppSchema");
            //modelBuilder.Entity<Computer>().ToTable("Table Name", "Schema Name");
        }
    }
}