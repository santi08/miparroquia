using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiParroquia.API.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Persistencia.Config
{
    public class HorarioConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Horario> entityBuilder)
        {
            entityBuilder.HasOne(h => h.Iglesia)
                         .WithMany(i => i.Horarios)
                         .HasForeignKey(h => h.IglesiaId);

            //entityBuilder.HasOne(a => a.Empresa)
            //             .WithMany(e => e.Areas)
            //             .HasForeignKey(a => a.EmpresaId)
            //             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
