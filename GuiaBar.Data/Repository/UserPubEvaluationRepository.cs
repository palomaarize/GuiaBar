using GuiaBar.Domain.Entities;
using GuiaBar.Domain.Interface;

namespace GuiaBar.Data.Repository
{
    public class UserPubEvaluationRepository : IUserPubEvaluationRepository
    {
        private readonly GuiaBarContext dbContext;
        public UserPubEvaluationRepository(GuiaBarContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public void CreateEvaluation(long userId, long pubId, decimal evaluation)
        {

            UserPubEvaluation pubEvaluation = new UserPubEvaluation()
            {
                UserId = userId, 
                PubId = pubId, 
                Evaluation = evaluation, 
            };

            dbContext.Set<UserPubEvaluation>().Add(pubEvaluation);
            dbContext.SaveChanges();
        }

    }
}