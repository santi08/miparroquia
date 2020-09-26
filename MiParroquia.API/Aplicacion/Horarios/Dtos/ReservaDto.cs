using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Horarios.Dtos
{
    public class ReservaDto
    {
        public Guid ReservaId { get; set; }
        public string Estado { get; set; }
        public bool Invitado { get; set; }
    }
}
