
using System.Collections.Generic;
using GuiaBar.Domain.Entities;

namespace GuiaBar.Domain.Services.Interface
{
    public interface IPubService
    {
        void CreatePub(string name, string description, string address, string contact );
        
    }
}