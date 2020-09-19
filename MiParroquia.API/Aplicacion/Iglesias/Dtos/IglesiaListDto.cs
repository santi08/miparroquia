using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Iglesias.Dtos
{
    public class IglesiaListDto
    {
        public Guid IglesiaId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Parroco { get; set; }

        //public Usuario Parroco { get; set; }
        //public ICollection<Horario> Horarios { get; set; }
    }
}
