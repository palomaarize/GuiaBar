using System.Collections.Generic;
using GuiaBar.Domain.Entities;

namespace GuiaBar.Domain.Services.Interface
{
    public interface IUserService
    {
        void CreateUser(string userName, string password, string email, string address);
        Token Login(string userName, string password);
        void CreateEvaluation(long userId, string pubName, decimal evaluation);
        // void GetEvaluationById(long pubId);
        Root CountDistance(long userId, string pubName);
         public IEnumerable<Pub> GetAllPubs();
    }
}