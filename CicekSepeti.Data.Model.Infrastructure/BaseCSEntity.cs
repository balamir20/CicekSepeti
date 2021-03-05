using CicekSepeti.Core.Infrastructure.BaseEntityModels.Concrete;
using System;

namespace CicekSepeti.Data.Model.Infrastructure
{
    public class BaseCSEntity : BaseEntity<int>, ICSEntity
    {
        public Guid UniqId { get ; set; }
    }
}
