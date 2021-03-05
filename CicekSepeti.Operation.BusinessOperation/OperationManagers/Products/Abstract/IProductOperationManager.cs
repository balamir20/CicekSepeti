using CicekSepeti.Core.Infrastructure.Utilities.Results.Abstract;
using CicekSepeti.Model.DtoModel.Products.Product.Dto;
using CicekSepeti.Model.ViewModel.Products.Product.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Operation.BusinessOperation.OperationManagers.Products.Abstract
{
    public interface IProductOperationManager
    {
        Task<IDataResult<ProductDto>> Get(int productId);
        Task<IDataResult<ProductDto>> Get(ProductSearchInputModel productSearchInputModel);
        Task<IDataResult<IList<ProductDto>>> GetList();
        Task<IResult> Insert(ProductAddDto productAddDto);
        Task<IResult> Update(ProductUpdateDto productUpdateDto);
        Task<IResult> Delete(int productId);
    }
}
