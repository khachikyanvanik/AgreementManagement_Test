using AgreementManagement.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AgreementManagement.Domain.Entities
{
    public abstract class BaseEntity<TKey> : IQueryResult
        where TKey : struct
    {
        protected BaseEntity()
        {
        }

        protected BaseEntity(TKey id)
        {
            Id = id;
        }

        [Key]
        public virtual TKey Id { get; set; }
    }
}
