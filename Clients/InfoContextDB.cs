using Microsoft.EntityFrameworkCore;

namespace VKRWebAPI.Clients
{
    public class InfoContextDB: DbContext
    {
        public DbSet<Inform> Informs { get; set; }

        public InfoContextDB(DbContextOptions<InfoContextDB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Info.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inform>().HasData
                (
                         new Inform { ID = 1, City = "Moskva", Information = "Авария на сети в г. Москва", Status = "Open" },
                         new Inform { ID = 2, City = "Novosibirsk", Information = "", Status = "" }
                ) ;
        }
    }
}
