using System;

namespace GuiaBar.Domain.Entities 
{
    public class Bar : Entity
    {
        public Bar(string name, string user, DateTime date, string contact)
        {
            Name = name;
            User = user;
            Date = date;
            Contact = contact;
        }

        public string Name {get; set; }

        public string Description { get; set; }

        public string Contact { get; set; }

        public DateTime Date { get; set; }

        public string User { get; set; }

    
    public void UpdateContact(string contact)
    {
        Contact = contact;
    }
    
    }

}