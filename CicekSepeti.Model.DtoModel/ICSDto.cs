using CicekSepeti.Core.Infrastructure.BaseEntityModels.Abstract;
using System;

namespace CicekSepeti.Model.DtoModel
{
    public interface ICSDto : IModel<int>
    {
        public Guid UniqId { get; set; }
    }
}
