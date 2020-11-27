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
    public class PubService : IPubService
    {
        private readonly IPubRepository repository;
        public PubService(IPubRepository repository) 
        {
            this.repository = repository;
        }

        public IEnumerable<Pub> GetAllPubs() => repository.GetAllPubs();

        // public Pub GetPubByName(string pubName) => repository.GetPubByName(pubName);

        public void CreatePub(string name, string description, string address, string contact)
        {   
            bool pubExist = repository.GetPubByName(name) != null;
            if(pubExist != false)
            {
                throw new Exception("Esse bar já foi cadastrado");
            }
            repository.CreatePub(name, description, address, contact);
        }

    }  
}