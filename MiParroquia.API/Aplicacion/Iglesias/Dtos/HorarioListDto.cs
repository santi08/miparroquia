using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Iglesias.Dtos
{
    public class HorarioListDto
    {
        public Guid HorarioId { get; set; }
        public string Dia { get; set; }
        public DateTime Hora { get; set; }
        public int Capacidad { get; set; }
        public int Disponible { get; set; }
        public string Transmision { get; set; }
    }
}
