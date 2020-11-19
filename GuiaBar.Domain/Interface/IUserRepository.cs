namespace GuiaBar.Domain.Interface
{
    public interface IUserRepository
    {
        void CreateUser(string userName, string password, string email);
    
    }
}