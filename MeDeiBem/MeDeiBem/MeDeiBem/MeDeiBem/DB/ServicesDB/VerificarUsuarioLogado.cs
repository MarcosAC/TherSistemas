using MeDeiBem.Model;

namespace MeDeiBem.DB.ServicesDB
{
    public class VerificarUsuarioLogado
    {   
        public static bool Logado()
        {
            DataBase dataBase = new DataBase();
            return dataBase.UsuarioLogado();
        } 
        
        public static void Deslogar()
        {            
            DataBase dataBase = new DataBase();
            dataBase.DeslogarUsuario();            
        }
    }
}
