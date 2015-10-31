using System.ComponentModel.DataAnnotations;

namespace PizzaNet.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public virtual int Id { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}