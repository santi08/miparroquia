using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiParroquia.API.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Persistencia.Config
{
    public class UsuarioInvitadoConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<UsuarioInvitado> entityBuilder)
        {
            entityBuilder.HasOne(h => h.Usuario)
                         .WithMany(i => i.Invitados)
                         .HasForeignKey(h => h.UsuarioId);
        }
    }
}
