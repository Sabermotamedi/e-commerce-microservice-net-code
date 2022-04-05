using Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.GrpcService
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            this.discountProtoServiceClient = discountProtoServiceClient;
        }
        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest() { ProductName = productName };
            return await discountProtoServiceClient.GetDiscountAsync(discountRequest);
        }

        public async Task<CouponModel> CreateDiscount(CouponModel coupon)
        {
            var discount = new CouponModel() { ProductName = coupon.ProductName, Amount = coupon.Amount, Description = coupon.Description };
            var createDiscountRequest = new CreateDiscountRequest() { Coupon = discount };
            var res= await discountProtoServiceClient.CreateDiscountAsync(createDiscountRequest);
            return res;
        }
    }
}
