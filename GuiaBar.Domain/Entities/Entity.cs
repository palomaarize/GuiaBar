using System;

namespace GuiaBar.Domain.Entities 
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        } 

        //Identificador Único
        public Guid Id { get; private set; }


        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}