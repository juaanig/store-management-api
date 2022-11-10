using Microsoft.EntityFrameworkCore;
using store_management_api.Entities;

namespace store_management_api.DBcontext
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuarios> Usuario { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
        public DbSet<Producto> Productos { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
        public DbSet<Ubicacion> Ubicaciones{ get; set; }

        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //================= USUSARIOS =================

            Usuarios agustin = new Usuarios()
            {
                LastName = "canapino",
                Name = "agustin",
                Email = "ac1@gmail.com",
                Password = "1234567890",
                Id = 1,
                Role = "Deposito"
            };

            Usuarios roberto = new Usuarios()
            {
                LastName = "carlos",
                Name = "roberto",
                Email = "rc@gmail.com",
                Password = "1234567890",
                Id = 2,
                Role = "Deposito"
            };

            //================= UBICACIONES =================

            Ubicacion deportivas = new Ubicacion()
            {
                NameLocation = "600cc",
                ExpDate = false,
                UsuarioId = agustin.Id,
                Id = 3,
            };

            Ubicacion onoff = new Ubicacion()
            {
                NameLocation = "250cc",
                ExpDate = false,
                UsuarioId = agustin.Id,
                Id = 1,
            };

            Ubicacion scooter = new Ubicacion()
            {
                NameLocation = "150cc",
                ExpDate = true,
                UsuarioId = roberto.Id,
                Id = 2,
            };

            //================= PRODUCTOS =================

            Producto cbr600 = new Producto()
            {
                EntryDate = new DateTime(2100, 5, 12),
                ExpDate = new DateTime(2020, 5, 12),
                Name = "Honda cbr 600cc ",
                Quantity = 10,
                Price = 59600,
                UbicacionId = deportivas.Id, 
                Id = 4,
            };

            Producto yzr600 = new Producto()
            {
                EntryDate = new DateTime(2100, 5, 12),
                ExpDate = new DateTime(2020, 5, 12),
                Name = "Yamaha r6 600cc ",
                Quantity = 7,
                Price = 60700,
                UbicacionId = deportivas.Id,
                Id = 1,
            };

            Producto tornado250 = new Producto()
            {
                EntryDate = new DateTime(2100, 5, 12),
                ExpDate = new DateTime(2020, 5, 12),
                Name = "Honda tornado 250cc ",
                Quantity = 20,
                Price = 5000,
                UbicacionId = onoff.Id,
                Id = 2,
            };

            Producto vespa150 = new Producto()
            {
                EntryDate = new DateTime(2100, 5, 12),
                ExpDate = new DateTime(2020, 5, 12),
                Name = "Vespa 150cc ",
                Quantity = 25,
                Price = 3500,
                UbicacionId = scooter.Id,
                Id = 3,
            };

            modelBuilder.Entity<Usuarios>().HasData(roberto, agustin);

            modelBuilder.Entity<Ubicacion>().HasData(deportivas, onoff, scooter);

            modelBuilder.Entity<Producto>().HasData(cbr600, yzr600, tornado250, vespa150);


            modelBuilder.Entity<Usuarios>()
              .HasMany<Ubicacion>(u => u.Ubicaciones)
              .WithOne(c => c.Usuario);

            modelBuilder.Entity<Ubicacion>()
              .HasMany<Producto>(u => u.Productos)
              .WithOne(c => c.Ubicaciones);

            base.OnModelCreating(modelBuilder);

        }

    }
}
