using CicekSepeti.Core.Infrastructure.BaseEntityModels.Concrete;
using System;

namespace CicekSepeti.Model.DtoModel
{
    public class BaseCSDto : BaseModel<int>, ICSDto
    {
        private Guid _uniqId = Guid.NewGuid();
        public Guid UniqId
        {
            get { return _uniqId; }
            set { _uniqId = value; }
        }
    }
}
