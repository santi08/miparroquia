using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Horarios.Dtos
{
    public class ReservaListDto
    {
        public Guid ReservaId { get; set; }
        public bool Invitado { get; set; }
        public Guid UsuarioId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificación { get; set; }
    }
}
