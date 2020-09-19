using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiParroquia.API.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Persistencia.Config
{
    public class ReservaConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Reserva> entityBuilder)
        {
            entityBuilder.HasOne(h => h.Horario)
                         .WithMany(i => i.Reservas)
                         .HasForeignKey(h => h.HorarioId);

            entityBuilder.HasOne(h => h.Usuario)
             .WithMany(i => i.Reservas)
             .HasForeignKey(h => h.UsuarioId);

        }
    }
}
