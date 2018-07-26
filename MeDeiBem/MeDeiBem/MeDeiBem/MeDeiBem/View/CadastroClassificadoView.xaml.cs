using MeDeiBem.Controls;
using MeDeiBem.DB;
using MeDeiBem.Model;
using MeDeiBem.ServicesAPI;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroClassificadoView : ContentPage
	{
        public CadastroClassificadoView ()
		{
			InitializeComponent ();

            BindingContext = VerificaClassificadoBaseLocal();

            CarregaSituacao();

            CarregarCategorias();

            CarregarHorarios();
        }

        #region Variaveis que recebe os dados dos campos de cadastro.
        private string situacao;
        private string observacao;
        private string idCategoria;
        private string categoria;
        private string idSubcategoria;
        private string subcategoria;
        private string titulo;
        private string texto;
        private string contatoHora1Inicial;
        private string contatoHora1Final;
        private string contatoHora2Inicial;
        private string contatoHora2Final;
        private string telefone;
        private string email;
        #endregion

        #region Métodos que carrega as categorias, subcategorias e horarios para o picker. 
        private async void CarregarCategorias()
        {
            ActIndicator.IsVisible = true;
            ActIndicator.IsRunning = true;

            var dadosClassificadoLocal = DataBase.GetClassificado();

            if (dadosClassificadoLocal != null)
            {
                List<Categoria> ListaCategorias = await CategoriaService.GetCategoria(DataBase.GetAppKey());
                PckCategoria.ItemsSource = ListaCategorias;
                var _categoria = ListaCategorias.FindIndex(c => c.idcategoria == dadosClassificadoLocal.idCategoria);
                PckCategoria.SelectedIndex = _categoria;
            }
            else
            {
                List<Categoria> ListaCategorias = await CategoriaService.GetCategoria(DataBase.GetAppKey());
                PckCategoria.ItemsSource = ListaCategorias;
            }

            ActIndicator.IsVisible = false;
            ActIndicator.IsRunning = false;
        }

        private async void CarregarSubCategorias(string keyUsuario, string idCategoria)
        {   
            var dadosClassificadoLocal = DataBase.GetClassificado();

            if (dadosClassificadoLocal != null)
            {
                var objCategoria = (Categoria)PckCategoria.SelectedItem;
                List<SubCategoria> ListaSubCategorias = await SubCategoriaService.GetSubCategoria(DataBase.GetAppKey(), objCategoria.idcategoria);
                PckSubCategoria.ItemsSource = ListaSubCategorias;
                var _subCategoria = ListaSubCategorias.FindIndex(s => s.idsubcategoria == dadosClassificadoLocal.idSubcategoria);
                PckSubCategoria.SelectedIndex = _subCategoria;
            }
            else
            {
                List<SubCategoria> ListaSubCategorias = await SubCategoriaService.GetSubCategoria(keyUsuario, idCategoria);
                PckSubCategoria.ItemsSource = ListaSubCategorias;
            }
        }

        private void CarregarHorarios()
        {
            var dadosClassificadoLocal = DataBase.GetClassificado();

            List<Hora> ListaHorarios = Horarios.GetHoras();

            PckHora1Inicial.ItemsSource = ListaHorarios;
            PckHora1Final.ItemsSource = ListaHorarios;
            PckHora2Inicial.ItemsSource = ListaHorarios;
            PckHora2Final.ItemsSource = ListaHorarios;

            if (dadosClassificadoLocal != null)
            {   
                var Hora1Inicial = ListaHorarios.FindIndex(h => h.Horas == dadosClassificadoLocal.contatoHorario1.Substring(0, 5));
                PckHora1Inicial.SelectedIndex = Hora1Inicial;

                var Hora1Final = ListaHorarios.FindIndex(h => h.Horas == dadosClassificadoLocal.contatoHorario1.Substring(5, 5));
                PckHora1Final.SelectedIndex = Hora1Final;

                var Hora2Inicial = ListaHorarios.FindIndex(h => h.Horas == dadosClassificadoLocal.contatoHorario2.Substring(0, 5));
                PckHora2Inicial.SelectedIndex = Hora2Inicial;

                var Hora2Final = ListaHorarios.FindIndex(h => h.Horas == dadosClassificadoLocal.contatoHorario2.Substring(5, 5));
                PckHora2Final.SelectedIndex = Hora2Final;
            }
            else
            {
                PckHora1Inicial.SelectedIndex = 28;
                PckHora1Final.SelectedIndex = 48;
                PckHora2Inicial.SelectedIndex = 56;
                PckHora2Final.SelectedIndex = 72;
            }
        }
        #endregion

        private async void CarregaSituacao()
        {
            if (DataBase.GetClassificado() != null)
            {
                var dadosSituacao = await SituacaoClassificadoService.VerificaSituacaoClassificado(DataBase.GetAppKey());
                LblSituacao.Text = dadosSituacao.situacao;
                LblObservacao.Text = dadosSituacao.obs;
            }
        }

        private Classificado VerificaClassificadoBaseLocal()
        {
            ActIndicator.IsVisible = true;
            ActIndicator.IsRunning = true;

            var dadosClassificadoLocal = DataBase.GetClassificado();

            ActIndicator.IsVisible = false;
            ActIndicator.IsRunning = false;

            return dadosClassificadoLocal;
        }

        private void LimparCampos()
        {
            PckCategoria.SelectedIndex = -1;
            PckSubCategoria.ItemsSource = null;
            PckSubCategoria.Items.Clear();
            TxtTitulo.Text = string.Empty;
            TxtTexto.Text = string.Empty;
            PckHora1Inicial.SelectedIndex = 8;
            PckHora1Final.SelectedIndex = 12;
            PckHora2Inicial.SelectedIndex = 14;
            PckHora2Final.SelectedIndex = 18;
            TxtEmail.Text = string.Empty;
            TxtTelefone.Text = string.Empty;
        }

        private void PckCategoria_OnSelectIndexChange(object sender, EventArgs e)
        {
            var objCategoria = (Categoria)PckCategoria.SelectedItem;

            if (PckCategoria.SelectedIndex != -1)
            {
                CarregarSubCategorias(DataBase.GetAppKey(), objCategoria.idcategoria);

                idCategoria = objCategoria.idcategoria;
                categoria = objCategoria.categoria;
            }
        }

        private void PckSubCategoria_OnSelectIndexChange(object sender, EventArgs e)
        {
            var objSubCategoria = (SubCategoria)PckSubCategoria.SelectedItem;

            if (PckSubCategoria.SelectedIndex != -1)
            {
                idSubcategoria = objSubCategoria.idsubcategoria;
                subcategoria = objSubCategoria.subcategoria;
            }
        }

        private void PckHora1Inicial_OnSelectIndexChange(object sender, EventArgs e)
        {
            var objHorarios = (Hora)PckHora1Inicial.SelectedItem;

            if (PckHora1Inicial.SelectedIndex != -1)
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

        private void PckHora2Inicial_OnSelectIndexChange(object sender, EventArgs e)
        {
            var objHorarios = (Hora)PckHora2Inicial.SelectedItem;

            if (PckHora2Inicial.SelectedIndex != -1)
            {
                contatoHora2Inicial = objHorarios.Horas;
            }
        }

        private void PckHora2Final_OnSelectIndexChange(object sender, EventArgs e)
        {
            var objHorarios = (Hora)PckHora2Final.SelectedItem;

            if (PckHora2Final.SelectedIndex != -1)
            {
                contatoHora2Final = objHorarios.Horas;
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
            #region Validação de campos
            if (PckCategoria.SelectedIndex == -1 || idCategoria == null)
            {
                await DisplayAlert("Put's, faltou algo! :O", "O campo CATEGORIA é obrigatório!", "Ok");
                return;
            }

            if (PckSubCategoria.SelectedIndex == -1 || idSubcategoria == null)
            {
                await DisplayAlert("Put's, faltou algo! :O", "O campo SUBCATEGORIA é obrigatório!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(TxtTitulo.Text))
            {
                await DisplayAlert("Put's, faltou algo! :O", "O campo TÍTULO é obrigatório!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(TxtTexto.Text))
            {
                await DisplayAlert("Put's, faltou algo! :O", "O campo TEXTO é obrigatório!", "Ok");
                return;
            }

            if (PckHora1Inicial.SelectedIndex == -1 || PckHora1Inicial.SelectedIndex == -1 || contatoHora1Final == null ||contatoHora1Final == null)
            {
                await DisplayAlert("Put's, faltou algo! :O", "O campo HORARIO DE CONTATO 1 é obrigatório!", "Ok");
                return;
            }

            if (PckHora2Inicial.SelectedIndex == -1 || PckHora2Final.SelectedIndex == -1 || contatoHora2Inicial == null || contatoHora2Final == null)
            {
                await DisplayAlert("Put's, faltou algo! :O", "O campo HORARIO DE CONTATO 2 é obrigatório!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(TxtTelefone.Text))
            {
                await DisplayAlert("Put's, faltou algo! :O", "O campo TELEFONE é obrigatório!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                await DisplayAlert("Put's, faltou algo! :O", "O campo EMAIL é obrigatório!", "Ok");
                return;
            }
            #endregion

            var classificado = new Classificado
            {
                idCategoria = idCategoria,
                categ = categoria,
                idSubcategoria = idSubcategoria,
                subcateg = subcategoria,
                titulo = titulo,
                texto = texto,
                contato_h1 = contatoHora1Inicial.Substring(0, 2) + "-" + 
                             contatoHora1Inicial.Substring(3, 2) + "-" + 
                             contatoHora1Final.Substring(0, 2) + "-" + 
                             contatoHora1Final.Substring(3, 2),

                contato_h2 = contatoHora2Inicial.Substring(0, 2) + "-" +
                             contatoHora2Inicial.Substring(3, 2) + "-" +
                             contatoHora2Final.Substring(0, 2) + "-" +
                             contatoHora2Final.Substring(3, 2),

                contatoHorario1 = contatoHora1Inicial + contatoHora1Final,
                contatoHorario2 = contatoHora2Inicial + contatoHora2Final,
                contato_tel = telefone,
                contato_email = email
            };
            
            ActIndicatorRegistrar.IsVisible = true;

            await ClassificadoService.AddClassificado(DataBase.GetAppKey(), classificado);
            var dadosVerificacaoClassificado = await SituacaoClassificadoService.VerificaSituacaoClassificado(DataBase.GetAppKey());
            classificado.situacao = dadosVerificacaoClassificado.situacao;
            classificado.observacao = dadosVerificacaoClassificado.obs;
            
            ActIndicatorRegistrar.IsVisible = false;

            LimparCampos();
        }

        private void BtnCancelar_OnCliked(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}