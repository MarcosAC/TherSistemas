using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MeDeiBem.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Evento verifica se houve mudança na propriedade.
        public event PropertyChangedEventHandler PropertyChanged;


        // Método que faz a chamada das modificaçoes das propriedades da View
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            /*
             * Invoca quem chamou o evento com o método Invoke que recebe dois parametros
             * 1º parametro: Quem invocou o evento, que no caso e a própria ViewModel usando o this.
             * 2º parametro: PropertyChangedEventArgs, criando um estancia e passando como parametro a propriedade.
             * 
             * Verifica se o evento PropertyChanged é nulo com o chapeu do Elvis "?" (Sinal de interrogação).
             * Se for nulo não chama o método Invoke.
            */
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Chama o OnPropertyChanged
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            /*
             *Verifica se houve mudança no valor da propriedade
             * Se não houve mudança não chama o OnPropertyChanged
             * Se houve mudança chama o OnPropertyChanged e faz a alteração na propriedade
            */
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
