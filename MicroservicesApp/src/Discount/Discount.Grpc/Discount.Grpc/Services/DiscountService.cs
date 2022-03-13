using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository discountRepository;

        public DiscountService(IDiscountRepository discount)
        {
            this.discountRepository = discount;
        }
        //public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        //{
        //    var coupon = await discountRepository.GetDiscount(request.ProductName);
        //    if (coupon == null)
        //    {
        //        throw new RpcException(new Status(StatusCode.NotFound, $"Discount with productName={request.ProductName} NotFound"));
        //    }
        //    var couponModel = _mapper.Map<CouponModel>(coupon);
        //    return couponModel;
        //}

    }
}
