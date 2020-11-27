using System.Collections.Generic;
using System.Linq;
using GuiaBar.Domain.Entities;
using GuiaBar.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace GuiaBar.Data.Repository
{
    public class PubRepository : IPubRepository
    {
        private readonly GuiaBarContext dbContext;
        public PubRepository(GuiaBarContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public void CreatePub(string name, string description, string address, string contact)
        {

            Pub pub = new Pub()
            {
                Name = name, 
                Description = description, 
                Address = address, 
                Contact = contact
            };

            dbContext.Set<Pub>().Add(pub);
            dbContext.SaveChanges();
        }
        public IEnumerable<UserPubEvaluation> ListEvaluationById(long pubId)
        {   
            IQueryable<UserPubEvaluation> upEvaluation =
            from up in dbContext.UserPubEvaluations
            where up.PubId == pubId
            select up;
            return upEvaluation.ToList();
        }

        public void UpdateEvaluation(long id, decimal evaluation)
        {
            Pub pubEvaluation = new Pub() {Id = id};
            dbContext.Pubs.Attach(pubEvaluation);
            pubEvaluation.Evaluation = evaluation;
            dbContext.SaveChanges();
        }

        public Pub GetPubByName(string pubName) => dbContext.Pubs.AsNoTracking().FirstOrDefault(p => p.Name == pubName);

        
         public IEnumerable<Pub> GetAllPubs()
        {   
            IQueryable<Pub> pubsList =
            from pubs in dbContext.Pubs
            select pubs;
            return pubsList.ToList();
        }
    }
}