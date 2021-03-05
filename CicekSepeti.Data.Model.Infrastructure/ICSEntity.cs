using CicekSepeti.Core.Infrastructure.BaseEntityModels.Abstract;
using System;

namespace CicekSepeti.Data.Model.Infrastructure
{
    public interface ICSEntity : IEntity<int>
    {
        public Guid UniqId { get; set; }
    }
}
