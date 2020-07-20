using Shopping.Business.Cart.Concrete;
using Shopping.Business.Coupons.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Coupons.CouponStrategies
{
    class RateCouponStrategy : ICouponStrategy
    {
        public void ApplyCoupon(ShoppingCart shoppingCart, decimal discountQuantity)
        {
            var amountOfCoupon = (shoppingCart.TotalAmount * discountQuantity) / 100;
            var newAmount = shoppingCart.TotalAmount - amountOfCoupon;
            //shoppingCart.DiscountedTotalAmount = newAmount > 0 ? newAmount : 0;
            shoppingCart.AppliedCouponDiscount += amountOfCoupon;
        }
    }
}
