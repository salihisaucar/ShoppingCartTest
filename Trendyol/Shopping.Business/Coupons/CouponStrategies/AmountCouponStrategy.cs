using Shopping.Business.Cart.Concrete;
using Shopping.Business.Coupons.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Coupons.CouponStrategies
{
    class AmountCouponStrategy : ICouponStrategy
    {
        public void ApplyCoupon(ShoppingCart shoppingCart, decimal discountQuantity)
        {
            var newAmount = shoppingCart.TotalAmount - discountQuantity;
            shoppingCart.DiscountedTotalAmount = newAmount > 0 ? newAmount : 0;
            shoppingCart.AppliedCampaignDiscount += discountQuantity;
        }
    }
}
