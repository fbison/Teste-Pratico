using System;

namespace TestePratico.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
