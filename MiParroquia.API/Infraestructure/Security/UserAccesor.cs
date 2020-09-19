using Microsoft.AspNetCore.Http;
using MiParroquia.API.Application.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;

namespace MiParroquia.API.Infrastructure.Security
{
    public class UserAccesor : IUserAccesor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccesor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserName()
        {
            var username = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            return username;
        }

        public string GetUserId()
        {
            var username = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return username;
        }

        //public Guid GetEmpresaId()
        //{
        //    var emrpesaId = Guid.Parse(_httpContextAccessor.HttpContext.User?.Claims?.Where(c => c.Type.Equals("empresaId")).FirstOrDefault().Value);
        //    return emrpesaId;
        //}
    }
}
