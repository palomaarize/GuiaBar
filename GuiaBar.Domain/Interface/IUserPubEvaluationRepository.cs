namespace GuiaBar.Domain.Interface
{
    public interface IUserPubEvaluationRepository
    {
        void CreateEvaluation(long userId, long pubId, decimal evaluation);
        
    }
}