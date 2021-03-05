using AutoMapper;
using CicekSepeti.Core.Infrastructure.Utilities.ComplexTypes;
using CicekSepeti.Core.Infrastructure.Utilities.Results.Abstract;
using CicekSepeti.Core.Infrastructure.Utilities.Results.Concrete;
using CicekSepeti.Data.Model.Infrastructure.Customers.Customer.Entity;
using CicekSepeti.Data.Repository.Infrastructure;
using CicekSepeti.Model.DtoModel.Customers.Customer.Dto;
using CicekSepeti.Operation.BusinessOperation.OperationManagers.Customers.Abstract;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Operation.OperationManager.Customers
{
    public class CustomerOperationManager : BaseOperationManager, ICustomerOperationManager
    {

        public CustomerOperationManager(IUnitOfWork UnitOfWork, IMapper mapper) : base(UnitOfWork, mapper)
        {
        }

        public async Task<IResult> Insert(CustomerAddDto customerAddDto)
        {
            try
            {
                CustomerEntity customer = Mapper.Map<CustomerEntity>(customerAddDto);
                await UnitOfWork.Customer.AddAsync(customer);
                await UnitOfWork.SaveAsync();
                var result = Mapper.Map<CustomerEntity, CustomerAddDto>(customer);
                return new Result(ResultStatus.Success, $"{result.CustomerName} eklendi");
            }
            catch (Exception ex)
            {
                //Logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IResult> Delete(int customerId)
        {
            try
            {
                CustomerEntity customer = await UnitOfWork.Customer.GetAsync(customer => customer.Id == customerId);
                if (customer != null)
                {
                    bool deleteResult = UnitOfWork.Customer.Delete(customer);
                    if (deleteResult)
                        return new Result(ResultStatus.Success, $"{customer.CustomerName} adlı müşteri silindi");
                    else
                        return new Result(ResultStatus.Error, "Silme işlemi gerçekleşmedi");
                }
                return new DataResult<CustomerEntity>(ResultStatus.Error, "Böyle bir müşteri bulunamadı", customer);
            }
            catch (Exception ex)
            {
                //Logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IDataResult<IList<CustomerDto>>> GetList()
        {
            try
            {
                IList<CustomerEntity> customerEntities = await UnitOfWork.Customer.GetListAsync();
                List<CustomerDto> customerDtos = Mapper.Map<List<CustomerDto>>(customerEntities);
                if (customerDtos.Count > -1)
                {
                    return new DataResult<IList<CustomerDto>>(ResultStatus.Success, customerDtos);
                }
                return new DataResult<IList<CustomerDto>>(ResultStatus.Error, "Müşteriler bulunamadı", data: null);
            }
            catch (Exception ex)
            {
                //Logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IDataResult<CustomerDto>> Get(int customerId)
        {
            try
            {
                CustomerEntity customer = await UnitOfWork.Customer.GetAsync(customer => customer.Id == customerId);
                CustomerDto customerDto = Mapper.Map<CustomerEntity, CustomerDto>(customer);
                if (customerDto != null)
                {
                    return new DataResult<CustomerDto>(ResultStatus.Success, customerDto);
                }
                return new DataResult<CustomerDto>(ResultStatus.Error, "Böyle bir müşteri bulunamadı", data: null);
            }
            catch (Exception ex)
            {
                //Logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }

        }

        public async Task<IResult> Update(CustomerUpdateDto customerUpdateDto)
        {
            try
            {
                CustomerEntity customer = Mapper.Map<CustomerEntity>(customerUpdateDto);
                await UnitOfWork.Customer.UpdateAsync(customer);
                await UnitOfWork.SaveAsync();
                CustomerUpdateDto result = Mapper.Map<CustomerEntity, CustomerUpdateDto>(customer);
                return new Result(ResultStatus.Success, $"{result.CustomerName} adlı müşteri güncellendi");
            }
            catch (Exception ex)
            {
                //Logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }
    }
}
