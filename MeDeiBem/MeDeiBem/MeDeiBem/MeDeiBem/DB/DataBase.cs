using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using MeDeiBem.Model;

namespace MeDeiBem.DB
{
    /*
     * Classe de conexão com o banco de dados.
     */
    class DataBase
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

        public void InserirUsuario(Usuario usuario)
        {
            _conexao.Insert(usuario);
        }

        public void InserirClassificado(Classificado classificado)
        {
            _conexao.Insert(classificado);
        }

        public Usuario GetUsuario(int logado)
        {
            return _conexao.Table<Usuario>().Where(u => u.IndLogado == logado).FirstOrDefault();
        }

        public Classificado GetClassificado(int id)
        {
            return _conexao.Table<Classificado>().Where(c => c.IdClassificado == id).FirstOrDefault();
        }
    }
}
