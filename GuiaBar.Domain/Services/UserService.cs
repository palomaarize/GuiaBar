using GuiaBar.Domain.Interface;
using GuiaBar.Domain.Services.Interface;

namespace GuiaBar.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository) 
        {
            this.repository = repository;
        }

        public void CreateUser(string userName, string password, string email) => repository.CreateUser(userName, password, email);
    }
}