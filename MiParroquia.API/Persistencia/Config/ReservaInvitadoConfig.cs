using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiParroquia.API.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Persistencia.Config
{
    public class ReservaInvitadoConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ReservaInvitado> entityBuilder)
        {
            entityBuilder.HasOne(h => h.Horario)
                         .WithMany(i => i.ReservaInvitados)
                         .HasForeignKey(h => h.HorarioId);

            entityBuilder.HasOne(h => h.UsuarioInvitado)
             .WithMany(i => i.Reservas)
             .HasForeignKey(h => h.UsuarioInvitadoId);
        }
    }
}
