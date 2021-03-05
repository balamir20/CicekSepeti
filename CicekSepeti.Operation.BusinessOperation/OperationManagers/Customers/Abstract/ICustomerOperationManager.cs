using CicekSepeti.Core.Infrastructure.Utilities.Results.Abstract;
using CicekSepeti.Model.DtoModel.Customers.Customer.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Operation.BusinessOperation.OperationManagers.Customers.Abstract
{
    public interface ICustomerOperationManager
    {
        Task<IDataResult<CustomerDto>> Get(int customerId);
        Task<IDataResult<IList<CustomerDto>>> GetList();
        Task<IResult> Insert(CustomerAddDto customerAddDto);
        Task<IResult> Update(CustomerUpdateDto customerUpdateDto);
        Task<IResult> Delete(int customerId); 
    }
}
