using MeDeiBem.DB;
using MeDeiBem.Model;
using MeDeiBem.ServicesAPI;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MeDeiBem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BaixaDescontoView : ContentPage
	{        
        public BaixaDescontoView ()
		{
            InitializeComponent ();

            BindingContext = this;
		}

        #region Variaveis que recebe os dados dos campos de cadastro.
        private string codigoDesconto;
        private string senhaVendedor;
        private string quantidadeVendida;
        #endregion

        private void TxtCodigoDesconto_OnTextChange(object sender, EventArgs e)
        {
            codigoDesconto = TxtCodigoDesconto.Text;
        }

        private void TxtSenhaVendedor_OnTextChange(object sender, EventArgs e)
        {
            senhaVendedor = TxtSenhaVendedor.Text;
        }

        private void TxtQuantidadeVendida_OnTextChange(object sender, EventArgs e)
        {
            quantidadeVendida = TxtQuantidadeVendida.Text;
        }

        private async void BtnLerCodigoQR_OnClicked(object sender, EventArgs e)
        {   
            var ScannerPage = new ZXingScannerPage();

            ScannerPage.Title = "Leitor Código Baixa Desconto";

            ScannerPage.OnScanResult += (result) => {
                
                ScannerPage.IsScanning = false;
                
                Device.BeginInvokeOnMainThread(async () => {
                    await Navigation.PopAsync();
                    TxtCodigoDesconto.Text = result.Text;                    
                });
            };

            await Navigation.PushAsync(ScannerPage);
        }

        private void BtnRegistrar_OnClicked(object sender, EventArgs e)
        {
            ActIndicator.IsVisible = true;

            var baixaDesconto = new BaixaDesconto
            {
                cod_desc = codigoDesconto,
                senha_vend = senhaVendedor,
                qtde = quantidadeVendida,
            };

            ProcessaBaixaDesconto.BaixaDescontoPromocao(DataBase.GetAppKey(), baixaDesconto);

            ActIndicator.IsVisible = false;

            TxtCodigoDesconto.Text = string.Empty;
            TxtSenhaVendedor.Text = string.Empty;
            TxtQuantidadeVendida.Text = string.Empty;
        }
    }
}