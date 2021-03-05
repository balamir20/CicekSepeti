using System;

namespace CicekSepeti.Core.Infrastructure.BaseEntityModels.Abstract
{
    public interface IModel<TKey>
    {
        TKey Id { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime? UpdatedTime { get; set; }
        bool IsActive { get; set; }
        DateTime? DeletedTime { get; set; }
        bool IsDeleted { get; set; }
        int Position { get; set; }
    }
}
