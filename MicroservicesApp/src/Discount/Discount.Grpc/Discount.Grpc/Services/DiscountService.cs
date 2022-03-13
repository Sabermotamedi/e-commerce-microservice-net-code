// -----------------------------------------------------------------------
// <copyright file="DiscountService.cs" company="SaberMotamedi">
// Copyright (c) SaberMotamedi. All rights reserved.  Developed with 🖤
// </copyright>
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository discountRepository;
        private readonly IMapper mapper;

        public DiscountService(IDiscountRepository discount, IMapper mapper)
        {
            this.discountRepository = discount;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await this.discountRepository.GetDiscount(request.ProductName);
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with productName={request.ProductName} NotFound"));
            }

            var couponModel = this.mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = this.mapper.Map<Coupon>(request.Coupon);
            var result = await this.discountRepository.CreateDiscount(coupon);
            if (!result)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $""));
            }

            return this.mapper.Map<CouponModel>(coupon);
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = this.mapper.Map<Coupon>(request.Coupon);
            var res = await this.discountRepository.UpdateDiscount(coupon);
            if (!res)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $""));
            }

            return this.mapper.Map<CouponModel>(res);
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var res = await this.discountRepository.DeleteDiscount(request.ProductName);

            DeleteDiscountResponse deleteDiscountResponse = new DeleteDiscountResponse() { Success = res };
            return deleteDiscountResponse;
        }
    }
}
