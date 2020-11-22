using System;

namespace GuiaBar.Domain.Entities
{
    public class Token
    {
        public string UserId { get; set; }

        public bool Authenticated {get; set; }

        public  DateTime Created { get; set; }

        public DateTime Expiration { get; set; }

        public string AccessToken { get; set; }
        
    }
}