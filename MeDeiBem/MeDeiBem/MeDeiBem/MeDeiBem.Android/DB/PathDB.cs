using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MeDeiBem.DB;
using MeDeiBem.Droid.DB;

namespace MeDeiBem.Droid.DB
{
    /*
     * Classe cria o arquivo de banco de dados em uma paste interna do sistema Android.
     */
    public class PathDB : IPathDataBase
    {
        public string GetPath(string NomeArquivoBanco)
        {
            string pathFolfer = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string pathDataBase = Path.Combine(pathFolfer, NomeArquivoBanco);

            return pathDataBase;
        }
    }
}