using Microsoft.AspNetCore.Identity;
using MiParroquia.API.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Persistencia
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<Usuario> userManager)
        {
            if (!userManager.Users.Any())
            {
                var iglesia = new Iglesia
                {
                    Nombre = "Parroquia la resurección"
                };

                var users = new List<Usuario>
                {
                    new Usuario {
                        PrimerNombre = "Yeferson",
                        PrimerApellido = "Guarin",
                        UserName =  "admin",
                        Email= "admin@admin.com",
                        Iglesias = new List<Iglesia>{iglesia}
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
        }

        //public static void SeedOpciones(DataContext context)
        //{

        //    if (!context.Opciones.Any())
        //    {
        //        List<Opcion> opciones = new List<Opcion>
        //        {
        //            new Opcion { Nombre = "Usuarios",
        //                         Url="/usuarios",
        //                         NumeroOpcion = 1,
        //                         Orden = 1,
        //                         OpcionesHijas= new List<Opcion>{
        //                             new Opcion { Nombre="Listar Usuarios", NumeroOpcion = 2, Orden = 1 },
        //                             new Opcion { Nombre="Crear Usuario", NumeroOpcion = 3, Orden = 2 },
        //                             new Opcion { Nombre="Editar Usuario", NumeroOpcion = 4, Orden = 3 },
        //                             new Opcion { Nombre="Eliminar Usuario", NumeroOpcion = 5, Orden = 4 },
        //                         }
        //                        },
        //            new Opcion { Nombre = "Areas",
        //                         Url="/areas",
        //                         NumeroOpcion = 6,
        //                         Orden = 2,
        //                         OpcionesHijas= new List<Opcion>{
        //                             new Opcion { Nombre="Listar Area", NumeroOpcion = 7, Orden = 1 },
        //                             new Opcion { Nombre="Crear Area", NumeroOpcion = 8, Orden = 2 },
        //                             new Opcion { Nombre="Editar Area", NumeroOpcion = 9, Orden = 3 },
        //                             new Opcion { Nombre="Eliminar Area", NumeroOpcion = 10, Orden = 4 },
        //                         }
        //                        },
        //            new Opcion { Nombre = "Maquinas",
        //                         Url="/maquinas",
        //                         NumeroOpcion = 11,
        //                         Orden = 3,
        //                         OpcionesHijas= new List<Opcion>{
        //                              new Opcion { Nombre="Listar Maquinas", NumeroOpcion = 12, Orden = 1 },
        //                              new Opcion { Nombre="Crear Maquina", NumeroOpcion = 13, Orden = 2 },
        //                              new Opcion { Nombre="Editar Maquina", NumeroOpcion = 14, Orden = 3 },
        //                              new Opcion { Nombre="Eliminar Maquina", NumeroOpcion = 15, Orden = 4 },
        //                         }
        //                        },
        //            new Opcion { Nombre = "Procesos",
        //                         Url="/procesos",
        //                         NumeroOpcion = 16,
        //                         Orden = 4,
        //                         OpcionesHijas= new List<Opcion>{
        //                              new Opcion { Nombre="Listar Procesos", NumeroOpcion = 17, Orden = 1 },
        //                              new Opcion { Nombre="Crear Proceso", NumeroOpcion = 18, Orden = 2 },
        //                              new Opcion { Nombre="Editar Proceso", NumeroOpcion = 19, Orden = 3 },
        //                              new Opcion { Nombre="Eliminar Proceso", NumeroOpcion = 20, Orden = 4 },
        //                              new Opcion { Nombre="Ver Transacciones", NumeroOpcion = 21, Orden = 5 },
        //                              new Opcion { Nombre="Ver Logs", NumeroOpcion = 22, Orden = 5 },
        //                         }
        //                        },
        //            new Opcion { Nombre="Vistas Proceso",
        //                           NumeroOpcion = 23,
        //                           Orden = 5,
        //                                    OpcionesHijas = new List<Opcion>{
        //                                         new Opcion { Nombre="Ver Vistas Proceso", NumeroOpcion = 24, Orden = 1 },
        //                                         new Opcion { Nombre="Crear Vista Proceso", NumeroOpcion = 25, Orden = 2 },
        //                                         new Opcion { Nombre="Editar Vista Proceso", NumeroOpcion = 26, Orden = 3 },
        //                                         new Opcion { Nombre="Eliminar Vista Proceso", NumeroOpcion = 27, Orden = 4 },
        //                                    }
        //                           },
        //            new Opcion { Nombre="Vistas Proceso",
        //                           NumeroOpcion = 28,
        //                           Orden = 6,
        //                                    OpcionesHijas = new List<Opcion>{
        //                                         new Opcion { Nombre="Ver Vistas Proceso", NumeroOpcion = 29, Orden = 1 },
        //                                         new Opcion { Nombre="Crear Vista Proceso", NumeroOpcion = 30, Orden = 2 },
        //                                         new Opcion { Nombre="Editar Vista Proceso", NumeroOpcion = 31, Orden = 3 },
        //                                         new Opcion { Nombre="Eliminar Vista Proceso", NumeroOpcion = 32, Orden = 4 },
        //                                    }
        //                           },
        //            new Opcion { Nombre="Usuarios Proceso",
        //                           NumeroOpcion = 33,
        //                           Orden = 7,
        //                                    OpcionesHijas = new List<Opcion>{
        //                                         new Opcion { Nombre="Ver Usuarios Proceso", NumeroOpcion = 34, Orden = 1 },
        //                                         new Opcion { Nombre="Crear Usuario Proceso", NumeroOpcion = 35, Orden = 2 },
        //                                         new Opcion { Nombre="Editar Usuario Proceso", NumeroOpcion = 36, Orden = 3 },
        //                                         new Opcion { Nombre="Eliminar Usuario Proceso", NumeroOpcion = 37, Orden = 4 },
        //                                    }
        //                           },
        //            new Opcion { Nombre="Configuraciones Proceso",
        //                           NumeroOpcion = 38,
        //                           Orden = 8,
        //                                    OpcionesHijas = new List<Opcion>{
        //                                         new Opcion { Nombre="Ver Configuraciones Proceso", NumeroOpcion = 39, Orden = 1 },
        //                                         new Opcion { Nombre="Crear Configuracion Proceso", NumeroOpcion = 40, Orden = 2 },
        //                                         new Opcion { Nombre="Editar Configuracion Proceso", NumeroOpcion = 41, Orden = 3 },
        //                                         new Opcion { Nombre="Eliminar Configuracion Proceso", NumeroOpcion = 42, Orden = 4 },
        //                                    }
        //                           },
        //            new Opcion { Nombre="Configuraciones Globales Proceso",
        //                           NumeroOpcion = 43,
        //                           Orden = 9,
        //                                    OpcionesHijas = new List<Opcion>{
        //                                         new Opcion { Nombre="Ver Configuraciones Globales Proceso", NumeroOpcion = 44, Orden = 1 },
        //                                         new Opcion { Nombre="Crear Configuracion Global Proceso", NumeroOpcion = 45, Orden = 2 },
        //                                         new Opcion { Nombre="Editar Configuracion Global Proceso", NumeroOpcion = 46, Orden = 3 },
        //                                         new Opcion { Nombre="Eliminar Configuracion Global Proceso", NumeroOpcion = 47, Orden = 4 },
        //                                    }
        //                           },
        //            new Opcion { Nombre="Roles Proceso",
        //                           NumeroOpcion = 48,
        //                           Orden = 10,
        //                                    OpcionesHijas = new List<Opcion>{
        //                                         new Opcion { Nombre="Ver Roles Proceso", NumeroOpcion = 49, Orden = 1 },
        //                                         new Opcion { Nombre="Crear Rol Proceso", NumeroOpcion = 50, Orden = 2 },
        //                                         new Opcion { Nombre="Editar Rol Proceso", NumeroOpcion = 51, Orden = 3 },
        //                                         new Opcion { Nombre="Eliminar Rol Proceso", NumeroOpcion = 52, Orden = 4 },
        //                                    }
        //                           },
        //            new Opcion { Nombre="Origenes Datos Proceso",
        //                           NumeroOpcion = 53,
        //                           Orden = 11,
        //                                    OpcionesHijas = new List<Opcion>{
        //                                         new Opcion { Nombre="Ver Origenes Datos Proceso", NumeroOpcion = 54, Orden = 1 },
        //                                         new Opcion { Nombre="Crear Origen Datos Proceso", NumeroOpcion = 55, Orden = 2 },
        //                                         new Opcion { Nombre="Editar Origen Datos Proceso", NumeroOpcion = 56, Orden = 3 },
        //                                         new Opcion { Nombre="Eliminar Origen Datos Proceso", NumeroOpcion = 57, Orden = 4 },
        //                                    }
        //                           },
        //            new Opcion { Nombre="Instancias Proceso",
        //                           NumeroOpcion = 58,
        //                           Orden = 12,
        //                                    OpcionesHijas = new List<Opcion>{
        //                                         new Opcion { Nombre="Ver Instancias Proceso", NumeroOpcion = 59, Orden = 1 },
        //                                         new Opcion { Nombre="Crear Instancia Proceso", NumeroOpcion = 60, Orden = 2 },
        //                                         new Opcion { Nombre="Editar Instancia Proceso", NumeroOpcion = 61, Orden = 3 },
        //                                         new Opcion { Nombre="Eliminar Instancia Proceso", NumeroOpcion = 62, Orden = 4 },
        //                                    }
        //                           },
        //            new Opcion { Nombre="Instancias",
        //                           NumeroOpcion = 63,
        //                           Orden = 13,
        //                                    OpcionesHijas = new List<Opcion>{
        //                                         new Opcion { Nombre="Ver Auditorias Instancia", NumeroOpcion = 64, Orden = 1 },
        //                                    }
        //                           },
        //            new Opcion { Nombre="Configuraciones Instancia",
        //                           NumeroOpcion = 65,
        //                           Orden = 14,
        //                                    OpcionesHijas = new List<Opcion>{
        //                                         new Opcion { Nombre="Ver Configuraciones Instancias", NumeroOpcion = 66, Orden = 1 },
        //                                         new Opcion { Nombre="Crear Configuracion Instancia", NumeroOpcion = 67, Orden = 2 },
        //                                         new Opcion { Nombre="Editar Configuracion Instancia", NumeroOpcion = 68, Orden = 3 },
        //                                         new Opcion { Nombre="Eliminar Configuracion Instancia", NumeroOpcion = 69, Orden = 4 },
        //                                    }
        //                           },
        //            new Opcion { Nombre="Roles Instancia",
        //                           NumeroOpcion = 70,
        //                           Orden = 15,
        //                                    OpcionesHijas = new List<Opcion>{
        //                                         new Opcion { Nombre="Ver Roles Instancias", NumeroOpcion = 71, Orden = 1 },
        //                                         new Opcion { Nombre="Crear Rol Instancia", NumeroOpcion = 72, Orden = 2 },
        //                                         new Opcion { Nombre="Editar Rol Instancia", NumeroOpcion = 73, Orden = 3 },
        //                                         new Opcion { Nombre="Eliminar Rol Instancia", NumeroOpcion = 74, Orden = 4 },
        //                                    }
        //                           },

        //        };

        //        context.Opciones.AddRange(opciones);
        //        context.SaveChanges();

        //    }
        //}
    }
}
