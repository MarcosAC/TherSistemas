using MeDeiBem.ServicesAPI;
using MeDeiBem.ServicesAPI.ModelAPI;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeDeiBem.ViewModel
{
    public class CadastroUsuarioViewModel : BaseViewModel
    {                
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string RadarUf { get; set; }
        public string RadarCidade { get; set; }
        public string Senha { get; set; }

        public ObservableCollection<RadarEstado> Estados { get; set; }
        public ObservableCollection<RadarCidade> Cidades { get; set; }

        public Command CadastrarCommand { get; set; }

        public CadastroUsuarioViewModel()
        {
            Estados = new ObservableCollection<RadarEstado>();
            Cidades = new ObservableCollection<RadarCidade>();

            CarregarListaEstados();
            CarregarListaCidades();
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

        private async Task ListaEstados()
        {
            try
            {
                var estados = await EstadoService.GetEstado();

                foreach (var item in estados)
                {
                    Estados.Add(item);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Erro:{ex.Message}", "Ok");
            }

            return;
        }

        private async Task ListaCidades()
        {
            try
            {
                var cidades = await CidadeService.GetCidade();

                foreach (var item in cidades)
                {
                    Cidades.Add(item);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Erro:{ex.Message}", "Ok");
            }
            return;
        }

        public async void CarregarListaEstados()
        {
            await ListaEstados();
        }

        public async void CarregarListaCidades()
        {
            await ListaCidades();
        }
    }
}
