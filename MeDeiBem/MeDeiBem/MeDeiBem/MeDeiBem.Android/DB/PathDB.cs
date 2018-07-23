using MeDeiBem.DB;
using MeDeiBem.Droid.DB;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathDB))]
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