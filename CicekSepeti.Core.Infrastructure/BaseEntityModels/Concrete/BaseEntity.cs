using CicekSepeti.Core.Infrastructure.BaseEntityModels.Abstract;
using System;

namespace CicekSepeti.Core.Infrastructure.BaseEntityModels.Concrete
{
    public abstract class BaseEntity<TKey> : BaseModel<TKey>, IEntity<TKey>
    {
    }
}
