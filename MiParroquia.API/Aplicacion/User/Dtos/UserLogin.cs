using System;
using System.Collections.Generic;
using System.Text;

namespace MiParroquia.API.Application.User.Dtos
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Image { get; set; }
    }
}
