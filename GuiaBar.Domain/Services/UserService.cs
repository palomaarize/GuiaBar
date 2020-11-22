using System;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository) 
        {
            this.repository = repository;
        }

        public void CreateUser(string userName, string password, string email) => repository.CreateUser(userName, password, email);

        public Token Login(string userName, string password)
        {
            User user = repository.GetUserByUserName(userName);
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
                    new Claim(ClaimTypes.Name, user.UserName)
                    //new Claim(ClaimTypes.Role, user.Role.ToString())
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
   
    }
}