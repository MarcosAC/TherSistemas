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
                new Hora() { Horas = "00:15" },
                new Hora() { Horas = "00:30" },
                new Hora() { Horas = "00:45" },
                new Hora() { Horas = "01:00" },
                new Hora() { Horas = "01:15" },
                new Hora() { Horas = "01:30" },
                new Hora() { Horas = "01:45" },
                new Hora() { Horas = "02:00" },
                new Hora() { Horas = "02:15" },
                new Hora() { Horas = "02:30" },
                new Hora() { Horas = "02:45" },
                new Hora() { Horas = "03:00" },
                new Hora() { Horas = "03:15" },
                new Hora() { Horas = "03:30" },
                new Hora() { Horas = "03:45" },
                new Hora() { Horas = "04:00" },
                new Hora() { Horas = "04:15" },
                new Hora() { Horas = "04:30" },
                new Hora() { Horas = "04:45" },
                new Hora() { Horas = "05:00" },
                new Hora() { Horas = "05:15" },
                new Hora() { Horas = "05:30" },
                new Hora() { Horas = "05:45" },
                new Hora() { Horas = "06:00" },
                new Hora() { Horas = "06:15" },
                new Hora() { Horas = "06:30" },
                new Hora() { Horas = "06:45" },
                new Hora() { Horas = "07:00" },
                new Hora() { Horas = "07:15" },
                new Hora() { Horas = "07:30" },
                new Hora() { Horas = "07:45" },
                new Hora() { Horas = "08:00" },
                new Hora() { Horas = "08:15" },
                new Hora() { Horas = "08:30" },
                new Hora() { Horas = "08:45" },
                new Hora() { Horas = "09:00" },
                new Hora() { Horas = "09:15" },
                new Hora() { Horas = "09:30" },
                new Hora() { Horas = "09:45" },
                new Hora() { Horas = "10:00" },
                new Hora() { Horas = "10:15" },
                new Hora() { Horas = "10:30" },
                new Hora() { Horas = "10:45" },
                new Hora() { Horas = "11:00" },
                new Hora() { Horas = "11:15" },
                new Hora() { Horas = "11:30" },
                new Hora() { Horas = "11:45" },
                new Hora() { Horas = "12:00" },
                new Hora() { Horas = "12:15" },
                new Hora() { Horas = "12:30" },
                new Hora() { Horas = "12:45" },
                new Hora() { Horas = "13:00" },
                new Hora() { Horas = "13:15" },
                new Hora() { Horas = "13:30" },
                new Hora() { Horas = "13:45" },
                new Hora() { Horas = "14:00" },
                new Hora() { Horas = "14:15" },
                new Hora() { Horas = "14:30" },
                new Hora() { Horas = "14:45" },
                new Hora() { Horas = "15:00" },
                new Hora() { Horas = "15:15" },
                new Hora() { Horas = "15:30" },
                new Hora() { Horas = "15:45" },
                new Hora() { Horas = "16:00" },
                new Hora() { Horas = "16:15" },
                new Hora() { Horas = "16:30" },
                new Hora() { Horas = "16:45" },
                new Hora() { Horas = "17:00" },
                new Hora() { Horas = "17:15" },
                new Hora() { Horas = "17:30" },
                new Hora() { Horas = "17:45" },
                new Hora() { Horas = "18:00" },
                new Hora() { Horas = "18:15" },
                new Hora() { Horas = "18:30" },
                new Hora() { Horas = "18:45" },
                new Hora() { Horas = "19:00" },
                new Hora() { Horas = "19:15" },
                new Hora() { Horas = "19:30" },
                new Hora() { Horas = "19:45" },
                new Hora() { Horas = "20:00" },
                new Hora() { Horas = "20:15" },
                new Hora() { Horas = "20:30" },
                new Hora() { Horas = "20:45" },
                new Hora() { Horas = "21:00" },
                new Hora() { Horas = "21:15" },
                new Hora() { Horas = "21:30" },
                new Hora() { Horas = "21:45" },
                new Hora() { Horas = "22:00" },
                new Hora() { Horas = "22:15" },
                new Hora() { Horas = "22:30" },
                new Hora() { Horas = "22:45" },
                new Hora() { Horas = "23:00" },
                new Hora() { Horas = "23:15" },
                new Hora() { Horas = "23:30" },
                new Hora() { Horas = "23:45" }
            };

            return ListaHoras;
        }
    }
}
