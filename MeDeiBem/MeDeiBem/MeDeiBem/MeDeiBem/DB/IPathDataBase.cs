using System;
using System.Collections.Generic;
using System.Text;

namespace MeDeiBem.DB
{
    /*
     * Interface que recebe o caminho do banco de dados,
     * atravez da método GetPath.
     */
    public interface IPathDataBase
    {
        string GetPath(string NomeArquivoBanco);
    }
}
