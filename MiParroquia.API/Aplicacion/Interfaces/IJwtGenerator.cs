using MiParroquia.API.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiParroquia.API.Application.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(Usuario user);
    }
}
