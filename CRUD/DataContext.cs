using Microsoft.EntityFrameworkCore;

namespace CRUD
{
    class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = db.sqlite"); // "db.sqlite" es el nombre del fichero que va a contener la base de datos
                                                                 // base.OnConfiguring(optionsBuilder);

        }
    }
}
