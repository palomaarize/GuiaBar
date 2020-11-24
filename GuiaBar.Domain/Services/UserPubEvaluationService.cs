using GuiaBar.Domain.Interface;

namespace GuiaBar.Domain.Services
{
    public class UserPubEvaluationService : IUserPubEvaluationRepository
    {

        private readonly IUserPubEvaluationRepository evaluationRepository;
        public UserPubEvaluationService(IUserPubEvaluationRepository evaluationRepository) 
        {
            this.evaluationRepository = evaluationRepository;
        }

        public void CreateEvaluation(long userId, long pubId, decimal evaluation) => evaluationRepository.CreateEvaluation(userId, pubId, evaluation);
    }
}