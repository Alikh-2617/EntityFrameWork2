using EntityFrameWork2.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWork2.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // sett Db 
        public DbSet<PersonVM> People { get; set; }
        public DbSet<CityVM> City { get; set; }
        public DbSet<CountryVM> Country { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonVM>().HasData(new PersonVM { Id = Guid.NewGuid().ToString(), Name = "Ali", EfterName = "khawari", age = 32, PhoneNumber = "1245" });
            modelBuilder.Entity<PersonVM>().HasData(new PersonVM { Id = Guid.NewGuid().ToString(), Name = "Ali22", EfterName = "khawari22", age = 32, PhoneNumber = "1245" });
            modelBuilder.Entity<PersonVM>().HasData(new PersonVM { Id = Guid.NewGuid().ToString(), Name = "Ali33", EfterName = "khawari33", age = 32, PhoneNumber = "1245" });

            modelBuilder.Entity<CityVM>().HasData(new CityVM { Name = "Åre", PostNumber = "415 55" });
            modelBuilder.Entity<CityVM>().HasData(new CityVM { Name = "Järpen", PostNumber = "415 44" });

            modelBuilder.Entity<CountryVM>().HasData(new CountryVM { Name = "Swedan" });
            modelBuilder.Entity<CountryVM>().HasData(new CountryVM { Name = "Norway" });
        }


    }
}
