using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MeDeiBem.Model;

namespace MeDeiBem.Controls
{
    public class Horarios
    {
        private static List<Hora> ListaHoras { get; set; }

        public static List<Hora> GetHoras()
        {
            ListaHoras = new List<Hora>
            {
                new Hora() { Horas = "00:00" },
                new Hora() { Horas = "01:00" },
                new Hora() { Horas = "02:00" },
                new Hora() { Horas = "03:00" },
                new Hora() { Horas = "04:00" },
                new Hora() { Horas = "05:00" },
                new Hora() { Horas = "06:00" },
                new Hora() { Horas = "07:00" },
                new Hora() { Horas = "08:00" },
                new Hora() { Horas = "09:00" },
                new Hora() { Horas = "10:00" },
                new Hora() { Horas = "11:00" },
                new Hora() { Horas = "12:00" },
                new Hora() { Horas = "13:00" },
                new Hora() { Horas = "14:00" },
                new Hora() { Horas = "15:00" },
                new Hora() { Horas = "16:00" },
                new Hora() { Horas = "17:00" },
                new Hora() { Horas = "18:00" },
                new Hora() { Horas = "19:00" },
                new Hora() { Horas = "20:00" },
                new Hora() { Horas = "21:00" },
                new Hora() { Horas = "22:00" },
                new Hora() { Horas = "23:00" }
            };

            return ListaHoras;
        }
    }
}
