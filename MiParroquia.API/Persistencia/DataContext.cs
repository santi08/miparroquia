using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Dominio;
using MiParroquia.API.Persistencia.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Persistencia
{
    public class DataContext : IdentityDbContext<Usuario>
    {
        public DataContext(DbContextOptions options)
         : base(options)
        {

        }

        public DbSet<Iglesia> Iglesias { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<UsuarioInvitado> UsuarioInvitados { get; set; }
        public DbSet<ReservaInvitado> ReservasInvitados { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Usuario u = new Usuario(); 
            
            
            base.OnModelCreating(builder);

            IglesiaConfig.SetEntityBuilder(builder.Entity<Iglesia>());
            HorarioConfig.SetEntityBuilder(builder.Entity<Horario>());
            ReservaConfig.SetEntityBuilder(builder.Entity<Reserva>());
            UsuarioInvitadoConfig.SetEntityBuilder(builder.Entity<UsuarioInvitado>());
            ReservaInvitadoConfig.SetEntityBuilder(builder.Entity<ReservaInvitado>());

            //builder.Entity<Value>().HasData(
            //    new Value { Id = 1, Name = "Value 101" },
            //    new Value { Id = 2, Name = "Value 102" },
            //    new Value { Id = 3, Name = "Value 103" }
            //);

        }
    }
}
