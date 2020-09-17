using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Dominio
{
    public class Reserva
    {
        public Guid ReservaId { get; set; }
        public Guid HorarioId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        public Horario Horario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
