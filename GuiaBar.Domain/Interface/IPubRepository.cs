using GuiaBar.Domain.Entities;

namespace GuiaBar.Domain.Interface
{
    public interface IPubRepository
    {       
        void CreatePub(string name, string description, string address, string contact );
        void PubEvaluation(long id, decimal evaluation);
    }
}