using Shopping.Business.Cart.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business.Coupons.Abstract
{
    public interface ICouponStrategy
    {
        void ApplyCoupon(ShoppingCart shoppingCart, decimal discountQuantity);
    }
}
