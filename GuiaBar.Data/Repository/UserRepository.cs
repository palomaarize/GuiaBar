using System.Linq;
using GuiaBar.Domain.Entities;
using GuiaBar.Domain.Interface;

namespace GuiaBar.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly GuiaBarContext dbContext;
        public UserRepository(GuiaBarContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public void CreateUser(string userName, string password, string email, string address)
        {

            User user = new User()
            {
                UserName = userName,
                Password = password,
                Email = email,
                Address = address,
                IsAdmin = false,
            };

            dbContext.Set<User>().Add(user);
            dbContext.SaveChanges();
        }

        public User GetUserByUserName(string userName) => dbContext.Users.FirstOrDefault(u => u.UserName == userName);
    }
}