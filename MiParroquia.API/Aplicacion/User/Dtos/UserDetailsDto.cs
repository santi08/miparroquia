using System;
using System.Collections.Generic;
using System.Text;

namespace MiParroquia.API.Application.User.Dtos
{
    public class UserDetailsDto
    {
        public string Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificación { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }

        //public ICollection<PerfilListDto> Perfiles { get; set; }
        //public virtual ICollection<ProcesoListDto> Procesos { get; set; }
    }
}
