using GuiaBar.Domain.Entities;
using GuiaBar.Domain.Interface;

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

    }
}