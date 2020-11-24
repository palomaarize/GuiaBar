
namespace GuiaBar.Domain.Services.Interface
{
    public interface IPubService
    {
        void CreatePub(string name, string description, string address, string contact );
        void PubEvaluation(long id, decimal evaluation);
    }
}