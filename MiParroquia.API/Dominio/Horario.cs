using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Dominio
{
    public class Horario
    {
        public Guid HorarioId { get; set; }
        public Guid IglesiaId { get; set; }
        public DateTime Hora { get; set; }
        public int Capacidad { get; set; }
        public string Transmision { get; set; }

        public Iglesia Iglesia { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<ReservaInvitado> ReservaInvitados { get; set; }
    }
}
