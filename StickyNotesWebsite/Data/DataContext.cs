using Microsoft.EntityFrameworkCore;
using StickyNotesWebsite.Models;

namespace StickyNotesWebsite.Data
{
    public class DataContext : DbContext
    {       
        public DbSet<StickyNote> stickyNote { get; set; }
        public DbSet<Category> categories { get; set; }
        public IConfiguration _config { get; set; }
        public DataContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        } 
    }
}
