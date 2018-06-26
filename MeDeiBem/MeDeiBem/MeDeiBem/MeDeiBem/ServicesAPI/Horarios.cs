using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MeDeiBem.Model;

namespace MeDeiBem.Controls
{
    public class Horarios
    {
        private static ObservableCollection<Hora> ListaHoras { get; set; }

        public static ObservableCollection<Hora> GetHoras()
        {
            ListaHoras = new ObservableCollection<Hora>();
            
                ListaHoras.Add(new Hora() { Horas = "00:00" });
                ListaHoras.Add(new Hora() { Horas = "01:00" });
                ListaHoras.Add(new Hora() { Horas = "02:00" });
                ListaHoras.Add(new Hora() { Horas = "03:00" });
                ListaHoras.Add(new Hora() { Horas = "04:00" });
                ListaHoras.Add(new Hora() { Horas = "05:00" });
                ListaHoras.Add(new Hora() { Horas = "06:00" });
                ListaHoras.Add(new Hora() { Horas = "07:00" });
                ListaHoras.Add(new Hora() { Horas = "08:00" });
                ListaHoras.Add(new Hora() { Horas = "09:00" });
                ListaHoras.Add(new Hora() { Horas = "10:00" });
                ListaHoras.Add(new Hora() { Horas = "11:00" });
                ListaHoras.Add(new Hora() { Horas = "12:00" });
                ListaHoras.Add(new Hora() { Horas = "13:00" });
                ListaHoras.Add(new Hora() { Horas = "14:00" });
                ListaHoras.Add(new Hora() { Horas = "15:00" });
                ListaHoras.Add(new Hora() { Horas = "16:00" });
                ListaHoras.Add(new Hora() { Horas = "17:00" });
                ListaHoras.Add(new Hora() { Horas = "18:00" });
                ListaHoras.Add(new Hora() { Horas = "19:00" });
                ListaHoras.Add(new Hora() { Horas = "20:00" });
                ListaHoras.Add(new Hora() { Horas = "21:00" });
                ListaHoras.Add(new Hora() { Horas = "22:00" });
                ListaHoras.Add(new Hora() { Horas = "23:00" });
                ListaHoras.Add(new Hora() { Horas = "24:00" });

            return ListaHoras;
        }
    }
}
