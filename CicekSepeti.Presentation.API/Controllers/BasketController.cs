using AutoMapper;
using CicekSepeti.Core.Api;
using CicekSepeti.Core.Infrastructure.Utilities.Results.Abstract;
using CicekSepeti.Data.Repository.Infrastructure;
using CicekSepeti.Model.DtoModel.Baskets.Basket.Dto;
using CicekSepeti.Operation.OperationManager.Baskets;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Presentation.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : BaseApiController
    {
        private readonly BasketOperationManager basketOperationManager;
        public BasketController(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper)
        {
            basketOperationManager = new BasketOperationManager(unitOfWork, mapper);
        }
        [HttpPost]
        public async Task<IResult> Insert([FromBody] BasketDto basketDto)
        {
            var result = await basketOperationManager.Insert(basketDto);
            return result;
        }
        [HttpPost]
        public async Task<IResult> Update([FromBody] BasketDto basketUpdate)
        {
            IResult result = await basketOperationManager.Update(basketUpdate);
            return result;
        }

        [HttpGet]
        public async Task<IDataResult<BasketDto>> Get(int basketId)
        {
            IDataResult<BasketDto> result = await basketOperationManager.Get(basketId);
            return result;
        }
        [HttpPost]
        public async Task<IDataResult<IList<BasketDto>>> GetList()
        {
            var result = await basketOperationManager.GetList();
            return result;
        }
        [HttpGet]
        public async Task<IResult> Delete(int basketId)
        {
            var result = await basketOperationManager.Delete(basketId);
            return result;
        }
    }
}
