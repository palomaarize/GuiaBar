using System;
using System.Collections.Generic;
using System.Linq;
using GuiaBar.Domain.Entities;
using GuiaBar.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace GuiaBar.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly GuiaBarContext dbContext;
        public UserRepository(GuiaBarContext dbContext) 
        {
            this.dbContext = dbContext;
        }


        public void CreateUser(string userName, string password, string email, string address)
        {

            User user = new User()
            {
                UserName = userName,
                Password = password,
                Email = email,
                Address = address,
                IsAdmin = false,
            };

            dbContext.Set<User>().Add(user);
            dbContext.SaveChanges();
        }

        public User GetUserByUserName(string userName) => dbContext.Users.FirstOrDefault(u => u.UserName == userName);
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
        
        

        
        


        // List<UserPubEvaluation> evaluations = dbContext.UserPubEvaluations
        //  .Include(e => e.Evaluation)
        //  .Where(e => e.Id == id)
        //  .ToList();

        //  foreach (var e in evaluations);




        // public UserPubEvaluation MediaEvaluation(long id, decimal evaluation)
        // {
        //      List<UserPubEvaluation> posts = dbContext.UserPubEvaluations
        //      .Include(e => e.Evaluation)
        //      .Where(e => e.Id == id).ToList();


        //  public UserPubEvaluation GetPubById(long id){
        //     UserPubEvaluation getPubs = dbContext.UserPubEvaluations.Where((e) => e.Id == id);
        //  }

        //     //  List<UserPubEvaluation> evaluations = new List<UserPubEvaluation>();
        //     //  evaluations.Add(id, evaluation);


        //     throw new System.NotImplementedException();
        // }
    }
}