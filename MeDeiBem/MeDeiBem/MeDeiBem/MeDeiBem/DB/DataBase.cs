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
        private SQLiteConnection _conexao;

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

        public void InserirClassificado(Classificado classificado)
        {
            _conexao.Insert(classificado);
        }

        public void GetUsuario()
        {
            //var dados = DataBase._conexao.Query<Usuario>("Seletc * From Usuario");
            //Debug.WriteLine("Dados Usuario Local" + dados.ToString()); 
            
            var tabelaUsuario =_conexao.Table<Usuario>();            
            foreach (var dados in tabelaUsuario)
            {
                App.Current.MainPage.DisplayAlert("Olha os dados aeee:", dados.nome + " " + dados.sobrenome, ":D");
                //Console.WriteLine("Dados Usuario Local" + dados.ToString());
            }
        }

        //public Usuario GetUsuario(int logado)
        //{
        //    return _conexao.Table<Usuario>().Where(u => u.IndLogado == logado).FirstOrDefault();
        //}

        public Classificado GetClassificado(int id)
        {
            return _conexao.Table<Classificado>().Where(c => c.IdClassificado == id).FirstOrDefault();
        }
    }
}
