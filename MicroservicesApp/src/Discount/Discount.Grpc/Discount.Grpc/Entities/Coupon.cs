// -----------------------------------------------------------------------
// <copyright file="Coupon.cs" company="SaberMotamedi">
// Copyright (c) SaberMotamedi. All rights reserved.  Developed with 🖤
// </copyright>
// -----------------------------------------------------------------------

namespace Discount.Grpc.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
