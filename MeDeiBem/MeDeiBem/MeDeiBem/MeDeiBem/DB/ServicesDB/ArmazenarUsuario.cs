using MeDeiBem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using MeDeiBem.DB;
using System.Diagnostics;

namespace MeDeiBem.DB.ServicesDB
{
    public class ArmazenarUsuario
    {
        //readonly Usuario usuario = new Usuario();
        //public static void InserirUsuario(Usuario usuario)
        //{
        //    try
        //    {
        //        DataBase._conexao.Insert(usuario);
        //        Debug.WriteLine("Eita, deu certo. :D");
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Erro-> " + ex.Message);
        //    }
            
        //}

        ////public Usuario GetUsuario(int logado)
        ////{
        ////    return DataBase._conexao.Table<Usuario>().Where(u => u.IndLogado == logado).FirstOrDefault();
        ////}

        //public static void GetUsuario()
        //{
        //    //var dados = DataBase._conexao.Query<Usuario>("Seletc * From Usuario");
        //    //Debug.WriteLine("Dados Usuario Local" + dados.ToString());            
        //    var tabelaUsuario = DataBase._conexao.Table<Usuario>();
        //    foreach (var dados in tabelaUsuario)
        //    {
        //        Console.WriteLine("Dados Usuario Local" + dados.ToString());
        //    }
        //}
    }
}
