using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace MiParroquia.API.Utils
{
    public class DateHelper
    {
        public static string ObtenerNombreDia(DateTime date)
        {
            string dia = "";
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dia = "Lunes";
                    break;
                case DayOfWeek.Tuesday:
                    dia = "Martes";
                    break;
                case DayOfWeek.Wednesday:
                    dia = "Miercoles";
                    break;
                case DayOfWeek.Thursday:
                    dia = "Jueves";
                    break;
                case DayOfWeek.Friday:
                    dia = "Viernes";
                    break;
                case DayOfWeek.Saturday:
                    dia = "Saturday";
                    break;
                case DayOfWeek.Sunday:
                    dia = "Domingo";
                    break;
            }

            return dia;
        }
    }
}
