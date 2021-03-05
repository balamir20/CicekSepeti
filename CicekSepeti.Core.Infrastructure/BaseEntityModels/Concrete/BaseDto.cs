using CicekSepeti.Core.Infrastructure.BaseEntityModels.Abstract;
using System;

namespace CicekSepeti.Core.Infrastructure.BaseEntityModels.Concrete
{
    public class BaseDto<TKey> : IModel<TKey>
    {
        public BaseDto()
        {
            IsActive = true;
        }
        public TKey Id { get; set; }
        private Guid _uniqId = Guid.NewGuid();
        public Guid UniqId
        {
            get { return _uniqId; }
            set { _uniqId = value; }
        }
        public bool IsActive { get; set; }
        public DateTime? DeletedTime { get; set; }
        public bool IsDeleted { get; set; }
        public int Position { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
