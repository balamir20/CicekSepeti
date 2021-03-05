using AutoMapper;
using CicekSepeti.Core.Infrastructure.Utilities.ComplexTypes;
using CicekSepeti.Core.Infrastructure.Utilities.Results.Abstract;
using CicekSepeti.Core.Infrastructure.Utilities.Results.Concrete;
using CicekSepeti.Data.Model.Infrastructure.Products.Product.Entity;
using CicekSepeti.Data.Repository.Infrastructure;
using CicekSepeti.Model.DtoModel.Products.Product.Dto;
using CicekSepeti.Model.ViewModel.Products.Product.Input;
using CicekSepeti.Operation.BusinessOperation.OperationManagers.Products.Abstract;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Operation.OperationManager.Products
{
    public class ProductOperationManager : BaseOperationManager, IProductOperationManager
    {
        public ProductOperationManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> Delete(int productId)
        {
            try
            {
                ProductEntity product = await UnitOfWork.Product.GetAsync(p => p.Id == productId);
                if (product != null)
                {
                    bool deleteResult = UnitOfWork.Product.Delete(product);
                    if (deleteResult)
                        return new Result(ResultStatus.Success, $"{product.ProductName} adlı ürün silindi");
                    else
                        return new Result(ResultStatus.Error, "Silme işlemi gerçekleşmedi");
                }
                return new DataResult<ProductEntity>(ResultStatus.Error, "Böyle bir ürün bulunamadı", product);
            }
            catch (Exception ex)
            {
                //Logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IDataResult<ProductDto>> Get(int productId)
        {
            try
            {
                ProductEntity product = await UnitOfWork.Product.GetAsync(product => product.Id == productId);
                ProductDto productDto = Mapper.Map<ProductEntity, ProductDto>(product);
                if (productDto != null)
                {
                    return new DataResult<ProductDto>(ResultStatus.Success, productDto);
                }
                return new DataResult<ProductDto>(ResultStatus.Error, "Böyle bir ürün bulunamadı", data: null);
            }
            catch (Exception ex)
            {
                //Logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IDataResult<ProductDto>> Get(ProductSearchInputModel productSearchInputModel)
        {
            try
            {
                ProductEntity product = await UnitOfWork.Product.GetAsync(p => p.ProductName == productSearchInputModel.ProductName && p.ProductDescription == productSearchInputModel.ProductDescription);
                ProductDto productDto = Mapper.Map<ProductEntity, ProductDto>(product);
                if (productDto != null)
                {
                    return new DataResult<ProductDto>(ResultStatus.Success, productDto);
                }
                return new DataResult<ProductDto>(ResultStatus.Error, "Böyle bir ürün bulunamadı", data: null);
            }
            catch (Exception ex)
            {
                //Logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IDataResult<IList<ProductDto>>> GetList()
        {
            try
            {
                IList<ProductEntity> productEntities = await UnitOfWork.Product.GetListAsync();
                List<ProductDto> productDtos = Mapper.Map<List<ProductDto>>(productEntities);
                if (productDtos.Count > -1)
                {
                    return new DataResult<IList<ProductDto>>(ResultStatus.Success, productDtos);
                }
                return new DataResult<IList<ProductDto>>(ResultStatus.Error, "Ürünler bulunamadı", data: null);
            }
            catch (Exception ex)
            {
                //Logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IResult> Insert(ProductAddDto productAddDto)
        {
            try
            {
                ProductEntity product = Mapper.Map<ProductEntity>(productAddDto);
                await UnitOfWork.Product.AddAsync(product);
                await UnitOfWork.SaveAsync();
                ProductAddDto result = Mapper.Map<ProductEntity, ProductAddDto>(product);
                return new Result(ResultStatus.Success, $"{result.ProductName} eklendi");
            }
            catch (Exception ex)
            {
                //Logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IResult> Update(ProductUpdateDto productUpdateDto)
        {
            try
            {
                ProductEntity product = Mapper.Map<ProductEntity>(productUpdateDto);
                await UnitOfWork.Product.UpdateAsync(product);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{product.ProductName} adlı ürün güncellendi");
            }
            catch (Exception ex)
            {
                //Logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }
    }
}
