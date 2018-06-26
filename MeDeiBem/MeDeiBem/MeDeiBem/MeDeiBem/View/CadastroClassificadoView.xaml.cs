using MeDeiBem.Controls;
using MeDeiBem.DB;
using MeDeiBem.Model;
using MeDeiBem.ServicesAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroClassificadoView : ContentPage
	{
        private ObservableCollection<Hora> ListaHorarios;
        public CadastroClassificadoView ()
		{
			InitializeComponent ();
            
            VerificaClassificadoBaseLocal();

            CarregarCategorias();

            CarregarHorarios();
        }

        #region Variaveis que recebe os dados dos campos de cadastro.
        private string situacao;
        private string observacao;
        private string categoria;
        private string subCategoria;
        private string titulo;
        private string texto;
        private string contatoHora1Inicial;
        private string contatoHora1Final;
        private string contatoHora2Inicial;
        private string contatoHora2Final;
        private string telefone;
        private string email;
        #endregion

        /*
         * Métodos que carrega as categorias e as subcategorias para o picker. 
         */
        private async void CarregarCategorias()
        {
            List<Categoria> ListaCategorias = await CategoriaService.GetCategoria(DataBase.GetAppKey());
            PckCategoria.ItemsSource = ListaCategorias;
        }

        private async void CarregarSubCategorias(string keyUsuario, string idCategoria)
        {
            List<SubCategoria> ListaSubCategorias = await SubCategoriaService.GetSubCategoria(keyUsuario, idCategoria);
            PckSubCategoria.ItemsSource = ListaSubCategorias;
        }

        private void CarregarHorarios()
        {
            ListaHorarios = Horarios.GetHoras();
            PckHora1Final.ItemsSource = ListaHorarios;

            PckHora1Final.SelectedIndex = 0;
        }

        private async void VerificaClassificadoBaseLocal()
        {
            if (DataBase.GetClassificado() != null)
            {
                var dadosSituacao = await SituacaoClassificadoService.VerificaSituacaoClassificado(DataBase.GetAppKey());
               
                LblSituacao.Text = dadosSituacao.situacao;
                LblObservacao.Text = dadosSituacao.obs;

                var dadosClassificadoLocal = DataBase.GetClassificado();

                List<Categoria> ListaCategorias = await CategoriaService.GetCategoria(DataBase.GetAppKey());
                var _categoria = ListaCategorias.FindIndex(c => c.categoria == dadosClassificadoLocal.categ);
                PckCategoria.SelectedIndex = _categoria;

                var objCategoria = (Categoria)PckCategoria.SelectedItem;
                List<SubCategoria> ListaSubCategorias = await SubCategoriaService.GetSubCategoria(DataBase.GetAppKey(), objCategoria.idcategoria);
                var _subCategoria = ListaSubCategorias.FindIndex(s => s.subcategoria == dadosClassificadoLocal.subcateg);
                PckSubCategoria.SelectedIndex = _subCategoria;

                TxtTitulo.Text = dadosClassificadoLocal.titulo;
                TxtTexto.Text = dadosClassificadoLocal.texto;
                //TmpckHora1Inicial.Time = TimeSpan.Parse(dadosClassificadoLocal.contato_h1.Substring(0, 5));
                //TmpckHora2Inicial.Time = TimeSpan.Parse(dadosClassificadoLocal.contato_h2.Substring(13, 5));
                TxtTelefone.Text = dadosClassificadoLocal.contato_tel;
                TxtEmail.Text = dadosClassificadoLocal.contato_email;
            }
        }

        private void LimparCampos()
        {
            PckCategoria.SelectedIndex = -1;
            PckSubCategoria.ItemsSource = null;
            PckSubCategoria.Items.Clear();
            TxtTitulo.Text = string.Empty;
            TxtTexto.Text = string.Empty;
            //TmpckHora1Inicial.Time = TimeSpan.Zero;
            //TmpckHora1Final.Time = TimeSpan.Zero;
            TmpckHora2Inicial.Time = TimeSpan.Zero;
            TmpckHora2Final.Time = TimeSpan.Zero;
            TxtEmail.Text = string.Empty;
            TxtTelefone.Text = string.Empty;
        }

        private void PckCategoria_OnSelectIndexChange(object sender, EventArgs e)
        {
            var objCategoria = (Categoria)PckCategoria.SelectedItem;

            if (PckCategoria.SelectedIndex != -1)
            {
                CarregarSubCategorias(DataBase.GetAppKey(), objCategoria.idcategoria);

                categoria = objCategoria.categoria;
            }
        }

        private void PckSubCategoria_OnSelectIndexChange(object sender, EventArgs e)
        {
            var objSubCategoria = (SubCategoria)PckSubCategoria.SelectedItem;

            if (PckSubCategoria.SelectedIndex != -1)
            {
                subCategoria = objSubCategoria.subcategoria;
            }
        }

        private void PckHora1Inicial_OnSelectIndexChange(object sender, EventArgs e)
        {
            var objHorarios = (Hora)PckHora1Final.SelectedItem;

            if (PckHora1Final.SelectedIndex != -1)
            {
                contatoHora1Inicial = objHorarios.Horas;
            }
        }
        
        private void PckHora1Final_OnSelectIndexChange(object sender, EventArgs e)
        {
            var objHorarios = (Hora)PckHora1Final.SelectedItem;

            if (PckHora1Final.SelectedIndex != -1)
            {
                contatoHora1Final = objHorarios.Horas;
            }
        }

        private void TxtTitulo_OnTextChanged(object sender, EventArgs e)
        {
            titulo = TxtTitulo.Text;
        }

        private void TxtTexto_OnTextChanged(object sender, EventArgs e)
        {
            texto = TxtTexto.Text;
        }

        private void TxtTelefone_OnTextChanged(object sender, EventArgs e)
        {
            telefone = TxtTelefone.Text;
        }

        private void TxtEmail_OnTextChanged(object sender, EventArgs e)
        {
            email = TxtEmail.Text;
        }

        private async void BtnPublicar_OnCliked(object sender, EventArgs e)
        {   

            var classificado = new Classificado
            {
                categ = categoria,
                subcateg = subCategoria,
                titulo = titulo,
                texto = texto,
                contato_h1 = contatoHora1Inicial + contatoHora1Final,
                contato_h2 = contatoHora2Inicial + contatoHora2Final,
                contato_tel = telefone,
                contato_email = email
            };

            ActIndicatorRegistrar.IsVisible = true;

            await ClassificadoService.AddClassificado(DataBase.GetAppKey(), classificado);
            var dadosVerificacaoClassificado = await SituacaoClassificadoService.VerificaSituacaoClassificado(DataBase.GetAppKey());

            ActIndicatorRegistrar.IsVisible = false;

            classificado.situacao = dadosVerificacaoClassificado.situacao;
            classificado.observacao = dadosVerificacaoClassificado.obs;

            DataBase.AddClassificado(classificado);

            LimparCampos();
        }

        private void BtnCancelar_OnCliked(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}