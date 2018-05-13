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
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { SetProperty(ref _nome, value); }
        }

        private string _sobrenome;

        public string Sobrenome
        {
            get { return _sobrenome; }
            set { SetProperty(ref _sobrenome, value); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _radarUf;

        public string RadarUf
        {
            get { return _radarUf; }
            set
            {
                if (_radarUf != value)
                {
                    _radarUf = value;
                    SetProperty(ref _radarUf, value);
                }
            }
        }

        private string _radarCidade;

        public string RadarCidade
        {
            get { return _radarCidade; }
            set { SetProperty(ref _radarCidade, value); }
        }

        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set { SetProperty(ref _senha, value); }
        }

        public ObservableCollection<RadarEstado> Estados { get; set; }
        public ObservableCollection<RadarCidade> Cidades { get; set; }

        public Command CadastrarUsuarioCommand { get; set; }

        public CadastroUsuarioViewModel()
        {
            Estados = new ObservableCollection<RadarEstado>();
            Cidades = new ObservableCollection<RadarCidade>();

            CarregarListaEstados();
            CarregarListaCidades();

            CadastrarUsuarioCommand = new Command(CadastrarUsuario);
        }

        private async void CadastrarUsuario()
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

            try
            {
                if (await ServicesAPI.CadastrarUsuario.AddUsuario(usuario) == true)
                {
                    await Application.Current.MainPage.DisplayAlert("Sucesso", "Usuario cadastrado com sucesso", "OK");
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }

            if (await ServicesAPI.CadastrarUsuario.AddUsuario(usuario) == true)
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
