using Shopping.Business.Coupons.CouponStrategies;
using Shopping.Business.Coupons.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Coupons.Concrete
{
    public class CouponFactory
    {
        internal static AmountCouponStrategy AmountCouponStrategy { get; private set; }

        public static Coupon GenerateCoupon(decimal minAmount, decimal discountQuantity, CouponType discountType)
        {
            if (discountType == CouponType.Amount)
            {
                AmountCouponStrategy amountCouponStrategy = new AmountCouponStrategy();
                return new Coupon(minAmount, discountQuantity, amountCouponStrategy);
            }
            else if (discountType == CouponType.Rate)
            {
                RateCouponStrategy rateCouponStrategy = new RateCouponStrategy();
                return new Coupon(minAmount, discountQuantity, rateCouponStrategy);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
