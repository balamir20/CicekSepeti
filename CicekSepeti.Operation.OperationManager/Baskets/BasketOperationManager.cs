using AutoMapper;
using CicekSepeti.Core.Infrastructure.Utilities.ComplexTypes;
using CicekSepeti.Core.Infrastructure.Utilities.Results.Abstract;
using CicekSepeti.Core.Infrastructure.Utilities.Results.Concrete;
using CicekSepeti.Data.Model.Infrastructure.Baskets.Basket.Entity;
using CicekSepeti.Data.Repository.Infrastructure;
using CicekSepeti.Model.DtoModel.Baskets.Basket.Dto;
using CicekSepeti.Model.DtoModel.Products.Product.Dto;
using CicekSepeti.Operation.BusinessOperation.OperationManagers.Baskets.Abstract;
using CicekSepeti.Operation.BusinessOperation.Products.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Operation.OperationManager.Baskets
{
    public class BasketOperationManager : BaseOperationManager, IBasketOperationManager
    {
        public BasketOperationManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        //public async Task<IResult> CheckBasket()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public IDataResult<BasketDto> InsertProductsToBasket(List<ProductDto> productDtos)
        {
            try
            {
                ProductDtoInsertBasketBusinessOperation productDtoInsertBasketBusinessOperation = new ProductDtoInsertBasketBusinessOperation(productDtos);
                BasketDto basketDto = productDtoInsertBasketBusinessOperation.Create();
                return new DataResult<BasketDto>(ResultStatus.Error, "Ürünler sepete eklendi", data: null);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IResult> Delete(int basketId)
        {
            try
            {
                BasketEntity basket = await UnitOfWork.Basket.GetAsync(basket => basket.Id == basketId);
                if (basket != null)
                {
                    bool deleteResult = UnitOfWork.Basket.Delete(basket);
                    if (deleteResult)
                        return new Result(ResultStatus.Success, $"{basket.Id} numaralı sepet silindi");
                    else
                        return new Result(ResultStatus.Error, "Silme işlemi gerçekleşmedi");
                }
                return new DataResult<BasketEntity>(ResultStatus.Error, "Böyle bir sepet bulunamadı", basket);

            }
            catch (Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IDataResult<BasketDto>> Get(int basketId)
        {
            try
            {
                BasketEntity basketEntities = await UnitOfWork.Basket.GetAsync(basket => basket.Id == basketId);
                BasketDto basketDto = Mapper.Map<BasketEntity, BasketDto>(basketEntities);
                if (basketDto != null)
                {
                    return new DataResult<BasketDto>(ResultStatus.Success, basketDto);
                }
                return new DataResult<BasketDto>(ResultStatus.Error, "Böyle bir sepet bulunamadı", data: null);
            }
            catch (Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IDataResult<IList<BasketDto>>> GetList()
        {
            try
            {
                IList<BasketEntity> basketEntities = await UnitOfWork.Basket.GetListAsync();
                List<BasketDto> basketDtos = Mapper.Map<List<BasketDto>>(basketEntities);
                if (basketDtos.Count > -1)
                {
                    return new DataResult<IList<BasketDto>>(ResultStatus.Success, basketDtos);
                }
                return new DataResult<IList<BasketDto>>(ResultStatus.Error, "Sepetler bulunamadı", data: null);
            }
            catch (Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IResult> Insert(BasketDto basketAddDto)
        {
            try
            {
                BasketEntity basket = Mapper.Map<BasketEntity>(basketAddDto);
                await UnitOfWork.Basket.AddAsync(basket);
                await UnitOfWork.SaveAsync();
                BasketDto result = Mapper.Map<BasketEntity, BasketDto>(basket);
                return new Result(ResultStatus.Success, $"{result.Id} eklendi");
            }
            catch (Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        public async Task<IResult> Update(BasketDto basketUpdateDto)
        {
            try
            {
                BasketEntity basket = Mapper.Map<BasketEntity>(basketUpdateDto);
                await UnitOfWork.Basket.UpdateAsync(basket);
                await UnitOfWork.SaveAsync();
                BasketDto result = Mapper.Map<BasketEntity, BasketDto>(basket);
                return new Result(ResultStatus.Success, $"{basket.Id} li sepet güncellendi");
            }
            catch (Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

    }
}
