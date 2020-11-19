namespace GuiaBar.Domain.Services.Interface
{
    public interface IUserService
    {
        void CreateUser(string userName, string password, string email);
        
    }
}