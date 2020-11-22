using GuiaBar.Domain.Entities;

namespace GuiaBar.Domain.Services.Interface
{
    public interface IUserService
    {
        void CreateUser(string userName, string password, string email);
        Token Login(string userName, string password);
    }
}