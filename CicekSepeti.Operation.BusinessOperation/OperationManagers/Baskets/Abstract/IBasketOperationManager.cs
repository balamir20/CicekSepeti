using CicekSepeti.Core.Infrastructure.Utilities.Results.Abstract;
using CicekSepeti.Model.DtoModel.Baskets.Basket.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Operation.BusinessOperation.OperationManagers.Baskets.Abstract
{
    public interface IBasketOperationManager
    {
        Task<IDataResult<BasketDto>> Get(int basketId);
        Task<IDataResult<IList<BasketDto>>> GetList();
        Task<IResult> Insert(BasketDto basketAddDto);
        Task<IResult> Update(BasketDto basketUpdateDto);
        Task<IResult> Delete(int basketId);
    }
}
