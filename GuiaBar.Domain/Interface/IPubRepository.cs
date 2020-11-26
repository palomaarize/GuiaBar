using System.Collections.Generic;
using GuiaBar.Domain.Entities;

namespace GuiaBar.Domain.Interface
{
    public interface IPubRepository
    {       
        void CreatePub(string name, string description, string address, string contact );
        void UpdateEvaluation(long id, decimal evaluation);
        IEnumerable<UserPubEvaluation> ListEvaluationById(long pubId);
        Pub GetPubByName(string pubName);
        IEnumerable<Pub> GetAllPubs();
    }
}