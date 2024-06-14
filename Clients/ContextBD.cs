using Microsoft.EntityFrameworkCore;

namespace VKRWebAPI.Clients
{
    public class ContextBD: DbContext
    {
        public DbSet<Clients> Clients { get; set; }

        public ContextBD (DbContextOptions<ContextBD> options): base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app12.db");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>().HasData
                (
                    new Clients { ID = 1, City = "Barnaul", Address = "polyana, 29", Contract = "01/01", Service = "L2", VLAN = "887", IPAddress = "", ServicePaid = true },
                    new Clients { ID = 2, City = "Omsk", Address = "Uskova, 13", Contract = "01/01", Service = "Internet", VLAN = "", IPAddress = "8.8.8.8", ServicePaid = true },
                    new Clients { ID = 3, City = "Moskva", Address = "Lenina, 56", Contract = "01/02", Service = "Internet", VLAN = "", IPAddress = "192.168.33.55", ServicePaid = true },
                    new Clients { ID = 4, City = "Perm", Address = "Molodejnaya, 8", Contract = "01/02", Service = "L2", VLAN = "327", IPAddress = "", ServicePaid = true },
                    new Clients { ID = 5, City = "Perm", Address = "Molodejnaya, 43", Contract = "01/02", Service = "L2", VLAN = "657", IPAddress = "", ServicePaid = false },
                    new Clients { ID = 6, City = "Perm", Address = "Popova, 13", Contract = "01/02", Service = "Internet", VLAN = "", IPAddress = "8.8.8.8", ServicePaid = true },
                    new Clients { ID = 7, City = "Perm", Address = "Papanova, 33", Contract = "01/02", Service = "Internet", VLAN = "", IPAddress = "8.8.8.8", ServicePaid = false },
                    new Clients { ID = 8, City = "Omsk", Address = "Gurova, 77", Contract = "01/01", Service = "Internet", VLAN = "", IPAddress = "8.8.8.8", ServicePaid = true },
                    new Clients { ID = 9, City = "Novosibirsk", Address = "Pervomayskaya, 3", Contract = "01/02", Service = "L2", VLAN = "2211", IPAddress = "", ServicePaid = false },
                    new Clients { ID = 10, City = "Novosibirsk", Address = "Olejka, 235", Contract = "01/01", Service = "Internet", VLAN = "", IPAddress = "8.8.8.8", ServicePaid = true }
                );
        }
    }
}
