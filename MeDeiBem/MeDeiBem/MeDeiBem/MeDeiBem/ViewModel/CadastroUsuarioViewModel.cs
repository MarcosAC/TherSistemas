using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using MeDeiBem.ServicesAPI.Model;
using MeDeiBem.ServicesAPI;

namespace MeDeiBem.ViewModel
{
    public class CadastroUsuarioViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string RadarUf { get; set; }
        public string RadarCidade { get; set; }
        public string Senha { get; set; }

        public Command CadastrarCommand { get; set; }

        public CadastroUsuarioViewModel()
        {
            CadastrarCommand = new Command(Cadastrar);
        }

        private async void Cadastrar()
        {
            var usuario = new Usuario
            {
                Nome = Nome,
                Sobrenome = Sobrenome,
                Email = Email,
                RadarUf = RadarUf,
                RadarCidade = RadarCidade,
                Senha = Senha
            };

            if (await CadastrarUsuario.Inserir(usuario) == true)
            {
                await Application.Current.MainPage.DisplayAlert("Sucesso", "Usuario cadastrado com sucesso", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Erro ao cadastrar usuario", "OK");
            }
        }
    }
}
