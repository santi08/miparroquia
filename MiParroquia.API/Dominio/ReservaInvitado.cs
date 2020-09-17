using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Dominio
{
    public class ReservaInvitado
    {
        public Guid ReservaInvitadoId { get; set; }
        public Guid HorarioId { get; set; }
        public Guid UsuarioInvitadoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        public Horario Horario { get; set; }
        public UsuarioInvitado UsuarioInvitado { get; set; }
    }
}
