using System.Collections.Generic;
using GuiaBar.Domain.Entities;

namespace GuiaBar.Domain.Interface
{
    public interface IUserRepository
    {

        
        void CreateUser(string userName, string password, string email, string address);
        User GetUserByUserName(string userName);
        void CreateEvaluation(long userId, long pubId, decimal evaluation);
        // UserPubEvaluation GetEvaluationById(long pubId);
    }
}