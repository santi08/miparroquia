﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Dominio
{
    public class Iglesia
    {
        public Guid IglesiaId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public Guid ParrocoId { get; set; }

        public Usuario Parroco { get; set; }
        public ICollection<Horario> Horarios { get; set; }
    }
}
