using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using GuiaBar.Domain.Config;
using GuiaBar.Domain.Entities;
using GuiaBar.Domain.Interface;
using GuiaBar.Domain.Services.Interface;
using Microsoft.IdentityModel.Tokens;

namespace GuiaBar.Domain.Services
{
    public class UserService : IUserService
    {   
        private readonly IPubRepository pubRepository;
        private readonly IUserRepository userRepository;
        private readonly IDistanceMatrixRepository distanceRepository;
        public UserService(IUserRepository userRepository, IPubRepository pubRepository, IDistanceMatrixRepository distanceRepository) 
        {
            this.userRepository = userRepository;
            this.pubRepository = pubRepository;
            this.distanceRepository = distanceRepository;
        }

        public void CreateUser(string userName, string password, string email, string address) => userRepository.CreateUser(userName, password, email, address);

        public Token Login(string userName, string password)
        {
            User user = userRepository.GetUserByUserName(userName);
            if(user == null)
            {
                throw new Exception("Usuario nao existe");
            }

            if(user.Password != password)
            {
                throw new Exception("Senha incorreta");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.TOKEN_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenstring = tokenHandler.WriteToken(token);

            return new Token {
                AccessToken = tokenstring,
                Authenticated = true,
                Expiration = tokenDescriptor.Expires.GetValueOrDefault(),
                Created = DateTime.Now
            };

        }   
        public void CreateEvaluation(long userId, string pubName, decimal evaluation)
        {
            long? pubId = pubRepository.GetPubByName(pubName).Id;
            if(pubId == null)
            {
                throw new NullReferenceException("Bar não cadastrado!");
            }
            userRepository.CreateEvaluation(userId, (long)pubId, evaluation);

            IEnumerable<UserPubEvaluation> userPubCollection = pubRepository.ListEvaluationById((long)pubId);
            decimal averageEvaluations = userPubCollection.Average(x => x.Evaluation);

            pubRepository.UpdateEvaluation((long)pubId, averageEvaluations);
        }

            public Root CountDistance(string userAddress, string pubAddress) => distanceRepository.GetRoute(userAddress, pubAddress);
             
    }
}