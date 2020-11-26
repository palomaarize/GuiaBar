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
        public User GetUserById(long userId) => dbContext.Users.FirstOrDefault(u => u.Id == userId);
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

        public IEnumerable<Pub> GetAllPubs()
        {   
            IQueryable<Pub> pubsList =
            from pubs in dbContext.Pubs
            select pubs;
            return pubsList.ToList();
        }
        
    }
}