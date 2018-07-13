using MeDeiBem.Model;
using SQLite;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace MeDeiBem.DB
{
    /*
     * Classe de conexão com o banco de dados.
     */
    public class DataBase
    {
        private static SQLiteConnection _conexao;

        public DataBase()
        {
            var dependencyService = DependencyService.Get<IPathDataBase>();
            string pathDataBase = dependencyService.GetPath("medeibem.sqlite");
            _conexao = new SQLiteConnection(pathDataBase);

            _conexao.CreateTable<Usuario>();
            _conexao.CreateTable<Classificado>();
        }

        public static void AddUsuario(Usuario usuario)
        {
            try
            {
                _conexao.InsertOrReplace(usuario);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro-> " + ex.Message);
            }
        }

        public void DeslogarUsuario()
        {
            try
            {
                _conexao.Query<Usuario>("DELETE FROM Usuario");
                _conexao.Query<Classificado>("DELETE FROM Classificado");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro-> " + ex.Message);
            }
        }

        public static void AddClassificado(Classificado classificado)
        {
            try
            {
                _conexao.InsertOrReplace(classificado);
            }
            catch (Exception Erro)
            {
                App.Current.MainPage.DisplayAlert("Put's, algo deu errado! :(", "Erro ao inserir dados do Classificado na base de dados local " + Erro, "Ok");
            }
        }

        public bool UsuarioLogado()
        {
            if (_conexao.Table<Usuario>().Count() == 0)
            {
                return false;
            }

            var dadosUsuario = _conexao.Table<Usuario>().FirstOrDefault();

            if (dadosUsuario.sinc_stat == 1)
            {
                return true;
            }

            return false;
        }

        public static Classificado GetClassificado()
        {
            if (_conexao.Table<Classificado>().Count() > 0)
            {
                var dadosClassificado = _conexao.Table<Classificado>().FirstOrDefault();
                return dadosClassificado;
            }
            
            return null;
        }

        public static string GetAppKey()
        {
            var dadosUsuario = _conexao.Table<Usuario>().Where(u => u.sinc_stat == 1).FirstOrDefault();
            return dadosUsuario.app_key;
        }

        public static Usuario GetUsuario()
        {
            var dadosUsuario = _conexao.Table<Usuario>().Where(u => u.sinc_stat == 1).FirstOrDefault();
            return dadosUsuario;
        }
    }
}
