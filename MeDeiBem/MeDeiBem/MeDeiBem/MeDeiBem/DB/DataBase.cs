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

        public void AddUsuario(Usuario usuario)
        {
            try
            {
                _conexao.Insert(usuario);
                Debug.WriteLine("Eita, deu certo. :D");
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
                _conexao.Query<Usuario>("UPDATE Usuario SET sinc_stat=0");
                Debug.WriteLine("Eita, deu certo. :D");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro-> " + ex.Message);
            }
        }

        public void InserirClassificado(Classificado classificado)
        {
            _conexao.Insert(classificado);
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

        public Classificado GetClassificado(int id)
        {
            return _conexao.Table<Classificado>().Where(c => c.IdClassificado == id).FirstOrDefault();
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
