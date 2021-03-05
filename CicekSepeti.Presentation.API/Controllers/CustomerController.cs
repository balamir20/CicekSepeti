//using AutoMapper;
//using CicekSepeti.Core.Api;
//using CicekSepeti.Core.Infrastructure.Utilities.Results.Abstract;
//using CicekSepeti.Data.Repository.Infrastructure;
//using CicekSepeti.Model.DtoModel.Customers.Customer.Dto;
//using CicekSepeti.Operation.OperationManager.Customers;
//using Microsoft.AspNetCore.Mvc;
//using NLog;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace CicekSepeti.Presentation.API.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class CustomerController : BaseApiController
//    {
//        private readonly CustomerOperationManager customerOperationManager;
//        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper)
//        {
//            customerOperationManager = new CustomerOperationManager(unitOfWork, mapper);
//        }
//        [HttpPost]
//        public async Task<IResult> Insert([FromBody] CustomerAddDto customerAddDto)
//        {
//            IResult result = await customerOperationManager.Insert(customerAddDto);
//            return result;
//        }
//        [HttpPost]
//        public async Task<IResult> Update([FromBody] CustomerUpdateDto customerUpdateDto)
//        {
//            IResult result = await customerOperationManager.Update(customerUpdateDto);
//            return result;
//        }

//        [HttpGet]
//        public async Task<IDataResult<CustomerDto>> Get(int customerId)
//        {
//            IDataResult<CustomerDto> result = await customerOperationManager.Get(customerId);
//            return result;
//        }
//        [HttpPost]
//        public async Task<IDataResult<IList<CustomerDto>>> GetList()
//        {
//            var result = await customerOperationManager.GetList();
//            return result;
//        }
//        [HttpGet]
//        public async Task<IResult> Delete(int customerId)
//        {
//            var result = await customerOperationManager.Delete(customerId);
//            return result;
//        }
//    }
//}
