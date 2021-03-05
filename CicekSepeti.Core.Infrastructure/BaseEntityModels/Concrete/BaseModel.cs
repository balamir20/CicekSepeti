using CicekSepeti.Core.Infrastructure.BaseEntityModels.Abstract;
using System;

namespace CicekSepeti.Core.Infrastructure.BaseEntityModels.Concrete
{
    public abstract class BaseModel<TKey> : IModel<TKey>
    {
        public BaseModel()
        {
            IsActive = true;
        }
        public TKey Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeletedTime { get; set; }
        public bool IsDeleted { get; set; }
        public int Position { get; set; }
    }
}
