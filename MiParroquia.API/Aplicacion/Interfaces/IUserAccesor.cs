using System;
using System.Collections.Generic;
using System.Text;

namespace MiParroquia.API.Application.Interfaces
{
    public interface IUserAccesor
    {
        string GetCurrentUserName();
        //Guid GetEmpresaId();
        string GetUserId();
    }
}
