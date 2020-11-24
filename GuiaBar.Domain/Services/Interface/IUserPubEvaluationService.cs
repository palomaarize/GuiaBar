namespace GuiaBar.Domain.Services.Interface
{
    public interface IUserPubEvaluationService
    {
        void CreateEvaluation(long userId, long pubId, decimal evaluation);
    }
}