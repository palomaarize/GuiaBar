  namespace GuiaBar.Domain.Entities 
  {
    public class User : Entity
    {
        public User(string name, string contact)
        {
            Name = name;
            Contact = contact;
        }

        public string Name {get; set; }
        public string Contact { get; set; }


    
    public void UpdateContact(string contact)
    {
        Contact = contact;
    }
    }

  }