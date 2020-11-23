using GuiaBar.Domain.Entities;

namespace GuiaBar.Domain.Services.Interface
{
    public interface IUserService
    {
        void CreateUser(string userName, string password, string email, string address);
        Token Login(string userName, string password);

    }
}