using AutoMapper;
using CicekSepeti.Core.Infrastructure.BaseEntityModels.Abstract;
using CicekSepeti.Data.Repository.Infrastructure;

namespace CicekSepeti.Operation.OperationManager
{
    public abstract class BaseOperationManager : IOperationManager
    {
        protected BaseOperationManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }
    }
}
