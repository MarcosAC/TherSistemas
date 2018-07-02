using MeDeiBem.Controls;
using MeDeiBem.DB;
using MeDeiBem.Model;
using MeDeiBem.ServicesAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MeDeiBem.ViewModel
{
    class CadastroClassificadoViewModel : BaseViewModel
    {   
        public CadastroClassificadoViewModel()
        {
            ListaCategoria = new ObservableCollection<Categoria>();
            ListaSubCategoria = new ObservableCollection<SubCategoria>();
            ListaHoras = new ObservableCollection<Hora>();

            PublicarClassificado = new Command(ExecutePublicarClassificado);
            //CarregarSubCategoria = new Command(ExecuteCarregarSubCategoriaCommand);

            VerificaClassificadoBaseLocal();

            CarregarCategorias();
            CarregaHorarios();
        }

        public Command PublicarClassificado { get; }
        //public Command CarregarSubCategoria { get; }

        private string _situacao;

        public string Situacao
        {
            get { return _situacao; }
            set { SetProperty(ref _situacao, value); }
        }

        private string _observacao;

        public string Observacao
        {
            get { return _observacao; }
            set { SetProperty(ref _observacao, value); }
        }

        //private ObservableCollection<Categoria> _listaCategoria;

        //public ObservableCollection<Categoria> ListaCategoria
        //{
        //    get { return _listaCategoria; }
        //    set { SetProperty(ref _listaCategoria, value); }
        //}

        private Categoria _categoriaSelecionada;

        public Categoria CategoriaSelecionada
        {
            get { return _categoriaSelecionada; }
            set { SetProperty(ref _categoriaSelecionada, value); }
        }

        private SubCategoria _subcategoriaSelecionada;

        public SubCategoria SubCategoriaSelecionada
        {
            get { return _subcategoriaSelecionada; }
            set { SetProperty(ref _subcategoriaSelecionada, value); }
        }

        public ObservableCollection<Categoria> ListaCategoria { get; }

        public ObservableCollection<SubCategoria> ListaSubCategoria { get; }

        public ObservableCollection<Hora> ListaHoras { get; }

        private string _titulo;

        public string Titulo
        {
            get { return _titulo; }
            set { SetProperty(ref _titulo, value); }
        }
        private string _texto;

        public string Texto
        {
            get { return _texto; }
            set { SetProperty(ref _texto, value); }
        }

        private Hora _hora1Inicial;

        public Hora Hora1Inicial
        {
            get { return _hora1Inicial; }
            set { SetProperty(ref _hora1Inicial, value); }
        }

        private Hora _hora1Final;

        public Hora Hora1Final
        {
            get { return _hora1Final; }
            set { SetProperty(ref _hora1Final, value); }
        }

        private Hora _hora2Inicial;

        public Hora Hora2Inicial
        {
            get { return _hora2Inicial; }
            set { SetProperty(ref _hora2Inicial, value); }
        }

        private Hora _hora2Final;

        public Hora Hora2Final
        {
            get { return _hora2Final; }
            set { SetProperty(ref _hora2Final, value); }
        }

        private string _telefone;

        public string Telefone
        {
            get { return _telefone; }
            set { SetProperty(ref _telefone, value); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private async void CarregarCategorias()
        {
            var categorias = await CategoriaService.GetCategoria(DataBase.GetAppKey());
            
            ListaCategoria.Clear();

            foreach (var item in categorias)
            {
                ListaCategoria.Add(item);
            }
        }

        public async void CarregarSubCategorias(string idCategoria)
        {
            var listaSubCategoria = await SubCategoriaService.GetSubCategoria(DataBase.GetAppKey(), idCategoria);

            ListaSubCategoria.Clear();

            foreach (var item in listaSubCategoria)
            {
                ListaSubCategoria.Add(item);
            }
        }

        private async void VerificaClassificadoBaseLocal()
        {
            if (DataBase.GetClassificado() != null)
            {
                try
                {
                    var dadosSituacao = await SituacaoClassificadoService.VerificaSituacaoClassificado(DataBase.GetAppKey());

                    var dadosClassificadoLocal = DataBase.GetClassificado();

                    Situacao = dadosSituacao.situacao;
                    Observacao = dadosSituacao.obs;
                    CategoriaSelecionada =  ListaCategoria.ToList().Find(c => c.categoria == dadosClassificadoLocal.categ);
                    SubCategoriaSelecionada = ListaSubCategoria.ToList().Find(s => s.subcategoria == dadosClassificadoLocal.subcateg);
                    Titulo = dadosClassificadoLocal.titulo;
                    Texto = dadosClassificadoLocal.texto;
                    Hora1Inicial = ListaHoras.ToList().Find(h => h.Horas == dadosClassificadoLocal.contato_h1.Substring(0, 5));
                    Hora1Final = ListaHoras.ToList().Find(h => h.Horas == dadosClassificadoLocal.contato_h1.Substring(5, 5));
                    Hora2Inicial = ListaHoras.ToList().Find(h => h.Horas == dadosClassificadoLocal.contato_h2.Substring(0, 5));
                    Hora2Final = ListaHoras.ToList().Find(h => h.Horas == dadosClassificadoLocal.contato_h2.Substring(5, 5));
                    Telefone = dadosClassificadoLocal.contato_tel;
                    Email = dadosClassificadoLocal.contato_email;
                }                
                catch (Exception erro)
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "Erro => " + erro, "Ok");
                }
            }
        }

        private void CarregaHorarios()
        {
            var horarios = Horarios.GetHoras();

            ListaHoras.Clear();

            foreach (var horario in horarios)
            {
                ListaHoras.Add(horario);
            }
        }

        private async void ExecutePublicarClassificado()
        {
            var classificado = new Classificado
            {
                categ = CategoriaSelecionada.categoria,
                subcateg = SubCategoriaSelecionada.subcategoria,
                titulo = Titulo,
                texto = Texto,
                contato_h1 = Hora1Inicial.Horas + Hora1Final.Horas,
                contato_h2 = Hora2Inicial.Horas + Hora2Final.Horas,
                contato_tel = Telefone,
                contato_email = Email
            };

            await ClassificadoService.AddClassificado(DataBase.GetAppKey(), classificado);
            DataBase.AddClassificado(classificado);
            //var dadosVerificacaoClassificado = await SituacaoClassificadoService.VerificaSituacaoClassificado(DataBase.GetAppKey());

            //classificado.situacao = dadosVerificacaoClassificado.situacao;
            //classificado.observacao = dadosVerificacaoClassificado.obs;
        }
        
    }
}
