using Proyecto_Final_DSWI.Models;

namespace Proyecto_Final_DSWI.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        public Admin loginAdmin(string username, string password);  
    }
}
