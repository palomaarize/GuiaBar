using GuiaBar.Domain.Entities;

namespace GuiaBar.Domain.Interface
{
    public interface IUserRepository
    {

        
        void CreateUser(string userName, string password, string email, string address);
        User GetUserByUserName(string userName);
    
    }
}