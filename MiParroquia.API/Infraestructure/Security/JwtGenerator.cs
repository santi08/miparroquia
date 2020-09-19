using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiParroquia.API.Application.Interfaces;
using MiParroquia.API.Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MiParroquia.API.Infrastructure.Security
{
    public class JwtGenerator : IJwtGenerator
    {

        private readonly SymmetricSecurityKey _key;

        public JwtGenerator(IConfiguration config)
        {
            //_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
             _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:Token").Value));
        }

        public string CreateToken(Usuario user)
        {
            //var opcionesUsuario = user.PerfilesUsuario.SelectMany(p => p.Perfil.OpcionesPerfil).Select(o => o.Opcion.NumeroOpcion);
            //var opciones = JsonConvert.SerializeObject(opcionesUsuario);

            var claims = new List<Claim> {

                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                //new Claim ("empresaId", user.EmpresaId.ToString()),
                //new Claim("opciones", opciones),
            };

            //generate signin credentials

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
