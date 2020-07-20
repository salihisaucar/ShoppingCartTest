using Shopping.Business.Cart.Concrete;
using Shopping.Business.Coupons.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Coupons.Concrete
{
    public class Coupon : ICoupon
    {
        public ICouponStrategy CouponStrategy { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal DiscountQuantity { get; set; }

        public Coupon(decimal minAmount, decimal discountQuantity, ICouponStrategy couponStrategy)
        {
            MinimumAmount = minAmount;
            CouponStrategy = couponStrategy;
            DiscountQuantity = discountQuantity;
        }

        public bool ApplyCoupon(ShoppingCart shoppingCart)
        {
            if (shoppingCart.TotalAmount > MinimumAmount)
            {
                CouponStrategy.ApplyCoupon(shoppingCart, DiscountQuantity);
                return true;
            }
            return false;
        }
    }
}
