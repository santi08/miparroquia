using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiParroquia.API.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Persistencia.Config
{
    public class IglesiaConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Iglesia> entityBuilder)
        {
            entityBuilder.HasOne(a => a.Parroco)
                         .WithMany(ah => ah.Iglesias)
                         .HasForeignKey(a => a.ParrocoId);

            //entityBuilder.HasOne(a => a.Empresa)
            //             .WithMany(e => e.Areas)
            //             .HasForeignKey(a => a.EmpresaId)
            //             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
