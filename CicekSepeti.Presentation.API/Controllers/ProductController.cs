using AutoMapper;
using CicekSepeti.Core.Api;
using CicekSepeti.Core.Infrastructure.Utilities.Results.Abstract;
using CicekSepeti.Data.Repository.Infrastructure;
using CicekSepeti.Model.DtoModel.Products.Product.Dto;
using CicekSepeti.Model.ViewModel.Products.Product.Input;
using CicekSepeti.Operation.OperationManager.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Presentation.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly ProductOperationManager productOperationManager;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper)
        {
            productOperationManager = new ProductOperationManager(unitOfWork, mapper);
        }
        [HttpPost]
        public async Task<IResult> Insert([FromBody] ProductAddDto productAddDto)
        {
            IResult result = await productOperationManager.Insert(productAddDto);
            return result;
        }
        [HttpPost]
        public async Task<IResult> Update([FromBody] ProductUpdateDto productUpdateDto)
        {
            IResult result = await productOperationManager.Update(productUpdateDto);
            return result;
        }

        [HttpGet]
        public async Task<IDataResult<ProductDto>> Get(int productId)
        {
            IDataResult<ProductDto> result = await productOperationManager.Get(productId);
            return result;
        }

        [HttpGet]
        public async Task<IDataResult<ProductDto>> GetWithName(ProductSearchInputModel productSearchInputModel)
        {
            IDataResult<ProductDto> result = await productOperationManager.Get(productSearchInputModel);
            return result;
        }
        [HttpPost]
        public async Task<IDataResult<IList<ProductDto>>> GetList()
        {
            var result = await productOperationManager.GetList();
            return result;
        }
        [HttpGet]
        public async Task<IResult> Delete(int productId)
        {
            var result = await productOperationManager.Delete(productId);
            return result;
        }
    }
}
