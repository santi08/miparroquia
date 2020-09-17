using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Dominio
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificación { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }

        public ICollection<Iglesia> Iglesias { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<UsuarioInvitado> Invitados { get; set; }
    }
}
